using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Projeto_FinalOficial.Modelos;
using System.Collections.Generic;
using System.Linq; // Necessário para usar o Select e Where na montagem do endereço

namespace Projeto_FinalOficial.Servicos
{
    public class ImpressoraService
    {
        private Venda _vendaParaImprimir;

        // Fontes maiores e mais legíveis para A4
        private Font _fonteTitulo = new Font("Arial", 18, FontStyle.Bold);
        private Font _fonteSubTitulo = new Font("Arial", 12);
        private Font _fonteNegrito = new Font("Arial", 10, FontStyle.Bold);
        private Font _fonteNormal = new Font("Arial", 10);
        // --- NOVO: Fonte um pouco menor para detalhes do endereço ---
        private Font _fonteDetalhe = new Font("Arial", 9);

        public void ImprimirCupom(Venda venda)
        {
            _vendaParaImprimir = venda;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(MontarLayoutA4);
            pd.DocumentName = $"Venda_{venda.Id}";

            // --- FORÇA O PADRÃO A4 ---
            // O padrão A4 tem aproximadamente 827 x 1169 "unidades" de documento
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            // Margens padrão de escritório (1 polegada = ~100)
            pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            try
            {
                // Abre a janela de escolha de impressora (opcional, se quiser direto use pd.Print())
                PrintDialog dialog = new PrintDialog();
                dialog.Document = pd;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir: " + ex.Message);
            }
        }

