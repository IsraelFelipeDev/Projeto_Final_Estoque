using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Projeto_FinalOficial.ProdutoVariacao;

namespace Projeto_FinalOficial
{
    public partial class UC_EstoqueGeral : UserControl
    {
        private DataTable _dtEstoqueCompleto;
        private DataView _dvEstoqueFiltrado;

        public UC_EstoqueGeral()
        {
            InitializeComponent();
        }

        private void UC_EstoqueGeral_Load(object sender, EventArgs e)
        {
            try
            {
                // Configura as colunas manualmente para garantir os nomes (Name)
                ConfigurarGrid();

                // Configura os eventos dos filtros e checkboxes
                ConfigurarEventosFiltro();

                // Busca os dados no banco
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro crítico ao iniciar a tela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // CONFIGURAÇÃO DO GRID
        // ====================================================================
        // ====================================================================
        // CONFIGURAÇÃO DO GRID (VISUAL AJUSTADO)
        // ====================================================================
        private void ConfigurarGrid()
        {
            try
            {
                dgv_Estoque.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgv_Estoque.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv_Estoque.RowTemplate.Height = 30;
                dgv_Estoque.AllowUserToAddRows = false;
                dgv_Estoque.RowHeadersVisible = false;
                dgv_Estoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Mantemos o Fill para preencher a tela toda
                dgv_Estoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv_Estoque.AutoGenerateColumns = false;
                dgv_Estoque.Columns.Clear();

                // Adicionamos as colunas
                AdicionarColuna("Descricao", "Produto", 100);
                AdicionarColuna("CodigoBarrasEAN", "EAN", 80);
                AdicionarColuna("Categoria", "Categoria", 80);
                AdicionarColuna("SubCategoria", "SubCategoria", 80);
                AdicionarColuna("Tamanho", "Tam.", 40);
                AdicionarColuna("Cor", "Cor", 50);
                AdicionarColunaNumerica("QtdMin", "Min");
                AdicionarColunaNumerica("QtdMax", "Max");
                AdicionarColunaNumerica("QtdAtual", "Atual");

                var colId = new DataGridViewTextBoxColumn();
                colId.DataPropertyName = "IdVariacao";
                colId.Name = "IdVariacao";
                colId.Visible = false;
                dgv_Estoque.Columns.Add(colId);

                // =========================================================
                // AJUSTE FINO DAS LARGURAS (AQUI ESTÁ A MÁGICA)
                // =========================================================
                // O FillWeight define a % que cada coluna ocupa na tela.

                // Produto: Ganha a maior fatia (40% do espaço)
                dgv_Estoque.Columns["Descricao"].FillWeight = 280;

                // EAN: Ganha um destaque médio (15% do espaço)
                dgv_Estoque.Columns["CodigoBarrasEAN"].FillWeight = 225;

                // Categoria e Sub: Tamanho médio (12% cada)
                dgv_Estoque.Columns["Categoria"].FillWeight = 120;
                dgv_Estoque.Columns["SubCategoria"].FillWeight = 120;

                // As colunas pequenas (Tam, Cor, Qtds) ficam espremidas
                // para sobrar espaço para o nome.
                dgv_Estoque.Columns["Tamanho"].FillWeight = 60;
                dgv_Estoque.Columns["Cor"].FillWeight = 70;
                dgv_Estoque.Columns["QtdMin"].FillWeight = 35;
                dgv_Estoque.Columns["QtdMax"].FillWeight = 35;
                dgv_Estoque.Columns["QtdAtual"].FillWeight = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar as colunas do Grid: " + ex.Message);
            }
        }

        private void AdicionarColuna(string campo, string titulo, int largura)
        {
            var col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = campo; // Liga ao Banco
            col.Name = campo;             // Liga ao Código C# (Importante para o erro que deu)
            col.HeaderText = titulo;
            col.MinimumWidth = largura;
            dgv_Estoque.Columns.Add(col);
        }

        private void AdicionarColunaNumerica(string campo, string titulo)
        {
            var col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = campo;
            col.Name = campo;             // Fundamental para o ColorirGrid achar a coluna
            col.HeaderText = titulo;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Estoque.Columns.Add(col);
        }

        // ====================================================================
        // CARREGAR DADOS (BLINDADO)
        // ====================================================================
        private void CarregarDados()
        {
            try
            {
                Produtos produtoService = new Produtos();
                _dtEstoqueCompleto = produtoService.ListarEstoqueGeral();

                if (_dtEstoqueCompleto == null || _dtEstoqueCompleto.Rows.Count == 0)
                {
                    // Não é erro, mas avisa para debug
                    // MessageBox.Show("A consulta ao banco não retornou nenhum registro.");
                }

                FiltrarEstoque();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar dados no banco: {ex.Message}\nVerifique a conexão ou a View SQL.", "Erro Banco de Dados");
            }
        }

        // ====================================================================
        // FILTROS (BLINDADO)
        // ====================================================================
        private void ConfigurarEventosFiltro()
        {
            try
            {
                if (txt_DescriçãoProd != null)
                    txt_DescriçãoProd.TextChanged += (s, e) => FiltrarEstoque();

                // Tratamento do AirCheckBox com delegate genérico
                if (chk_Critico != null) chk_Critico.CheckedChanged += delegate { FiltrarEstoque(); };
                if (chk_Ideal != null) chk_Ideal.CheckedChanged += delegate { FiltrarEstoque(); };
                if (chk_Acima != null) chk_Acima.CheckedChanged += delegate { FiltrarEstoque(); };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar eventos de filtro: " + ex.Message);
            }
        }

        private void FiltrarEstoque()
        {
            try
            {
                if (_dtEstoqueCompleto == null) return;

                _dvEstoqueFiltrado = _dtEstoqueCompleto.DefaultView;
                List<string> filtrosGerais = new List<string>();

                // Filtro Texto
                if (txt_DescriçãoProd != null && !string.IsNullOrWhiteSpace(txt_DescriçãoProd.Text))
                {
                    // Try-Catch previne erro de sintaxe SQL no filtro
                    filtrosGerais.Add($"Descricao LIKE '%{txt_DescriçãoProd.Text.Replace("'", "''")}%'");
                }

                // Filtro Checkbox
                List<string> filtrosStatus = new List<string>();
                if (chk_Critico != null && chk_Critico.Checked) filtrosStatus.Add("(QtdAtual <= QtdMin)");
                if (chk_Ideal != null && chk_Ideal.Checked) filtrosStatus.Add("(QtdAtual > QtdMin AND QtdAtual <= QtdMax)");
                if (chk_Acima != null && chk_Acima.Checked) filtrosStatus.Add("(QtdAtual > QtdMax)");

                if (filtrosStatus.Count > 0)
                {
                    string statusCombinado = "(" + string.Join(" OR ", filtrosStatus) + ")";
                    filtrosGerais.Add(statusCombinado);
                }

                // Aplica Filtro
                if (filtrosGerais.Count > 0)
                    _dvEstoqueFiltrado.RowFilter = string.Join(" AND ", filtrosGerais);
                else
                    _dvEstoqueFiltrado.RowFilter = "";

                dgv_Estoque.DataSource = _dvEstoqueFiltrado;

                // Atualizações visuais seguras
                ColorirGrid();
                AtualizarTotaisLabels();
            }
            catch (Exception ex)
            {
                // Evita crash se o usuário digitar caracteres inválidos no filtro
                System.Diagnostics.Debug.WriteLine("Erro ao filtrar: " + ex.Message);
            }
        }

        // ====================================================================
        // VISUAL / CORES (ONDE DEU O ERRO DA FOTO)
        // ====================================================================
        private void ColorirGrid()
        {
            // Proteção 1: Se não tem colunas, sai fora para não dar erro
            if (dgv_Estoque.Columns.Count == 0) return;

            // Proteção 2: Verifica se as colunas necessárias existem
            if (!dgv_Estoque.Columns.Contains("QtdAtual") ||
                !dgv_Estoque.Columns.Contains("QtdMin") ||
                !dgv_Estoque.Columns.Contains("QtdMax"))
            {
                // Se cair aqui, é porque o ConfigurarGrid não rodou direito ou AutoGenerate mudou os nomes
                return;
            }

            try
            {
                foreach (DataGridViewRow row in dgv_Estoque.Rows)
                {
                    // Pega os valores com verificação de nulo (DBNull)
                    object objAtual = row.Cells["QtdAtual"].Value;
                    object objMin = row.Cells["QtdMin"].Value;
                    object objMax = row.Cells["QtdMax"].Value;

                    if (objAtual != DBNull.Value && objMin != DBNull.Value && objMax != DBNull.Value)
                    {
                        // Conversão segura
                        int qtd = Convert.ToInt32(objAtual);
                        int min = Convert.ToInt32(objMin);
                        int max = Convert.ToInt32(objMax);

                        if (qtd <= min) // Crítico
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        }
                        else if (qtd > max) // Acima
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230);
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        }
                        else // Ideal
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235);
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Não usamos MessageBox aqui dentro, pois está num loop e travaria o PC
                System.Diagnostics.Debug.WriteLine("Erro ao Colorir Grid: " + ex.Message);
            }
        }

        // ====================================================================
        // TOTAIS / LABELS (BLINDADO)
        // ====================================================================
        private void AtualizarTotaisLabels()
        {
            try
            {
                // Se não tiver dados filtrados, zera tudo e sai
                if (_dvEstoqueFiltrado == null) return;

                int totalGeral = _dvEstoqueFiltrado.Count;
                int contNegativos = 0;
                int contIdeal = 0;
                int contAcima = 0;

                foreach (DataRowView rowView in _dvEstoqueFiltrado)
                {
                    DataRow row = rowView.Row;

                    // Proteção contra nulos na hora de somar
                    int qtd = (row["QtdAtual"] != DBNull.Value) ? Convert.ToInt32(row["QtdAtual"]) : 0;
                    int min = (row["QtdMin"] != DBNull.Value) ? Convert.ToInt32(row["QtdMin"]) : 0;
                    int max = (row["QtdMax"] != DBNull.Value) ? Convert.ToInt32(row["QtdMax"]) : 0;

                    if (qtd <= min) contNegativos++;
                    else if (qtd > max) contAcima++;
                    else contIdeal++;
                }

                // Atualiza Labels com verificação de nulidade (caso delete o label da tela sem querer)
                if (lbl_TotalRegistros != null) lbl_TotalRegistros.Text = totalGeral.ToString();
                if (lbl_Negativos != null) lbl_Negativos.Text = contNegativos.ToString();
                if (lbl_Ideal != null) lbl_Ideal.Text = contIdeal.ToString();
                if (lbl_Acima != null) lbl_Acima.Text = contAcima.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular totais: " + ex.Message);
            }
        }

        private void btn_FazerPedido_Click(object sender, EventArgs e)
        {

            try
            {
                // Lista que vamos enviar para a outra tela
                List<ItemPedidoTransfer> listaParaPedido = new List<ItemPedidoTransfer>();

                // Percorre todas as linhas do Grid (que já respeita os filtros atuais da tela)
                foreach (DataGridViewRow row in dgv_Estoque.Rows)
                {
                    // Pega os valores
                    int atual = Convert.ToInt32(row.Cells["QtdAtual"].Value);
                    int min = Convert.ToInt32(row.Cells["QtdMin"].Value);
                    int max = Convert.ToInt32(row.Cells["QtdMax"].Value);

                    // LÓGICA: Se estiver abaixo ou igual ao mínimo
                    if (atual <= min)
                    {
                        // Calcula quanto falta para chegar no máximo (Sugestão de compra)
                        int sugestaoCompra = max - atual;
                        if (sugestaoCompra <= 0) sugestaoCompra = min; // Segurança

                        listaParaPedido.Add(new ItemPedidoTransfer
                        {
                            IdVariacao = Convert.ToInt32(row.Cells["IdVariacao"].Value),
                            NomeProduto = row.Cells["Descricao"].Value.ToString() + " - " + row.Cells["Tamanho"].Value.ToString(),
                            QtdSugestao = sugestaoCompra
                        });
                    }
                }

                if (listaParaPedido.Count == 0)
                {
                    MessageBox.Show("Nenhum item abaixo do estoque mínimo encontrado na lista atual.", "Tudo Certo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Navegação para a tela de Pedido passando a lista
                // Nota: Precisamos pegar a instância do Form Principal para navegar
                Principla formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
                if (formPrincipal != null)
                {
                    // Chama o novo construtor que criamos no Passo 2
                    formPrincipal.RenderizarControl(new UC_FazerPedido(listaParaPedido));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar pedido: " + ex.Message);
            }
        }
        // ====================================================================
        // MÉTODO QUE FALTAVA (Cole isto dentro da classe UC_EstoqueGeral)
        // ====================================================================
        private void AtualizarNoBanco(int id, int min, int max, int atual)
        {
            try
            {
                // 1. Instancia sua classe de produtos (que tem a conexão)
                Produtos produtoService = new Produtos();

                // 2. Chama o método SQL que criamos na classe Produtos.cs
                produtoService.AtualizarQuantidadesEstoque(id, min, max, atual);

                // Feedback opcional (se quiser que avise, descomente a linha abaixo)
                // MessageBox.Show("Estoque atualizado com sucesso!", "Sucesso");
            }
            catch (Exception ex)
            {
                // Se der erro no banco, avisa e para tudo
                MessageBox.Show($"Erro ao salvar no banco: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btn_AlterarItem_Click(object sender, EventArgs e)
        {
         
            // 1. Verifica se tem linha selecionada
            if (dgv_Estoque.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto na lista para alterar.", "Atenção");
                return;
            }

            try
            {
                // 2. Pega os dados da linha selecionada
                DataGridViewRow row = dgv_Estoque.SelectedRows[0];
                int idVariacao = Convert.ToInt32(row.Cells["IdVariacao"].Value);
                string nomeProd = row.Cells["Descricao"].Value.ToString();

                int qMin = Convert.ToInt32(row.Cells["QtdMin"].Value);
                int qMax = Convert.ToInt32(row.Cells["QtdMax"].Value);
                int qAtual = Convert.ToInt32(row.Cells["QtdAtual"].Value);

                // 3. Abre o Dialogo de Edição (Método auxiliar abaixo)
                using (var formEdicao = new FormEdicaoRapida(nomeProd, qMin, qMax, qAtual))
                {
                    if (formEdicao.ShowDialog() == DialogResult.OK)
                    {
                        // 4. Se o usuário clicou em Salvar, atualiza no Banco
                        AtualizarNoBanco(idVariacao, formEdicao.NovoMin, formEdicao.NovoMax, formEdicao.NovoAtual);

                        // 5. Atualiza o Grid Visualmente (sem precisar recarregar tudo do banco)
                        row.Cells["QtdMin"].Value = formEdicao.NovoMin;
                        row.Cells["QtdMax"].Value = formEdicao.NovoMax;
                        row.Cells["QtdAtual"].Value = formEdicao.NovoAtual;

                        // Re-aplica as cores
                        ColorirGrid();
                        AtualizarTotaisLabels();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir edição: " + ex.Message);
            }
        }
    }
    }
    // Pequeno form para editar quantidades sem criar arquivo novo
    public class FormEdicaoRapida : Form
    {
        public int NovoMin { get; private set; }
        public int NovoMax { get; private set; }
        public int NovoAtual { get; private set; }

        private NumericUpDown nudMin, nudMax, nudAtual;

        public FormEdicaoRapida(string produto, int min, int max, int atual)
        {
            this.Text = "Ajuste Rápido de Estoque";
            this.Size = new Size(300, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblTitulo = new Label { Text = produto, Location = new Point(10, 10), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };

            Label lblMin = new Label { Text = "Mínimo:", Location = new Point(20, 50) };
            nudMin = new NumericUpDown { Location = new Point(120, 48), Minimum = 0, Maximum = 9999, Value = min };

            Label lblMax = new Label { Text = "Máximo:", Location = new Point(20, 80) };
            nudMax = new NumericUpDown { Location = new Point(120, 78), Minimum = 0, Maximum = 9999, Value = max };

            Label lblAtual = new Label { Text = "Atual:", Location = new Point(20, 110) };
            nudAtual = new NumericUpDown { Location = new Point(120, 108), Minimum = -999, Maximum = 9999, Value = atual };

            Button btnSalvar = new Button { Text = "Salvar", DialogResult = DialogResult.OK, Location = new Point(50, 160), Size = new Size(80, 30), BackColor = Color.LightGreen };
            Button btnCancelar = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(150, 160), Size = new Size(80, 30) };

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblMin); this.Controls.Add(nudMin);
            this.Controls.Add(lblMax); this.Controls.Add(nudMax);
            this.Controls.Add(lblAtual); this.Controls.Add(nudAtual);
            this.Controls.Add(btnSalvar); this.Controls.Add(btnCancelar);

            btnSalvar.Click += (s, e) => {
                NovoMin = (int)nudMin.Value;
                NovoMax = (int)nudMax.Value;
                NovoAtual = (int)nudAtual.Value;
            };
        }
    }


