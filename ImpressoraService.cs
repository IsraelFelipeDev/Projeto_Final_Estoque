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
    
    // Variável local para armazenar o pedido durante a impressão
        private PedidoCompraImpressao _pedidoParaImprimir;

        // Método Público para chamar a impressão
        public void ImprimirPedidoCompra(PedidoCompraImpressao pedido)
        {
            _pedidoParaImprimir = pedido;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(MontarLayoutNotaFiscal);
            pd.DocumentName = $"Pedido_Compra_{pedido.IdPedido}";

            // Configura A4
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40); // Margens um pouco menores para caber as caixas

            PrintDialog dialog = new PrintDialog();
            dialog.Document = pd;

            // DICA: Para salvar como PDF automaticamente, você pode configurar aqui,
            // mas deixar o Dialog permite o usuário escolher "Microsoft Print to PDF".
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        // Lógica de Desenho estilo DANFE / Nota Fiscal
        private void MontarLayoutNotaFiscal(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float top = e.MarginBounds.Top;
            float left = e.MarginBounds.Left;
            float right = e.MarginBounds.Right;
            float width = e.MarginBounds.Width;
            float y = top;

            Pen canetaFina = new Pen(Color.Black, 1);
            Pen canetaGrossa = new Pen(Color.Black, 2);
            Brush pincel = Brushes.Black;

            // Fontes específicas para NF
            Font fontTituloGrande = new Font("Arial", 14, FontStyle.Bold);
            Font fontLabel = new Font("Arial", 6, FontStyle.Regular); // "CNPJ", "DATA", etc.
            Font fontConteudo = new Font("Arial", 8, FontStyle.Regular); // O texto em si
            Font fontConteudoBold = new Font("Arial", 8, FontStyle.Bold);

            // =========================================================
            // HELPER: Função local para desenhar caixas com título pequeno
            // =========================================================
            void DesenharCampo(string label, string valor, float x, float yPos, float w, float h, bool destaque = false)
            {
                g.DrawRectangle(canetaFina, x, yPos, w, h);
                g.DrawString(label, fontLabel, Brushes.Gray, x + 2, yPos + 2);

                // Centraliza verticalmente o valor
                float yTexto = yPos + (h / 2) - 2;
                Font f = destaque ? fontConteudoBold : fontConteudo;
                g.DrawString(valor, f, pincel, x + 3, yTexto);
            }

            // =========================================================
            // 1. CABEÇALHO (IDENTIFICAÇÃO)
            // =========================================================
            float alturaCabecalho = 80;

            // Caixa Grande do Fornecedor (Emitente Simulada)
            g.DrawRectangle(canetaGrossa, left, y, width, alturaCabecalho);

            // Coluna da Esquerda (Dados do Fornecedor)
            g.DrawString(_pedidoParaImprimir.FornecedorNome.ToUpper(), fontTituloGrande, pincel, left + 10, y + 10);
            g.DrawString(_pedidoParaImprimir.FornecedorEndereco, fontConteudo, pincel, left + 10, y + 40);
            g.DrawString("CNPJ: " + _pedidoParaImprimir.FornecedorCNPJ, fontConteudoBold, pincel, left + 10, y + 55);

            // Coluna da Direita (Dados do Pedido - Fixo estilo DANFE)
            float xDir = left + (width * 0.6f); // 60% da largura
            g.DrawLine(canetaFina, xDir, y, xDir, y + alturaCabecalho); // Linha divisória vertical

            g.DrawString("PEDIDO DE COMPRA", fontTituloGrande, pincel, xDir + 10, y + 10);
            g.DrawString("Nº " + _pedidoParaImprimir.IdPedido.ToString("D6"), new Font("Arial", 12, FontStyle.Bold), Brushes.Red, xDir + 10, y + 35);
            g.DrawString("NATUREZA DA OPERAÇÃO", fontLabel, Brushes.Gray, xDir + 10, y + 55);
            g.DrawString("COMPRA DE MERCADORIAS", fontConteudo, pincel, xDir + 10, y + 65);

            y += alturaCabecalho + 10;

            // =========================================================
            // 2. DESTINATÁRIO (SUA LOJA)
            // =========================================================
            // Título da Seção
            g.FillRectangle(Brushes.LightGray, left, y, width, 15);
            g.DrawRectangle(canetaFina, left, y, width, 15);
            g.DrawString("DESTINATÁRIO / REMETENTE", fontConteudoBold, pincel, left + 5, y + 2);
            y += 15;

            // Linha 1: Nome e CNPJ
            DesenharCampo("NOME / RAZÃO SOCIAL", _pedidoParaImprimir.LojaNome, left, y, width * 0.7f, 30);
            DesenharCampo("CNPJ / CPF", _pedidoParaImprimir.LojaCNPJ, left + (width * 0.7f), y, width * 0.3f, 30);
            y += 30;

            // Linha 2: Endereço e Data Emissão
            DesenharCampo("ENDEREÇO", _pedidoParaImprimir.LojaEndereco, left, y, width * 0.7f, 30);
            DesenharCampo("DATA DA EMISSÃO", _pedidoParaImprimir.DataEmissao.ToString("dd/MM/yyyy"), left + (width * 0.7f), y, width * 0.3f, 30);
            y += 35; // Espaço extra

            // =========================================================
            // 3. ITENS DO PEDIDO (GRID)
            // =========================================================
            g.FillRectangle(Brushes.LightGray, left, y, width, 15);
            g.DrawRectangle(canetaFina, left, y, width, 15);
            g.DrawString("DADOS DO PRODUTO / SERVIÇO", fontConteudoBold, pincel, left + 5, y + 2);
            y += 15;

            // Cabeçalhos das Colunas
            float hHeader = 20;
            float[] cols = { 0.1f, 0.45f, 0.1f, 0.1f, 0.12f, 0.13f }; // Porcentagens da largura
                                                                      // 0=Cód, 1=Desc, 2=Un, 3=Qtd, 4=Unit, 5=Total

            float xAtual = left;
            string[] headers = { "CÓDIGO", "DESCRIÇÃO DO PRODUTO", "UN", "QTD", "VL. UNIT", "VL. TOTAL" };

            // Desenha cabeçalho
            for (int i = 0; i < cols.Length; i++)
            {
                float wCol = width * cols[i];
                g.DrawRectangle(canetaFina, xAtual, y, wCol, hHeader);
                // Centraliza texto
                StringFormat sf = new StringFormat { Alignment = (i >= 3) ? StringAlignment.Far : StringAlignment.Near, LineAlignment = StringAlignment.Center };
                RectangleF rect = new RectangleF(xAtual + 2, y, wCol - 4, hHeader);
                g.DrawString(headers[i], fontLabel, pincel, rect, sf);
                xAtual += wCol;
            }
            y += hHeader;

            // Desenha Itens
            foreach (var item in _pedidoParaImprimir.Itens)
            {
                float hLinha = 20;
                xAtual = left;

                // Dados a imprimir
                string[] dados = {
                    item.Codigo,
                    item.Descricao, // Aqui você pode concatenar a COR se quiser: item.Descricao + " - " + item.Cor
                    item.Unidade,
                    item.Quantidade.ToString(),
                    item.ValorUnitario.ToString("N2"),
                    item.Total.ToString("N2")
                };

                for (int i = 0; i < cols.Length; i++)
                {
                    float wCol = width * cols[i];
                    g.DrawRectangle(canetaFina, xAtual, y, wCol, hLinha);

                    StringFormat sf = new StringFormat { Alignment = (i >= 3) ? StringAlignment.Far : StringAlignment.Near, LineAlignment = StringAlignment.Center };
                    RectangleF rect = new RectangleF(xAtual + 2, y, wCol - 4, hLinha);

                    g.DrawString(dados[i], fontConteudo, pincel, rect, sf);
                    xAtual += wCol;
                }
                y += hLinha;
            }

            y += 10;

            // =========================================================
            // 4. CÁLCULO DO IMPOSTO (TOTAIS E FRETE)
            // =========================================================
            g.FillRectangle(Brushes.LightGray, left, y, width, 15);
            g.DrawRectangle(canetaFina, left, y, width, 15);
            g.DrawString("CÁLCULO DO IMPOSTO E TOTAIS", fontConteudoBold, pincel, left + 5, y + 2);
            y += 15;

            // Caixa única dividida horizontalmente
            float hTotais = 35;

            // Vamos dividir em 4 caixas: Base Calculo (vazio), Valor Frete, Prazo, Total Nota
            float wBox = width / 4;

            DesenharCampo("BASE DE CÁLCULO ICMS", "0,00", left, y, wBox, hTotais);

            // FRETE
            DesenharCampo("VALOR DO FRETE", _pedidoParaImprimir.ValorFrete.ToString("C2"), left + wBox, y, wBox, hTotais);

            // PRAZO (Usando campo de 'Outras Despesas' ou similar visualmente)
            DesenharCampo("PRAZO DE ENTREGA", $"{_pedidoParaImprimir.PrazoEntregaDias} DIAS ÚTEIS", left + (wBox * 2), y, wBox, hTotais);

            // TOTAL NOTA
            DesenharCampo("VALOR TOTAL DO PEDIDO", _pedidoParaImprimir.TotalGeral.ToString("C2"), left + (wBox * 3), y, wBox, hTotais, true);

            y += hTotais + 20;

            // =========================================================
            // 5. DADOS ADICIONAIS / RODAPÉ
            // =========================================================
            g.FillRectangle(Brushes.LightGray, left, y, width, 15);
            g.DrawRectangle(canetaFina, left, y, width, 15);
            g.DrawString("DADOS ADICIONAIS", fontConteudoBold, pincel, left + 5, y + 2);
            y += 15;

            string observacoes = "Documento gerado automaticamente pelo Sistema Crimson Suit.\n" +
                                 "Este documento não possui valor fiscal, servindo apenas para conferência e solicitação de compra.";

            g.DrawRectangle(canetaFina, left, y, width, 60);
            g.DrawString("INFORMAÇÕES COMPLEMENTARES", fontLabel, Brushes.Gray, left + 2, y + 2);
            g.DrawString(observacoes, fontConteudo, pincel, new RectangleF(left + 2, y + 15, width - 4, 45));

        }
    }
}