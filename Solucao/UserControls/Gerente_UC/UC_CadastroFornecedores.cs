using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Projeto_FinalOficial
{
    public partial class UC_CadastroFornecedores : UserControl
    {
        // =========================================================
        // CLASSE INTERNA AUXILIAR
        // ==================================z=======================
        private class ItemComboCategoria
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public override string ToString()
            {
                return Nome;
            }
        }

        private CadastroFornecedor _service = new CadastroFornecedor();

        public UC_CadastroFornecedores()
        {
            InitializeComponent();
        }

        // =========================================================
        // 1. CARREGAMENTO INICIAL
        // =========================================================
        private void UC_CadastroFornecedores_Load_1(object sender, EventArgs e)
        {
            CarregarCategorias();
            ConfigurarGridProdutos();
            ConfigurarEstiloGrid();
        }

        private void ConfigurarGridProdutos()
        {
            dgv_Produtos.AutoGenerateColumns = false; // Importante: Vamos controlar o que aparece
            dgv_Produtos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Produtos.RowHeadersVisible = false;
            dgv_Produtos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Produtos.AllowUserToAddRows = false;

            dgv_Produtos.Columns.Clear();

            // 1. Coluna de Checkbox (Manual)
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.HeaderText = "Sel.";
            colCheck.Name = "colCheck";
            colCheck.Width = 40;
            dgv_Produtos.Columns.Add(colCheck);

            // OBS: NÃO criamos a coluna de Preço aqui. Ela virá do Banco.

            // 2. Coluna de Valor do Frete (Manual - Calculada)
            DataGridViewTextBoxColumn colFrete = new DataGridViewTextBoxColumn();
            colFrete.HeaderText = "Frete (R$)";
            colFrete.Name = "ValorFrete";
            colFrete.DefaultCellStyle.Format = "N2";
            colFrete.ReadOnly = true;
            dgv_Produtos.Columns.Add(colFrete);

            // 3. Coluna de Prazo (Manual - Calculada)
            DataGridViewTextBoxColumn colPrazo = new DataGridViewTextBoxColumn();
            colPrazo.HeaderText = "Prazo (Dias)";
            colPrazo.Name = "PrazoEntrega";
            colPrazo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPrazo.ReadOnly = true;
            dgv_Produtos.Columns.Add(colPrazo);
        }

        private void CarregarCategorias()
        {
            try
            {
                DataTable dt = _service.ListarCategorias();
                clb_Categorias.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    clb_Categorias.Items.Add(new ItemComboCategoria
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nome = row["Nome"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
        }

        // =========================================================
        // 2. LÓGICA DE FILTRO E ATUALIZAÇÃO DO GRID
        // =========================================================
        private void clb_Categorias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (string.IsNullOrWhiteSpace(txt_NomeFantasia.Text) ||
                    string.IsNullOrWhiteSpace(txt_Cnpj.Text) ||
                    string.IsNullOrWhiteSpace(txt_CEP.Text))
                {
                    e.NewValue = CheckState.Unchecked;
                    MessageBox.Show("Preencha Nome Fantasia, CNPJ e CEP antes de selecionar categorias.");
                    return;
                }
            }

            this.BeginInvoke(new Action(() =>
            {
                AtualizarGridProdutos();
            }));
        }

        private void AtualizarGridProdutos()
        {
            List<string> nomesCategorias = new List<string>();
            foreach (var item in clb_Categorias.CheckedItems)
            {
                ItemComboCategoria cat = (ItemComboCategoria)item;
                nomesCategorias.Add(cat.Nome);
            }

            if (nomesCategorias.Count == 0)
            {
                dgv_Produtos.DataSource = null;
                return;
            }

            try
            {
                // 1. Busca dados do banco
                DataTable dtProdutos = _service.ListarProdutosPorNomesDeCategoria(nomesCategorias);

                // 2. Permite gerar colunas do banco temporariamente para pegarmos os dados
                dgv_Produtos.AutoGenerateColumns = true;
                dgv_Produtos.DataSource = dtProdutos;

                // 3. AGORA FAZEMOS A MÁGICA: Ajustamos a coluna que veio do banco

                // Esconde ID
                if (dgv_Produtos.Columns.Contains("Id"))
                    dgv_Produtos.Columns["Id"].Visible = false;

                // Configura a coluna de Preço que veio do Banco
                // (Assumindo que no banco se chama "ValorCompra" ou "Preco" ou "Valor")
                string nomeColunaPrecoBanco = "";

                if (dgv_Produtos.Columns.Contains("ValorCompra")) nomeColunaPrecoBanco = "ValorCompra";
                else if (dgv_Produtos.Columns.Contains("Preco")) nomeColunaPrecoBanco = "Preco";
                else if (dgv_Produtos.Columns.Contains("Valor")) nomeColunaPrecoBanco = "Valor";

                if (!string.IsNullOrEmpty(nomeColunaPrecoBanco))
                {
                    // AQUI MUDAMOS O CABEÇALHO PARA O USUÁRIO VER BONITO
                    dgv_Produtos.Columns[nomeColunaPrecoBanco].HeaderText = "Preço Custo (R$)";
                    dgv_Produtos.Columns[nomeColunaPrecoBanco].DefaultCellStyle.Format = "N2";
                    dgv_Produtos.Columns[nomeColunaPrecoBanco].Visible = true;

                    // Opcional: Colocar na posição certa (índice 3, depois de Check, Categoria, Sub)
                    dgv_Produtos.Columns[nomeColunaPrecoBanco].DisplayIndex = 3;
                }

                // Organiza visualmente as colunas manuais para ficarem no final ou começo conforme desejado
                if (dgv_Produtos.Columns.Contains("colCheck")) dgv_Produtos.Columns["colCheck"].DisplayIndex = 0;

                // Trava edição (exceto checkbox)
                foreach (DataGridViewColumn col in dgv_Produtos.Columns)
                {
                    if (col.Name != "colCheck") col.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar produtos: " + ex.Message);
            }
        }

        private void ConfigurarEstiloGrid()
        {
            dgv_Produtos.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgv_Produtos.DefaultCellStyle.ForeColor = Color.Black;
            dgv_Produtos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgv_Produtos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_Produtos.ColumnHeadersHeight = 40;
            dgv_Produtos.EnableHeadersVisualStyles = false;
            dgv_Produtos.RowTemplate.Height = 35;
            dgv_Produtos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgv_Produtos.Columns.Contains("colCheck")) dgv_Produtos.Columns["colCheck"].Width = 60;
        }

        // =========================================================
        // 3. GERAÇÃO INTELIGENTE (ALEATÓRIO)
        // =========================================================
        private void btn_Aleatorio_Click(object sender, EventArgs e)
        {
            if (dgv_Produtos.Rows.Count == 0)
            {
                MessageBox.Show("Selecione algumas categorias primeiro.");
                return;
            }

            Random rnd = new Random();

            // 1. Calcula Frete e Prazo ÚNICOS para o fornecedor
            int prazoUnico = rnd.Next(3, 20);
            double valorBase = (rnd.NextDouble() * (80 - 25)) + 25;
            decimal freteUnico = Math.Round((decimal)valorBase, 2);

            // Identifica qual é o nome da coluna de preço no Grid (vinda do banco)
            string nomeColPreco = "";
            if (dgv_Produtos.Columns.Contains("ValorCompra")) nomeColPreco = "ValorCompra";
            else if (dgv_Produtos.Columns.Contains("Preco")) nomeColPreco = "Preco";
            else if (dgv_Produtos.Columns.Contains("Valor")) nomeColPreco = "Valor";

            foreach (DataGridViewRow row in dgv_Produtos.Rows)
            {
                if (row.IsNewRow) continue;

                // --- PREÇO DE CUSTO ---
                string catAtual = row.Cells["Categoria"].Value != null ? row.Cells["Categoria"].Value.ToString() : "";
                string subAtual = "";
                if (dgv_Produtos.Columns.Contains("SubCategoria") && row.Cells["SubCategoria"].Value != null)
                {
                    subAtual = row.Cells["SubCategoria"].Value.ToString();
                }

                decimal precoSugerido = GerarPrecoInteligente(catAtual, subAtual, rnd);

                // Escreve na coluna do banco identificada
                if (!string.IsNullOrEmpty(nomeColPreco))
                {
                    row.Cells[nomeColPreco].Value = precoSugerido;
                }

                // --- FRETE E PRAZO (Colunas Manuais) ---
                if (dgv_Produtos.Columns.Contains("ValorFrete"))
                    row.Cells["ValorFrete"].Value = freteUnico;

                if (dgv_Produtos.Columns.Contains("PrazoEntrega"))
                    row.Cells["PrazoEntrega"].Value = prazoUnico;

                // Marca o Checkbox
                if (dgv_Produtos.Columns.Contains("colCheck"))
                    row.Cells["colCheck"].Value = true;
            }
        }

        private decimal GerarPrecoInteligente(string categoria, string subCategoria, Random random)
        {
            string cat = categoria.ToLower().Trim();
            string sub = subCategoria.ToLower().Trim();

            double min = 10;
            double max = 100;

            if (cat.Contains("acessório") || cat.Contains("acessorio"))
            {
                if (sub.Contains("boné") || sub.Contains("chapeu")) { min = 30.00; max = 69.90; }
                else if (sub.Contains("relógio") || sub.Contains("relogio")) { min = 150.00; max = 700.00; }
                else { min = 20.00; max = 100.00; }
            }
            else if (cat.Contains("roupa") || cat.Contains("vestuário"))
            {
                if (sub.Contains("Camiseta")) { min = 29.90; max = 69.90; }
                else if (sub.Contains("Calças Jeans/Sarja")) { min = 80.00; max = 200.00; }
                else if (sub.Contains("Camisas Sociais")) { min = 150.00; max = 200.00; }
                else if (sub.Contains("Costumes/Ternos")) { min = 300.00; max = 900.00; }
                else { min = 40.00; max = 150.00; }
            }
            else if (cat.Contains("calçado") || cat.Contains("sapato"))
            {
                if (sub.Contains("tênis") || sub.Contains("tenis")) { min = 120.00; max = 600.00; }
                else if (sub.Contains("Sapatos Sociais")) { min = 250.00; max = 600.00; }
                else { min = 80.00; max = 300.00; }
            }

            double valorGerado = (random.NextDouble() * (max - min)) + min;
            return Math.Round((decimal)valorGerado, 2);
        }

        // =========================================================
        // 4. SALVAR
        // =========================================================
        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NomeFantasia.Text) || string.IsNullOrWhiteSpace(txt_Cnpj.Text))
            {
                MessageBox.Show("Preencha Nome Fantasia e CNPJ.");
                return;
            }

            // 1. Mantemos a lista de categorias
            List<int> idsCategorias = new List<int>();
            foreach (var item in clb_Categorias.CheckedItems)
            {
                ItemComboCategoria cat = (ItemComboCategoria)item;
                idsCategorias.Add(cat.Id);
            }

            // 2. CRIAMOS UM DATATABLE EM VEZ DE UMA LISTA
            // Isso permite enviar Preço, Frete e Prazo junto com o ID
            DataTable dtProdutosParaSalvar = new DataTable();
            dtProdutosParaSalvar.Columns.Add("ProdutoId", typeof(int));
            dtProdutosParaSalvar.Columns.Add("PrecoCusto", typeof(decimal));
            dtProdutosParaSalvar.Columns.Add("Frete", typeof(decimal));
            dtProdutosParaSalvar.Columns.Add("Prazo", typeof(int));

            dgv_Produtos.EndEdit();

            // Identifica qual o nome da coluna de preço no seu Grid
            string colPreco = dgv_Produtos.Columns.Contains("ValorCompra") ? "ValorCompra" :
                             (dgv_Produtos.Columns.Contains("Preco") ? "Preco" : "Valor");

            foreach (DataGridViewRow row in dgv_Produtos.Rows)
            {
                if (row.IsNewRow) continue;

                bool isChecked = false;
                if (row.Cells["colCheck"].Value != null)
                    bool.TryParse(row.Cells["colCheck"].Value.ToString(), out isChecked);

                if (isChecked)
                {
                    DataRow dr = dtProdutosParaSalvar.NewRow();
                    // Use o nome da coluna que veio do Banco (geralmente "Id")
                    dr["ProdutoId"] = Convert.ToInt32(row.Cells["Id"].Value);
                    dr["PrecoCusto"] = row.Cells[colPreco].Value != DBNull.Value ? Convert.ToDecimal(row.Cells[colPreco].Value) : 0;
                    dr["Frete"] = row.Cells["ValorFrete"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["ValorFrete"].Value) : 0;
                    dr["Prazo"] = row.Cells["PrazoEntrega"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["PrazoEntrega"].Value) : 0;

                    dtProdutosParaSalvar.Rows.Add(dr);
                }
            }

            try
            {
                if (dtProdutosParaSalvar.Rows.Count == 0)
                {
                    if (MessageBox.Show("Nenhum produto selecionado. Continuar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }

                // 3. AGORA O 12º ARGUMENTO É O DATATABLE
                bool sucesso = _service.SalvarFornecedorCompleto(
                    txt_NomeFantasia.Text,
                    txt_RazãoSocial.Text,
                    txt_Cnpj.Text,
                    txt_Telefone.Text,
                    txt_CEP.Text,
                    txt_Cidade.Text,
                    txt_Estado.Text,
                    txt_Rua.Text,
                    txt_Bairro.Text,
                    txt_Número.Text,
                    idsCategorias,
                    dtProdutosParaSalvar // <--- O erro de conversão morre aqui
                );

                if (sucesso)
                {
                    MessageBox.Show("Fornecedor e Catálogo salvos com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txt_NomeFantasia.Clear();
            txt_RazãoSocial.Clear();
            txt_Cnpj.Clear();
            txt_Telefone.Clear();
            txt_CEP.Clear();
            txt_Cidade.Clear();
            txt_Estado.Clear();
            txt_Rua.Clear();
            txt_Bairro.Clear();
            txt_Número.Clear();

            for (int i = 0; i < clb_Categorias.Items.Count; i++)
            {
                clb_Categorias.SetItemChecked(i, false);
            }

            dgv_Produtos.DataSource = null;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // =========================================================
        // 5. HELPERS DE INTERFACE (CNPJ, TEL, CEP)
        // =========================================================
        private void txt_Cnpj_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Cnpj.Text))
            {
                Random random = new Random();
                string b1 = random.Next(10, 99).ToString();
                string b2 = random.Next(100, 999).ToString();
                string b3 = random.Next(100, 999).ToString();
                string dig = random.Next(10, 99).ToString();
                txt_Cnpj.Text = $"{b1}.{b2}.{b3}/0001-{dig}";
            }
        }

        private void txt_Telefone_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Telefone.Text))
            {
                Random random = new Random();
                string ddd = random.Next(11, 99).ToString();
                string part1 = random.Next(9000, 9999).ToString();
                string part2 = random.Next(1000, 9999).ToString();
                txt_Telefone.Text = $"({ddd}) {part1}-{part2}";
            }
        }

        private async void txt_CEP_Leave(object sender, EventArgs e)
        {
            string cepDigitado = txt_CEP.Text;
            if (string.IsNullOrWhiteSpace(cepDigitado)) return;

            try
            {
                var endereco = await ViaCepService.BuscarEndereco(cepDigitado);

                if (endereco != null)
                {
                    txt_Rua.Text = endereco.logradouro;
                    txt_Bairro.Text = endereco.bairro;
                    txt_Cidade.Text = endereco.localidade;
                    txt_Estado.Text = endereco.uf;
                    txt_Número.Focus();
                }
                else
                {
                    MessageBox.Show("CEP não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message);
            }
        }
    }
}