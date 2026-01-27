using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Projeto_FinalOficial.Modelos; // Certifique-se que o Cliente está aqui ou no namespace principal

namespace Projeto_FinalOficial
{
    public partial class UC_Vendas : UserControl
    {
        public UC_Vendas()
        {
            InitializeComponent();
        }

        private Cliente _clienteParaImpressao = null;
        private decimal _valorTotalVenda = 0;
        private int _idProdutoAtual = 0;
        private int _estoqueAtualDisponivel = 0;
        private ProdutoVariacao _variacaoAtual = null;

        private void UC_Vendas_Load(object sender, EventArgs e)
        {
            CarregarDataGridView();

            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.DefinirModoTelaCheia(true);
            }

            // Foco inicial no código de barras
            txt_CodigoProd.Focus();
        }


        private void UC_Vendas_Leave(object sender, EventArgs e)
        {
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.DefinirModoTelaCheia(false);
            }
        }

        
        private void CarregarDataGridView()
        {
            // Limpa as colunas anteriores
            dgv_Carrinho.Columns.Clear();

            // =========================================================
            // CONFIGURAÇÃO DE ESTILO E FONTE (MUDANÇAS AQUI)
            // =========================================================

            // 1. Define uma fonte maior (Tamanho 12 ou 14 fica bom para PDV)
            // "Segoe UI" é a fonte padrão moderna do Windows. Pode usar "Arial" se preferir.
            System.Drawing.Font fonteGrande = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            System.Drawing.Font fonteCabecalho = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // 2. Aplica a fonte nas células de dados
            dgv_Carrinho.DefaultCellStyle.Font = fonteGrande;

            // 3. Aplica a fonte no cabeçalho (Títulos das colunas)
            dgv_Carrinho.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;
            dgv_Carrinho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centraliza título

            // 4. AUMENTA A ALTURA DAS LINHAS (Essencial quando se aumenta a fonte)
            dgv_Carrinho.RowTemplate.Height = 35; // Altura da linha de dados (padrão é 22)
            dgv_Carrinho.ColumnHeadersHeight = 40; // Altura do cabeçalho
            dgv_Carrinho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // Trava altura

            // 5. Configurações visuais extras para facilitar leitura
            dgv_Carrinho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Colunas ocupam todo espaço
            dgv_Carrinho.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleciona a linha inteira ao clicar
            dgv_Carrinho.MultiSelect = false; // Evita selecionar várias linhas
            dgv_Carrinho.BackgroundColor = System.Drawing.Color.White; // Fundo branco limpo
            dgv_Carrinho.EnableHeadersVisualStyles = false; // Permite customizar cor do cabeçalho se quiser depois

            // =========================================================
            // ADIÇÃO DAS COLUNAS (SEU CÓDIGO ORIGINAL)
            // =========================================================
            dgv_Carrinho.Columns.Add("Nome", "Produto");
            dgv_Carrinho.Columns.Add("Cor", "Cor");
            dgv_Carrinho.Columns.Add("ValorUnitario", "Valor Unit.");
            dgv_Carrinho.Columns.Add("Quantidade", "Qtd.");
            dgv_Carrinho.Columns.Add("TotalItem", "Total");

            // Formatação de moeda
            dgv_Carrinho.Columns["ValorUnitario"].DefaultCellStyle.Format = "N2";
            dgv_Carrinho.Columns["TotalItem"].DefaultCellStyle.Format = "N2";

            // Alinhamento dos números à direita (padrão contábil)
            dgv_Carrinho.Columns["ValorUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Carrinho.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Carrinho.Columns["TotalItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // =========================================================
        // CORREÇÃO PRINCIPAL: LÓGICA DE BUSCA E NOMES DAS VARIÁVEIS
        // =========================================================
        private void PreencherDadosDoProduto(string codigo)
        {
            try
            {
                // Instancia os serviços
                ProdutoVariacao variacaoService = new ProdutoVariacao();
                Produtos produtoPaiService = new Produtos();

                // VARIÁVEIS PARA ARMAZENAR O RESULTADO
                ProdutoVariacao variacaoEncontrada = null;
                Produtos produtoPai = null;

                // ==========================================================
                // TENTATIVA 1: BUSCAR POR CÓDIGO DE BARRAS (EAN) NA VARIAÇÃO
                // ==========================================================
                // É o cenário mais comum: ler o código de barras do produto específico (ex: Camiseta P)
                variacaoEncontrada = variacaoService.BuscarPorEAN(codigo);

                if (variacaoEncontrada != null)
                {
                    // Se achou a variação, busca os dados do Pai (Nome, Foto, etc) usando o ID de vínculo
                    produtoPai = produtoPaiService.BuscarPorId(variacaoEncontrada.ProdutoId);
                }
                else
                {
                    // ==========================================================
                    // TENTATIVA 2: BUSCAR PELO ID INTERNO (Fallback)
                    // ==========================================================
                    // Caso o usuário tenha digitado o código interno do sistema manualmente
                    if (int.TryParse(codigo, out int idInterno))
                    {
                        // Aqui tentamos achar direto o pai, mas ATENÇÃO:
                        // Vender pelo Pai sem definir tamanho pode dar erro de estoque depois.
                        // O ideal é forçar a busca da variação, mas mantive para compatibilidade.
                        produtoPai = produtoPaiService.BuscarPorId(idInterno);

                        if (produtoPai != null)
                        {
                            // Tenta pegar a primeira variação disponível para ter um preço/estoque
                            var listaVariacoes = variacaoService.BuscarPorProdutoPai(produtoPai.Id);
                            if (listaVariacoes.Count > 0)
                            {
                                variacaoEncontrada = listaVariacoes[0]; // Pega a primeira como padrão
                            }
                        }
                    }
                }

                // ==========================================================
                // PREENCHER A TELA
                // ==========================================================
                if (produtoPai != null && variacaoEncontrada != null)
                {
                    // O ID que vai para o carrinho deve ser o da VARIAÇÃO para baixar estoque corretamente
                    _idProdutoAtual = variacaoEncontrada.Id;
                    _variacaoAtual = variacaoEncontrada;
                    _estoqueAtualDisponivel = variacaoEncontrada.QtdAtual;

                    // Monta o nome: Nome do Pai + Tamanho da Variação
                    txt_NomeProd.Text = $"{produtoPai.Nome} ({variacaoEncontrada.Tamanho})";
                    txt_CorProd.Text = produtoPai.Cor;

                    // PREÇO: Prioridade para o preço da Variação, se for 0 usa o do Pai
                    decimal valorFinal = variacaoEncontrada.ValorVendaAtual > 0
                                         ? variacaoEncontrada.ValorVendaAtual
                                         : produtoPai.ValorVendaBase;

                    txt_ValorUnitario.Text = valorFinal.ToString("N2");
                    num_Quantidade.Value = 1;

                    // FOTO: A foto fica no Pai
                    if (produtoPai.FotoCapa != null && produtoPai.FotoCapa.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(produtoPai.FotoCapa))
                        {
                            pick_FotoProd.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pick_FotoProd.Image = null;
                    }

                    // Focar na quantidade
                    num_Quantidade.Focus();
                    num_Quantidade.Select(0, num_Quantidade.Value.ToString().Length);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado pelo código informado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimparCampos();
                    txt_CodigoProd.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            _idProdutoAtual = 0;
            txt_NomeProd.Clear();
            txt_CorProd.Clear();
            txt_ValorUnitario.Clear();
            pick_FotoProd.Image = null;
            num_Quantidade.Value = 0;
        }

        private void txt_CodigoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string codigo = txt_CodigoProd.Text.Trim();

                if (!string.IsNullOrEmpty(codigo))
                {
                    PreencherDadosDoProduto(codigo);
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // 1. Validação: Verifica se tem produto carregado na memória
            if (_idProdutoAtual == 0 || _variacaoAtual == null)
            {
                MessageBox.Show("Por favor, busque e selecione um produto primeiro.");
                txt_CodigoProd.Focus();
                return;
            }

            // 2. Validação: Quantidade
            int qtdDigitada = (int)num_Quantidade.Value;

            if (qtdDigitada <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.");
                return;
            }

            // 3. Validação: Estoque (Opcional, mas recomendado)
            if (qtdDigitada > _estoqueAtualDisponivel)
            {
                MessageBox.Show($"Estoque insuficiente! Disponível: {_estoqueAtualDisponivel}");
                return;
            }

            // =======================================================================
            // LÓGICA DE AGRUPAMENTO VISUAL (Direto no DataGridView)
            // =======================================================================

            bool produtoJaEstavaNoGrid = false;

            // Varre as linhas do Grid para ver se o produto já está lá
            foreach (DataGridViewRow row in dgv_Carrinho.Rows)
            {
                // Pula linha nova em branco
                if (row.IsNewRow) continue;

                // Verifica se a linha tem o ID (Tag) igual ao produto atual
                if (row.Tag != null && Convert.ToInt32(row.Tag) == _idProdutoAtual)
                {
                    // === CENÁRIO A: ENCONTROU O PRODUTO ===

                    // 1. Pega a quantidade que já estava lá
                    int qtdAnterior = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    // 2. Soma com a nova
                    int novaQtdTotal = qtdAnterior + qtdDigitada;

                    // 3. Atualiza a célula de Quantidade
                    row.Cells["Quantidade"].Value = novaQtdTotal;

                    // 4. Atualiza a célula de Total (Preço x Nova Quantidade)
                    decimal valorUnit = Convert.ToDecimal(row.Cells["ValorUnitario"].Value);
                    row.Cells["TotalItem"].Value = novaQtdTotal * valorUnit;

                    produtoJaEstavaNoGrid = true;
                    break; // Para o loop, já achamos e atualizamos
                }
            }

            if (!produtoJaEstavaNoGrid)
            {
                // === CENÁRIO B: NÃO ESTAVA LÁ, ADICIONA NOVO ===

                decimal totalItem = qtdDigitada * _variacaoAtual.ValorVendaAtual;

                // Adiciona a linha visualmente
                int index = dgv_Carrinho.Rows.Add(
                    txt_NomeProd.Text,                    // Nome
                    txt_CorProd.Text,                     // Cor
                    _variacaoAtual.ValorVendaAtual,       // Valor Unitario
                    qtdDigitada,                          // Quantidade
                    totalItem                             // Total
                );

                // O PULO DO GATO: Guardar o ID escondido na propriedade Tag da linha
                dgv_Carrinho.Rows[index].Tag = _idProdutoAtual;
            }

            // 4. Recalcula o total final da venda e limpa campos
            RecalcularTotalVenda();
            LimparCamposAposAdicionar();
        }

        private bool CamposEstaoValidos()
        {
            return !string.IsNullOrEmpty(txt_NomeProd.Text) && num_Quantidade.Value > 0;
        }

        private void AtualizarTotalVenda(decimal valorItem)
        {
            _valorTotalVenda += valorItem;
            txt_ValorFinal.Text = _valorTotalVenda.ToString("N2");
        }

        private void LimparCamposAposAdicionar()
        {
            txt_CodigoProd.Clear();
            txt_NomeProd.Clear();
            txt_CorProd.Clear();
            txt_ValorUnitario.Clear();
            num_Quantidade.Value = 0;
            pick_FotoProd.Image = null;

            txt_CodigoProd.Focus();
        }

        private void btn_LimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Correção de nomenclatura (remover underscores extras se desejar, mas mantive para compatibilidade)
        private void txt_ValorFinal_TextChanged(object sender, EventArgs e)
        {
            // Apenas para garantir formatação visual se alguém digitar manual
        }

        private void btn_ExcluirItemCarrinho_Click(object sender, EventArgs e)
        {
            if (dgv_Carrinho.CurrentRow != null && !dgv_Carrinho.CurrentRow.IsNewRow)
            {
                dgv_Carrinho.Rows.RemoveAt(dgv_Carrinho.CurrentRow.Index);
                RecalcularTotalVenda();
            }
        }

        private void Btn_AlterarItem_Click(object sender, EventArgs e)
        {
            if (dgv_Carrinho.CurrentRow != null)
            {
                DataGridViewRow linhaSelecionada = dgv_Carrinho.CurrentRow;
                int novaQuantidade = (int)num_Quantidade.Value;

                if (novaQuantidade > 0)
                {
                    linhaSelecionada.Cells["Quantidade"].Value = novaQuantidade;

                    decimal valorUnitario = Convert.ToDecimal(linhaSelecionada.Cells["ValorUnitario"].Value);
                    decimal novoTotalItem = valorUnitario * novaQuantidade;
                    linhaSelecionada.Cells["TotalItem"].Value = novoTotalItem;

                    RecalcularTotalVenda();
                }
                else
                {
                    MessageBox.Show("Selecione um item no carrinho e defina uma quantidade maior que zero no campo de quantidade.", "Atenção");
                }
            }
        }

        private void RecalcularTotalVenda()
        {
            _valorTotalVenda = 0;
            foreach (DataGridViewRow row in dgv_Carrinho.Rows)
            {
                if (row.Cells["TotalItem"].Value != null)
                {
                    _valorTotalVenda += Convert.ToDecimal(row.Cells["TotalItem"].Value);
                }
            }
            txt_ValorFinal.Text = _valorTotalVenda.ToString("N2");
        }

        private void btn_FinalizarVenda_Click(object sender, EventArgs e)
        {
            if (dgv_Carrinho.Rows.Count == 0 || (dgv_Carrinho.Rows.Count == 1 && dgv_Carrinho.Rows[0].IsNewRow))
            {
                MessageBox.Show("Carrinho vazio!");
                return;
            }

            try
            {
                List<ItemVenda> listaDeItens = new List<ItemVenda>();

                foreach (DataGridViewRow row in dgv_Carrinho.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Nome"].Value == null) continue;

                    ItemVenda item = new ItemVenda();

                    if (row.Tag != null)
                        item.IdProduto = Convert.ToInt32(row.Tag);
                    else
                    {
                        // Se perdeu o ID, tenta recuperar pelo nome (menos seguro, mas fallback)
                        // Idealmente nunca deve entrar aqui se a lógica de adicionar funcionar
                        item.IdProduto = 0;
                    }

                    item.NomeProduto = row.Cells["Nome"].Value.ToString();
                    item.Cor = row.Cells["Cor"].Value != null ? row.Cells["Cor"].Value.ToString() : "";
                    var cellValor = row.Cells["ValorUnitario"].Value;
                    item.ValorUnitario = cellValor != null ? Convert.ToDecimal(cellValor) : 0;
                    item.Quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    listaDeItens.Add(item);
                }

                var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
                if (formPrincipal != null)
                {
                    formPrincipal.RenderizarControl(new UC_Pagamento(_valorTotalVenda, listaDeItens, _clienteParaImpressao));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar itens: " + ex.Message);
            }
        }

        private void btn_CadastraCLiente_Click(object sender, EventArgs e)
        {
            CadastroCliente telaCadastroCliente = new CadastroCliente();
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.RenderizarControl(telaCadastroCliente);
            }
        }

        private void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            string termoDigitado = txt_BuscaCliente.Text.Trim();

            if (string.IsNullOrEmpty(termoDigitado))
            {
                MessageBox.Show("Por favor, digite um Nome ou CPF.");
                return;
            }

            try
            {
                Cliente clienteService = new Cliente();

                // Realiza a busca
                var resultadoObj = clienteService.BuscarPorNomeOuCPF(termoDigitado);

                // Converte (Cast) para Cliente
                Cliente resultado = resultadoObj as Cliente;

                if (resultado != null && resultado.Id > 0)
                {
                    _clienteParaImpressao = resultado;
                    MessageBox.Show($"Cliente selecionado: {resultado.Nome}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _clienteParaImpressao = null;
                    MessageBox.Show("Nenhum cliente encontrado.");
                    txt_BuscaCliente.SelectAll();
                    txt_BuscaCliente.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}