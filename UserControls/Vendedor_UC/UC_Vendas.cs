using Projeto_FinalOficial.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_Vendas : UserControl
    {
        // =========================================================
        // CONSTANTES DAS COLUNAS
        // =========================================================
        private const string ColNome = "Nome";
        private const string ColCor = "Cor";
        private const string ColValorUnit = "ValorUnitario";
        private const string ColQtd = "Quantidade";
        private const string ColTotalItem = "TotalItem";

        // =========================================================
        // VARIÁVEIS DE ESTADO
        // =========================================================
        private Cliente _clienteParaImpressao = null;
        private decimal _valorTotalVenda = 0;
        private int _idProdutoAtual = 0;
        private int _estoqueAtualDisponivel = 0;
        private ProdutoVariacao _variacaoAtual = null;

        public UC_Vendas()
        {
            InitializeComponent();
        }

        // =========================================================
        // EVENTOS DE INICIALIZAÇÃO
        // =========================================================
        private void UC_Vendas_Load(object sender, EventArgs e)
        {
            // Garante que o painel comece invisível
            if (pn_FechamentoCaixa != null)
            {
                pn_FechamentoCaixa.Visible = false;
            }

            ConfigurarGridCarrinho();
            ConfigurarGridFechamento();

            DefinirTelaCheia(true);
            txt_CodigoProd.Focus();
        }

        private void UC_Vendas_Leave(object sender, EventArgs e)
        {
            DefinirTelaCheia(false);
        }

        private void DefinirTelaCheia(bool ativar)
        {
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.DefinirModoTelaCheia(ativar);
            }
        }

        // =========================================================
        // CONFIGURAÇÃO VISUAL DOS GRIDS
        // =========================================================
        private void ConfigurarGridCarrinho()
        {
            dgv_Carrinho.Columns.Clear();

            var fonteGrande = new Font("Segoe UI", 12F, FontStyle.Regular);
            var fonteCabecalho = new Font("Segoe UI", 12F, FontStyle.Bold);

            dgv_Carrinho.DefaultCellStyle.Font = fonteGrande;
            dgv_Carrinho.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;
            dgv_Carrinho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_Carrinho.RowTemplate.Height = 35;
            dgv_Carrinho.ColumnHeadersHeight = 40;
            dgv_Carrinho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Carrinho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Carrinho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Carrinho.MultiSelect = false;
            dgv_Carrinho.BackgroundColor = Color.White;
            dgv_Carrinho.EnableHeadersVisualStyles = false;

            dgv_Carrinho.Columns.Add(ColNome, "Produto");
            dgv_Carrinho.Columns.Add(ColCor, "Cor");
            dgv_Carrinho.Columns.Add(ColValorUnit, "Valor Unit.");
            dgv_Carrinho.Columns.Add(ColQtd, "Qtd.");
            dgv_Carrinho.Columns.Add(ColTotalItem, "Total");

            dgv_Carrinho.Columns[ColValorUnit].DefaultCellStyle.Format = "N2";
            dgv_Carrinho.Columns[ColTotalItem].DefaultCellStyle.Format = "N2";
            dgv_Carrinho.Columns[ColValorUnit].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Carrinho.Columns[ColTotalItem].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Carrinho.Columns[ColQtd].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ConfigurarGridFechamento()
        {
            var fonteConteudo = new Font("Segoe UI", 12F, FontStyle.Regular);
            var fonteCabecalho = new Font("Segoe UI", 12F, FontStyle.Bold);

            dgv_ListaVendas.DefaultCellStyle.Font = fonteConteudo;
            dgv_ListaVendas.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;

            dgv_ListaVendas.RowTemplate.Height = 35;
            dgv_ListaVendas.ColumnHeadersHeight = 40;
            dgv_ListaVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_ListaVendas.BackgroundColor = Color.White;
            dgv_ListaVendas.EnableHeadersVisualStyles = false;
            dgv_ListaVendas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_ListaVendas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_ListaVendas.RowHeadersVisible = false;
            dgv_ListaVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // =========================================================
        // LÓGICA DE BUSCA DE PRODUTOS
        // =========================================================
        private async void txt_CodigoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string codigo = txt_CodigoProd.Text.Trim();

                if (!string.IsNullOrEmpty(codigo))
                {
                    txt_CodigoProd.Enabled = false;
                    await BuscarEPreencherProduto(codigo);
                    txt_CodigoProd.Enabled = true;
                    txt_CodigoProd.Focus();
                }
            }
        }

        private async Task BuscarEPreencherProduto(string codigo)
        {
            try
            {
                LimparCamposProduto(manterCodigo: true);
                var resultado = await Task.Run(() => RealizarBuscaNoBanco(codigo));

                if (resultado.Pai != null && resultado.Variacao != null)
                {
                    PreencherInterfaceProduto(resultado.Pai, resultado.Variacao);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_CodigoProd.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produto: {ex.Message}");
            }
        }

        private class ResultadoBusca
        {
            public Produtos Pai { get; set; }
            public ProdutoVariacao Variacao { get; set; }
        }

        private ResultadoBusca RealizarBuscaNoBanco(string codigo)
        {
            var variacaoService = new ProdutoVariacao();
            var produtoPaiService = new Produtos();
            ProdutoVariacao variacao = variacaoService.BuscarPorEAN(codigo);
            Produtos pai = null;

            if (variacao != null)
            {
                pai = produtoPaiService.BuscarPorId(variacao.ProdutoId);
            }
            else if (int.TryParse(codigo, out int idInterno))
            {
                pai = produtoPaiService.BuscarPorId(idInterno);
                if (pai != null)
                    variacao = variacaoService.BuscarPorProdutoPai(pai.Id).FirstOrDefault();
            }

            return new ResultadoBusca { Pai = pai, Variacao = variacao };
        }

        private void PreencherInterfaceProduto(Produtos pai, ProdutoVariacao variacao)
        {
            _variacaoAtual = variacao;
            _idProdutoAtual = variacao.Id;
            _estoqueAtualDisponivel = variacao.QtdAtual;

            txt_NomeProd.Text = $"{pai.Nome} ({variacao.Tamanho})";
            txt_CorProd.Text = pai.Cor;

            decimal preco = variacao.ValorVendaAtual > 0 ? variacao.ValorVendaAtual : pai.ValorVendaBase;
            txt_ValorUnitario.Text = preco.ToString("N2");
            num_Quantidade.Value = 1;

            if (pai.FotoCapa != null && pai.FotoCapa.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(pai.FotoCapa))
                    pick_FotoProd.Image = Image.FromStream(ms);
            }
            else
            {
                pick_FotoProd.Image = null;
            }

            num_Quantidade.Focus();
            num_Quantidade.Select(0, num_Quantidade.Value.ToString().Length);
        }

        // =========================================================
        // MANIPULAÇÃO DO CARRINHO
        // =========================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarAdicaoCarrinho(out int qtdDigitada)) return;

            decimal valorUnitario = _variacaoAtual.ValorVendaAtual > 0 ? _variacaoAtual.ValorVendaAtual : decimal.Parse(txt_ValorUnitario.Text);

            var linhaExistente = dgv_Carrinho.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => r.Tag != null && (int)r.Tag == _idProdutoAtual && !r.IsNewRow);

            if (linhaExistente != null)
            {
                int qtdAnterior = Convert.ToInt32(linhaExistente.Cells[ColQtd].Value);
                int novaQtd = qtdAnterior + qtdDigitada;

                if (novaQtd > _estoqueAtualDisponivel)
                {
                    MessageBox.Show($"Estoque total insuficiente! Disponível: {_estoqueAtualDisponivel}");
                    return;
                }

                linhaExistente.Cells[ColQtd].Value = novaQtd;
                linhaExistente.Cells[ColTotalItem].Value = novaQtd * valorUnitario;
            }
            else
            {
                decimal totalItem = qtdDigitada * valorUnitario;
                int index = dgv_Carrinho.Rows.Add(
                    txt_NomeProd.Text,
                    txt_CorProd.Text,
                    valorUnitario,
                    qtdDigitada,
                    totalItem
                );
                dgv_Carrinho.Rows[index].Tag = _idProdutoAtual;
            }

            RecalcularTotalVenda();
            LimparCamposProduto(manterCodigo: false);
            txt_CodigoProd.Focus();
        }

        private bool ValidarAdicaoCarrinho(out int qtdDigitada)
        {
            qtdDigitada = (int)num_Quantidade.Value;
            if (_idProdutoAtual == 0 || _variacaoAtual == null)
            {
                MessageBox.Show("Busque um produto primeiro.");
                txt_CodigoProd.Focus();
                return false;
            }
            if (qtdDigitada <= 0)
            {
                MessageBox.Show("Quantidade inválida.");
                num_Quantidade.Focus();
                return false;
            }
            if (qtdDigitada > _estoqueAtualDisponivel)
            {
                MessageBox.Show($"Estoque insuficiente. Disponível: {_estoqueAtualDisponivel}");
                return false;
            }
            return true;
        }

        private void btn_ExcluirItemCarrinho_Click(object sender, EventArgs e)
        {
            if (dgv_Carrinho.CurrentRow != null && !dgv_Carrinho.CurrentRow.IsNewRow)
            {
                if (MessageBox.Show("Deseja remover este item?", "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgv_Carrinho.Rows.RemoveAt(dgv_Carrinho.CurrentRow.Index);
                    RecalcularTotalVenda();
                }
            }
        }

        private void Btn_AlterarItem_Click(object sender, EventArgs e)
        {
            if (dgv_Carrinho.CurrentRow != null && !dgv_Carrinho.CurrentRow.IsNewRow)
            {
                int novaQtd = (int)num_Quantidade.Value;
                if (novaQtd > 0)
                {
                    var row = dgv_Carrinho.CurrentRow;
                    row.Cells[ColQtd].Value = novaQtd;
                    row.Cells[ColTotalItem].Value = Convert.ToDecimal(row.Cells[ColValorUnit].Value) * novaQtd;
                    RecalcularTotalVenda();
                }
            }
        }

        private void RecalcularTotalVenda()
        {
            _valorTotalVenda = 0;
            foreach (DataGridViewRow row in dgv_Carrinho.Rows)
            {
                if (row.Cells[ColTotalItem].Value != null)
                    _valorTotalVenda += Convert.ToDecimal(row.Cells[ColTotalItem].Value);
            }
            // Atualiza a label da tela de VENDAS
            txt_ValorFinal.Text = _valorTotalVenda.ToString("N2");
        }

        private void LimparCamposProduto(bool manterCodigo)
        {
            if (!manterCodigo) txt_CodigoProd.Clear();
            _idProdutoAtual = 0;
            _variacaoAtual = null;
            _estoqueAtualDisponivel = 0;
            txt_NomeProd.Clear();
            txt_CorProd.Clear();
            txt_ValorUnitario.Clear();
            pick_FotoProd.Image = null;
            num_Quantidade.Value = 0;
        }

        private void btn_LimparCampos_Click(object sender, EventArgs e)
        {
            LimparCamposProduto(manterCodigo: false);
            txt_CodigoProd.Focus();
        }

        // =========================================================
        // FINALIZAÇÃO DE VENDA
        // =========================================================
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
                    if (row.IsNewRow || row.Cells[ColNome].Value == null) continue;
                    listaDeItens.Add(new ItemVenda
                    {
                        IdProduto = row.Tag != null ? Convert.ToInt32(row.Tag) : 0,
                        NomeProduto = row.Cells[ColNome].Value.ToString(),
                        Cor = row.Cells[ColCor].Value?.ToString() ?? "",
                        ValorUnitario = Convert.ToDecimal(row.Cells[ColValorUnit].Value),
                        Quantidade = Convert.ToInt32(row.Cells[ColQtd].Value)
                    });
                }

                var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
                if (formPrincipal != null)
                    formPrincipal.RenderizarControl(new UC_Pagamento(_valorTotalVenda, listaDeItens, _clienteParaImpressao));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar itens: " + ex.Message);
            }
        }

        // =========================================================
        // CLIENTES
        // =========================================================
        private async void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            string termo = txt_BuscaCliente.Text.Trim();
            if (string.IsNullOrEmpty(termo)) return;

            try
            {
                var clienteService = new Cliente();
                var resultado = await Task.Run(() => clienteService.BuscarPorNomeOuCPF(termo) as Cliente);

                if (resultado != null && resultado.Id > 0)
                {
                    _clienteParaImpressao = resultado;
                    MessageBox.Show($"Cliente: {resultado.Nome}");
                }
                else
                {
                    _clienteParaImpressao = null;
                    MessageBox.Show("Cliente não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btn_CadastraCLiente_Click(object sender, EventArgs e)
        {
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null) formPrincipal.RenderizarControl(new CadastroCliente());
        }

        // =========================================================
        // FECHAMENTO DE CAIXA (LÓGICA FINAL)
        // =========================================================

        // 1. AÇÃO DO BOTÃO "FECHAR CAIXA" DA BARRA SUPERIOR
        private void btn_FecharCaixa_Click(object sender, EventArgs e)
        {
            if (Sessao.IDCaixaAtual == 0)
            {
                MessageBox.Show("Não há caixa aberto para fechar.");
                return;
            }

            try
            {
                FluxoCaixa model = new FluxoCaixa();
                var resumo = model.ObterResumoFechamento(Sessao.IDCaixaAtual);
                DataTable historico = model.ObterVendasDoCaixa(Sessao.IDCaixaAtual);

                // Preenche as labels informativas
                lbl_ValorInicial.Text = resumo.valorInicial.ToString("C2");
                lbl_TotalVendido.Text = resumo.totalVendas.ToString("C2");

                // --- ATUALIZADO: Usando lbl_ValorFechamentoCaixa ---
                decimal totalFinal = resumo.valorInicial + resumo.totalVendas;
                lbl_ValorFechamentoCaixa.Text = totalFinal.ToString("C2");
                // ---------------------------------------------------

                dgv_ListaVendas.DataSource = historico;

                lbl_Letreiro.Text = "Fechamento de Caixa";

                pn_FechamentoCaixa.Visible = true;
                pn_FechamentoCaixa.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar fechamento: " + ex.Message);
            }
        }

        // 2. AÇÃO DO BOTÃO VERDE "CONFIRMAR FECHAMENTO" (No Painel)
        private void btn_ConfirmarFechamento_Click(object sender, EventArgs e)
        {
            // Abre o Pop-up Modal e aguarda sucesso
            SolicitarAutorizacaoGerente((nomeGerente) =>
            {
                // Se chegou aqui, a senha estava correta
                FinalizarFechamentoCaixaNoBanco(nomeGerente);
            });
        }

        // --- MÉTODO POP-UP MODAL ---
        private void SolicitarAutorizacaoGerente(Action<string> acaoSeAutorizado)
        {
            using (Form formPopup = new Form())
            {
                formPopup.Text = "Autorização do Gerente";
                formPopup.StartPosition = FormStartPosition.CenterParent;
                formPopup.Size = new Size(652, 367);
                formPopup.FormBorderStyle = FormBorderStyle.None;
                formPopup.BackColor = Color.DimGray;
                formPopup.Padding = new Padding(1);

                UC_ValidacaoGerente ucValidacao = new UC_ValidacaoGerente(
                    acaoAposLiberacao: (nome) =>
                    {
                        formPopup.DialogResult = DialogResult.OK;
                        formPopup.Close();
                        acaoSeAutorizado(nome);
                    },
                    acaoCancelar: () =>
                    {
                        formPopup.DialogResult = DialogResult.Cancel;
                        formPopup.Close();
                    }
                );

                ucValidacao.Dock = DockStyle.Fill;
                formPopup.Controls.Add(ucValidacao);
                formPopup.ShowDialog(this);
            }
        }

        // 3. SALVAR NO BANCO
        private void FinalizarFechamentoCaixaNoBanco(string nomeGerente)
        {
            try
            {
                FluxoCaixa model = new FluxoCaixa();

                // --- ATUALIZADO: Lendo de lbl_ValorFechamentoCaixa ---
                string valorTexto = lbl_ValorFechamentoCaixa.Text;
                string valorLimpo = valorTexto.Replace("R$", "").Replace(" ", "").Trim();

                decimal valorFinal = 0;
                // Tenta converter. Se falhar (vazio ou erro), recalcula na mão.
                if (!decimal.TryParse(valorLimpo, out valorFinal))
                {
                    var resumo = model.ObterResumoFechamento(Sessao.IDCaixaAtual);
                    valorFinal = resumo.valorInicial + resumo.totalVendas;
                }

                bool sucesso = model.FecharCaixa(Sessao.IDCaixaAtual, valorFinal, nomeGerente);

                if (sucesso)
                {
                    MessageBox.Show($"Caixa fechado com sucesso!\nGerente: {nomeGerente}\nValor Final: {valorFinal:C2}", "Sucesso");
                    Sessao.IDCaixaAtual = 0;
                    pn_FechamentoCaixa.Visible = false;

                    lbl_Letreiro.Text = "Caixa Livre";
                }
                else
                {
                    MessageBox.Show("Erro ao fechar o caixa no banco de dados.", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro técnico ao fechar caixa: " + ex.Message);
            }
        }

        // 4. AÇÃO DO BOTÃO VERMELHO "CANCELAR" (No Painel)
        private void btn_CancelarFechamento_Click(object sender, EventArgs e)
        {
            pn_FechamentoCaixa.Visible = false;
            lbl_Letreiro.Text = "Caixa Livre";
        }

        private void txt_ValorFinal_TextChanged(object sender, EventArgs e) { }
    }
}