        private void MontarLayoutA4(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Margens e Limites da Folha A4
            float margemEsq = e.MarginBounds.Left;
            float margemDir = e.MarginBounds.Right;
            float margemSup = e.MarginBounds.Top;
            float larguraUtil = e.MarginBounds.Width;

            float y = margemSup;
            Brush pincel = Brushes.Black;
            Pen caneta = new Pen(Brushes.Black, 1);

            // Ferramentas de Alinhamento
            StringFormat centro = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat esquerda = new StringFormat() { Alignment = StringAlignment.Near };
            StringFormat direita = new StringFormat() { Alignment = StringAlignment.Far };

            // ==========================================
            // 1. CABEÇALHO (LOGO E DADOS DA EMPRESA)
            // ==========================================

            // Título Centralizado
            RectangleF rectTitulo = new RectangleF(margemEsq, y, larguraUtil, 40);
            g.DrawString("CRIMSON SUIT", _fonteTitulo, pincel, rectTitulo, centro);
            y += 40;

            // Subtítulos
            g.DrawString("Rua Rio de Janeiro, 473 - Centro - Belo Horizonte/MG", _fonteSubTitulo, pincel, rectTitulo.X + (larguraUtil / 2), y, centro);
            y += 20;
            g.DrawString("CNPJ: 10.897.345/0001-00", _fonteSubTitulo, pincel, rectTitulo.X + (larguraUtil / 2), y, centro);
            y += 40;

            // Linha separadora grossa
            g.DrawLine(new Pen(Color.Black, 2), margemEsq, y, margemDir, y);
            y += 20;

            // ==========================================
            // 2. DADOS DO CLIENTE E VENDA (Bloco Esquerdo)
            // ==========================================
            // --- INÍCIO DAS ALTERAÇÕES NESTA SEÇÃO ---

            g.DrawString($"PEDIDO Nº: {_vendaParaImprimir.Id:D6}", _fonteNegrito, pincel, margemEsq, y);
            g.DrawString($"DATA: {_vendaParaImprimir.DataVenda:dd/MM/yyyy HH:mm}", _fonteNormal, pincel, margemEsq + 300, y);
            y += 25; // Dei um pouco mais de espaço aqui

            // LÓGICA PARA VERIFICAR O CLIENTE
            string linhaClienteNome;
            string linhaClienteEndereco = "";
            string linhaClienteContato = "";

            // Verifica se o objeto Cliente dentro da venda NÃO É NULO
            // (Lembre-se: sua consulta no banco precisa trazer esse objeto preenchido)
            if (_vendaParaImprimir.Cliente != null)
            {
                // --- Tem Cliente Cadastrado ---

                // 1. Monta linha do Nome e CPF
                linhaClienteNome = $"CLIENTE: {_vendaParaImprimir.Cliente.Nome.ToUpper()}";
                if (!string.IsNullOrEmpty(_vendaParaImprimir.Cliente.CPF))
                {
                    linhaClienteNome += $" - CPF: {_vendaParaImprimir.Cliente.CPF}";
                }

                // 2. Monta linha do Endereço (junta apenas as partes que não estão vazias)
                var partesEndereco = new List<string>
                {
                    _vendaParaImprimir.Cliente.Rua,
                    _vendaParaImprimir.Cliente.Numero,
                    _vendaParaImprimir.Cliente.Bairro,
                    _vendaParaImprimir.Cliente.Cidade,
                    _vendaParaImprimir.Cliente.Estado
                };
                // Filtra os nulos/vazios e junta com hífen
                string enderecoBase = string.Join(" - ", partesEndereco.Where(s => !string.IsNullOrEmpty(s)));

                if (!string.IsNullOrEmpty(enderecoBase))
                {
                    linhaClienteEndereco = $"ENDEREÇO: {enderecoBase}";
                    if (!string.IsNullOrEmpty(_vendaParaImprimir.Cliente.CEP))
                    {
                        linhaClienteEndereco += $" (CEP: {_vendaParaImprimir.Cliente.CEP})";
                    }
                }

                // 3. Monta linha do Contato
                if (!string.IsNullOrEmpty(_vendaParaImprimir.Cliente.Telefone))
                {
                    linhaClienteContato = $"CONTATO: {_vendaParaImprimir.Cliente.Telefone}";
                }
            }
            else
            {
                // --- Não tem cliente (é nulo) ---
                linhaClienteNome = "CLIENTE: Consumidor Final";
            }

            // --- IMPRESSÃO DAS LINHAS DO CLIENTE ---

            // Imprime o Nome (sempre imprime)
            g.DrawString(linhaClienteNome, _fonteNegrito, pincel, margemEsq, y);
            y += 20;

            // Imprime Endereço (se houver) com fonte um pouco menor
            if (!string.IsNullOrEmpty(linhaClienteEndereco))
            {
                g.DrawString(linhaClienteEndereco, _fonteDetalhe, pincel, margemEsq, y);
                y += 18; // Avanço menor
            }

            // Imprime Contato (se houver) com fonte um pouco menor
            if (!string.IsNullOrEmpty(linhaClienteContato))
            {
                g.DrawString(linhaClienteContato, _fonteDetalhe, pincel, margemEsq, y);
                y += 18; // Avanço menor
            }

            y += 15; // Espaço final antes da tabela
            // --- FIM DAS ALTERAÇÕES NESTA SEÇÃO ---


            // ==========================================
            // 3. TABELA DE PRODUTOS (COM COLUNA COR)
            // ==========================================

            // --- A. DEFINIÇÃO DAS POSIÇÕES X (AJUSTADO) ---
            // Vamos dividir a largura útil. Supondo margemEsq = 50.

            float xItem = margemEsq;          // Começo (Nome)
            float xCor = margemEsq + 340;     // <--- NOVA COLUNA (Começa após o nome)
            float xQtd = margemEsq + 450;     // Empurrei um pouco para direita
            float xUnit = margemEsq + 530;    // Empurrei um pouco para direita
            float xTotal = margemDir;         // Fim (Alinhado à direita)

            // Fundo cinza para o cabeçalho
            g.FillRectangle(Brushes.LightGray, margemEsq, y, larguraUtil, 25);
            g.DrawRectangle(caneta, margemEsq, y, larguraUtil, 25);

            // --- B. CABEÇALHO DA TABELA ---
            float yHeader = y + 5;
            g.DrawString("DESCRIÇÃO", _fonteNegrito, pincel, xItem + 5, yHeader);
            g.DrawString("COR", _fonteNegrito, pincel, xCor, yHeader);           // <--- TÍTULO NOVO
            g.DrawString("QTD", _fonteNegrito, pincel, xQtd, yHeader);
            g.DrawString("VL. UNIT", _fonteNegrito, pincel, xUnit, yHeader);
            g.DrawString("TOTAL", _fonteNegrito, pincel, xTotal, yHeader, direita);

            y += 30; // Sai do cabeçalho

            // --- C. LOOP DE ITENS ---
            foreach (var item in _vendaParaImprimir.Itens)
            {
                // 1. NOME DO PRODUTO (Encurtado para dar espaço à cor)
                string nomeProduto = $"{item.IdProduto} - {item.NomeProduto}";

                // Reduzi o limite de corte de 45 para 32 caracteres para não bater na cor
                if (nomeProduto.Length > 32) nomeProduto = nomeProduto.Substring(0, 32) + "...";

                g.DrawString(nomeProduto, _fonteNormal, pincel, xItem, y);

                // 2. COR (NOVO)
                // Verifica se tem cor, senão coloca um tracinho "-"
                // ATENÇÃO: Substitua 'item.Cor' pela propriedade correta do seu sistema se for diferente
                string corProduto = string.IsNullOrEmpty(item.Cor) ? "-" : item.Cor;

                // Corta a cor se for um nome gigante (ex: "Azul Marinho Escuro")
                if (corProduto.Length > 12) corProduto = corProduto.Substring(0, 12);

                g.DrawString(corProduto, _fonteNormal, pincel, xCor, y);

                // 3. RESTANTE DAS COLUNAS (Iguais ao anterior)
                g.DrawString(item.Quantidade.ToString(), _fonteNormal, pincel, xQtd + 10, y);
                g.DrawString(item.ValorUnitario.ToString("C2"), _fonteNormal, pincel, xUnit, y);
                g.DrawString(item.Subtotal.ToString("C2"), _fonteNormal, pincel, xTotal, y, direita);

                // Linha fina cinza
                y += 20;
                g.DrawLine(Pens.LightGray, margemEsq, y, margemDir, y);
                y += 5;
            }

            y += 10;

            // ==========================================
            // 4. TOTALIZADORES (CORRIGIDO PARA NÃO ENCAVALAR)
            // ==========================================

            // Define altura da caixa de totais
            float alturaCaixaTotal = 50; // Aumentei para 50px para ficar mais espaçado

            // Opcional: Pinta o fundo de cinza bem clarinho para destacar
            g.FillRectangle(Brushes.WhiteSmoke, margemEsq, y, larguraUtil, alturaCaixaTotal);
            g.DrawRectangle(caneta, margemEsq, y, larguraUtil, alturaCaixaTotal);

            // --- CÁLCULOS DE POSIÇÃO (AQUI ESTÁ A CORREÇÃO) ---

            // 1. Centralizar verticalmente dentro da caixa
            // Fórmula: Y_Inicial + (AlturaCaixa - AlturaFonte) / 2
            float yTextoPequeno = y + (alturaCaixaTotal - _fonteNormal.GetHeight(g)) / 2;
            float yTextoGrande = y + (alturaCaixaTotal - _fonteTitulo.GetHeight(g)) / 2;

            // 2. Desenhar Quantidade (Esquerda)
            g.DrawString($"Qtd Itens: {_vendaParaImprimir.Itens.Count} ", _fonteNormal, pincel, xItem + 10, yTextoPequeno);

            // 3. Desenhar TOTAL (Direita) - Lógica inteligente
            string textoValor = _vendaParaImprimir.ValorTotal.ToString("C2");
            string textoLabel = "TOTAL A PAGAR:";

            // Passo A: Desenhar o VALOR encostado na margem direita (xTotal)
            g.DrawString(textoValor, _fonteTitulo, pincel, xTotal, yTextoGrande, direita);

            // Passo B: Medir o tamanho físico do valor em pixels
            SizeF tamanhoDoValor = g.MeasureString(textoValor, _fonteTitulo);

            // Passo C: Calcular onde o Label deve ficar (MargemDireita - TamanhoValor - 10px de respiro)
            float xLabel = xTotal - tamanhoDoValor.Width - 10;

            // Passo D: Desenhar o Label alinhado à DIREITA dessa nova posição
            g.DrawString(textoLabel, _fonteTitulo, pincel, xLabel, yTextoGrande, direita);

            // Avança o Y para o rodapé
            y += alturaCaixaTotal + 20;

            // ==========================================
            // 5. MENSAGEM FINAL
            // ==========================================
            g.DrawLine(caneta, margemEsq, y, margemDir, y); // Linha assinatura (opcional)
            y += 5;
            g.DrawString("Obrigado pela preferência!", _fonteNormal, pincel, margemEsq + (larguraUtil / 2), y, centro);
        }
    }
}