using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class CadastroProdutos : UserControl
    {
        // ==========================================
        // 1. VARIÁVEIS GLOBAIS E SERVIÇOS
        // ==========================================
        private int _idProdutoAtual = 0; // 0 = Novo Cadastro, >0 = Edição

        private readonly Produtos _produtoModel;
        private readonly Categoria _categoriaService;
        private readonly SubCategoria _subCategoriaService;
        private readonly Estilo _estiloService;
        private readonly Composicao _composicaoService;
        private readonly Modelagem _modelagemService;
        private readonly ProdutoVariacao _variacaoService;

        public CadastroProdutos()
        {
            InitializeComponent();

            try
            {
                // Instanciando os serviços (Camada de Dados)
                _produtoModel = new Produtos();
                _categoriaService = new Categoria();
                _subCategoriaService = new SubCategoria();
                _estiloService = new Estilo();
                _composicaoService = new Composicao();
                _modelagemService = new Modelagem();
                _variacaoService = new ProdutoVariacao();

                // Configurações iniciais visuais e de eventos
                ConfigurarFormularioInicial();
            }
            catch (Exception ex)
            {
                TratarErroGlobal(ex, "Falha crítica na inicialização");
            }
        }

        private void CadastroProdutos_Load(object sender, EventArgs e)
        {
            ConfigurarGridVariacoes();
        }

        // ==========================================
        // 2. CONFIGURAÇÃO INICIAL E GRID
        // ==========================================
        private void ConfigurarFormularioInicial()
        {
            RegistrarEventos();
            CarregarCombosIndependentes(); // Categoria e Estilo
            CarregarBuscaRapida();         // Preenche o combo de busca no topo
            ResetarEstadoFormulario();     // Deixa tudo limpo para começar
        }

        private void RegistrarEventos()
        {
            // Botões Principais
            btn_Cadastrar.Click += Btn_Cadastrar_Click;
            btn_Limpar.Click += Btn_Limpar_Click;
            btn_Cancelar.Click += Btn_Cancelar_Click;

            // Auxiliares
            btn_AdicionarFoto.Click += Btn_AdicionarFoto_Click;

            // Combos e Busca
            cmb_Categoria.SelectedIndexChanged += Cmb_Categoria_SelectedIndexChanged;
            cmb_SubCategoria.SelectedIndexChanged += Cmb_SubCategoria_SelectedIndexChanged;
            cmb_BuscaRapida.SelectedIndexChanged += Cmb_BuscaRapida_SelectedIndexChanged;

            // Grid
            dgv_VariaçõesProd.DataError += Dgv_VariaçõesProd_DataError;
        }

        private void ConfigurarGridVariacoes()
        {
            // Limpeza inicial
            dgv_VariaçõesProd.AutoGenerateColumns = false;
            dgv_VariaçõesProd.Columns.Clear();

            // === ADICIONE ISTO (Coluna Oculta para o ID) ===
            dgv_VariaçõesProd.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                Visible = false // O usuário não vê, mas o código usa
            });
            // Configurações visuais gerais
            dgv_VariaçõesProd.AllowUserToAddRows = true;
            dgv_VariaçõesProd.EditMode = DataGridViewEditMode.EditOnEnter;

            // Isso garante que não sobre aquele espaço cinza no final
            dgv_VariaçõesProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 1. Coluna Tamanho (ComboBox)
            // Deixamos 'DisplayedCells' para caber textos como "GG" ou "Tamanho Único"
            DataGridViewComboBoxColumn colTamanho = new DataGridViewComboBoxColumn();
            colTamanho.HeaderText = "Tamanho";
            colTamanho.Name = "colTamanho";
            colTamanho.DataPropertyName = "Tamanho";
            colTamanho.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // <--- MUDANÇA
            colTamanho.MinimumWidth = 80; // Garante que não fique muito espremido
            colTamanho.FlatStyle = FlatStyle.Flat;
            dgv_VariaçõesProd.Columns.Add(colTamanho);

            // 2. Coluna EAN (A Estrela do Layout)
            // Definimos como FILL para ela esticar e preencher todo o resto da tela
            DataGridViewTextBoxColumn colEAN = new DataGridViewTextBoxColumn();
            colEAN.HeaderText = "EAN / Cód. Barras";
            colEAN.Name = "colEAN";
            colEAN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // <--- O SEGREDO ESTÁ AQUI
            colEAN.MinimumWidth = 100;
            dgv_VariaçõesProd.Columns.Add(colEAN);

            // 3. Qtd Min
            // ColumnHeader faz a coluna ficar da largura exata da frase "Qtd Mínima"
            DataGridViewTextBoxColumn colQtdMin = new DataGridViewTextBoxColumn();
            colQtdMin.HeaderText = "Qtd Mínima";
            colQtdMin.Name = "colQtdMin";
            colQtdMin.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; // <--- MUDANÇA
            colQtdMin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centraliza número
            colQtdMin.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_VariaçõesProd.Columns.Add(colQtdMin);

            // 4. Qtd Max
            DataGridViewTextBoxColumn colQtdMax = new DataGridViewTextBoxColumn();
            colQtdMax.HeaderText = "Qtd Máxima";
            colQtdMax.Name = "colQtdMax";
            colQtdMax.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; // <--- MUDANÇA
            colQtdMax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQtdMax.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_VariaçõesProd.Columns.Add(colQtdMax);

            // 5. Estoque Atual
            DataGridViewTextBoxColumn colQtd = new DataGridViewTextBoxColumn();
            colQtd.HeaderText = "Estoque Atual";
            colQtd.Name = "colQtd";
            colQtd.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; // <--- MUDANÇA
            colQtd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQtd.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_VariaçõesProd.Columns.Add(colQtd);
        }

        private void Dgv_VariaçõesProd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true; // Evita crash se usuario digitar letra em campo numérico do grid
        }

        // ==========================================
        // 3. CARREGAMENTO DE DADOS (Busca e Combos)
        // ==========================================

        private void CarregarBuscaRapida()
        {
            try
            {
                // Remove evento temporariamente para preencher sem disparar lógica
                cmb_BuscaRapida.SelectedIndexChanged -= Cmb_BuscaRapida_SelectedIndexChanged;

                var dt = _produtoModel.ListarNomesParaBusca(); // Método deve retornar ID e Nome

                cmb_BuscaRapida.DataSource = dt;
                cmb_BuscaRapida.DisplayMember = "Nome";
                cmb_BuscaRapida.ValueMember = "Id";
                cmb_BuscaRapida.SelectedIndex = -1;

                cmb_BuscaRapida.SelectedIndexChanged += Cmb_BuscaRapida_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                TratarErroGlobal(ex, "Erro ao carregar lista de busca rápida");
            }
        }

        private void CarregarCombosIndependentes()
        {
            try
            {
                var listaCategorias = _categoriaService.ListarTodas();
                ConfigurarComboBoxPadrao(cmb_Categoria, listaCategorias);

                var listaEstilos = _estiloService.ListarTodos();
                ConfigurarComboBoxPadrao(cmb_Estilo, listaEstilos);
            }
            catch (Exception ex) { TratarErroGlobal(ex, "Erro ao carregar listas iniciais"); }
        }

        // --- Evento da BUSCA RÁPIDA (Onde a mágica acontece) ---
        private void Cmb_BuscaRapida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_BuscaRapida.SelectedIndex > -1 && cmb_BuscaRapida.SelectedValue is int idProduto)
            {
                _idProdutoAtual = idProduto; // Entramos em modo de EDIÇÃO
                CarregarDadosProdutoEdicao(); // Preenche a tela
            }
        }

        private void CarregarDadosProdutoEdicao()
        {
            if (_idProdutoAtual == 0) return;

            try
            {
                // 1. Busca dados do Produto Pai
                Produtos produto = _produtoModel.BuscarPorId(_idProdutoAtual);

                if (produto != null)
                {
                    txt_Nome.Text = produto.Nome;
                    txt_Coleção.Text = produto.Colecao;
                    txt_DescriçãoProd.Text = produto.Descricao;
                    txt_Cor.Text = produto.Cor;
                    txt_CustoMedio.Text = produto.ValorCompra.ToString("N2");

                    // Preencher combos dispara eventos que carregam subcategorias
                    cmb_Categoria.Text = produto.Categoria;
                    cmb_SubCategoria.Text = produto.SubCategoria;
                    cmb_Estilo.Text = produto.Estilo;
                    Cmb_Composição.Text = produto.Composicao;
                    cmb_Modelagem.Text = produto.Modelagem;

                    // Foto
                    if (produto.FotoCapa != null && produto.FotoCapa.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(produto.FotoCapa))
                            pic_Foto.Image = Image.FromStream(ms);
                    }
                    else pic_Foto.Image = null;

                    btn_Cadastrar.Text = "Salvar Alterações"; // Feedback visual
                }

                // 2. Busca e Preenche o Grid de Variações
                dgv_VariaçõesProd.Rows.Clear();
                var listaVariacoes = _variacaoService.BuscarPorProdutoPai(_idProdutoAtual);

                if (listaVariacoes != null)
                {
                    foreach (var item in listaVariacoes)
                    {
                        int index = dgv_VariaçõesProd.Rows.Add();
                        DataGridViewRow row = dgv_VariaçõesProd.Rows[index];

                        // Precisamos garantir que o ComboBox da coluna tenha os tamanhos carregados antes de setar o valor
                        // Como definimos a SubCategoria acima, o grid já deve ter as opções de tamanho corretas
                        row.Cells["colTamanho"].Value = item.Tamanho;
                        row.Cells["colId"].Value = item.Id;
                        row.Cells["colEAN"].Value = item.CodigoBarrasEAN;
                        row.Cells["colQtd"].Value = item.QtdAtual;
                        row.Cells["colQtdMin"].Value = item.QtdMin;
                        row.Cells["colQtdMax"].Value = item.QtdMax;
                    }
                }
            }
            catch (Exception ex)
            {
                TratarErroGlobal(ex, "Erro ao carregar dados para edição");
            }
        }

        // --- Eventos de Categoria e SubCategoria ---
        private void Cmb_Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Categoria.SelectedIndex > -1 && cmb_Categoria.SelectedValue is int categoriaId)
            {
                try
                {
                    var listaSub = _subCategoriaService.BuscarPorCategoriaPai(categoriaId);
                    ConfigurarComboBoxPadrao(cmb_SubCategoria, listaSub);
                    cmb_SubCategoria.Enabled = listaSub.Count > 0;

                    var listaComp = _composicaoService.BuscarPorCategoria(categoriaId);
                    ConfigurarComboBoxPadrao(Cmb_Composição, listaComp);

                    var listaModel = _modelagemService.BuscarPorCategoria(categoriaId);
                    ConfigurarComboBoxPadrao(cmb_Modelagem, listaModel);
                    if (listaModel.Count == 1) cmb_Modelagem.SelectedIndex = 0;

                    // Se mudou a categoria manualmente (não via busca), limpa o grid
                    if (cmb_BuscaRapida.SelectedIndex == -1) dgv_VariaçõesProd.Rows.Clear();
                }
                catch (Exception ex) { TratarErroGlobal(ex, "Erro ao filtrar dependências da categoria"); }
            }
            else
            {
                LimparCombosDependentes();
            }
        }

        private void Cmb_SubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_SubCategoria.SelectedIndex > -1 && cmb_SubCategoria.SelectedValue is int idSubCat)
            {
                try
                {
                    // Carrega os tamanhos (P, M, G...) no ComboBox de dentro do Grid
                    DataTable dtTamanhos = _subCategoriaService.BuscarTamanhosPorSubCategoria(idSubCat);
                    var colCombo = (DataGridViewComboBoxColumn)dgv_VariaçõesProd.Columns["colTamanho"];

                    if (dtTamanhos != null && dtTamanhos.Rows.Count > 0)
                    {
                        colCombo.DataSource = dtTamanhos;
                        colCombo.DisplayMember = "Tamanho";
                        colCombo.ValueMember = "Tamanho";
                    }
                    else colCombo.DataSource = null;
                }
                catch (Exception ex) { TratarErroGlobal(ex, "Erro ao carregar grade de tamanhos"); }
            }
        }

        // ==========================================
        // 4. LÓGICA DE SALVAR (CRUD)
        // ==========================================

        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (!FormularioEstaValido()) return;

            try
            {
                Produtos produto = MapearFormularioParaModelo();
                int idFinal = 0;

                // --- CENÁRIO 1: NOVO PRODUTO (INSERT) ---
                if (_idProdutoAtual == 0)
                {
                    idFinal = produto.SalvarRetornandoId();
                    if (idFinal > 0)
                    {
                        SalvarVariacoesDoGrid(idFinal);
                        ExibirMensagemSucesso($"Produto cadastrado! ID: {idFinal}");
                        ResetarEstadoFormulario();
                    }
                }
                // --- CENÁRIO 2: EDIÇÃO DE PRODUTO (UPDATE) ---
                else
                {
                    bool ok = produto.Atualizar(); // Update no pai
                    if (ok)
                    {
                        // Remove variações antigas e salva as que estão no grid agora
                        
                        SalvarVariacoesDoGrid(_idProdutoAtual);

                        ExibirMensagemSucesso("Produto atualizado com sucesso!");
                        ResetarEstadoFormulario();
                    }
                }
            }
            catch (Exception ex)
            {
                TratarErroGlobal(ex, "Erro ao salvar os dados");
            }
        }

        private void SalvarVariacoesDoGrid(int produtoId)
        {
            foreach (DataGridViewRow row in dgv_VariaçõesProd.Rows)
            {
                if (row.IsNewRow) continue;

                string tamanho = row.Cells["colTamanho"].Value?.ToString();
                if (string.IsNullOrEmpty(tamanho)) continue;

                // Recupera os dados do Grid
                int idVariacao = Convert.ToInt32(row.Cells["colId"].Value); // Pega o ID oculto (será 0 se for novo)
                string ean = row.Cells["colEAN"].Value?.ToString();
                int.TryParse(row.Cells["colQtd"].Value?.ToString(), out int qtdAtual);
                int.TryParse(row.Cells["colQtdMin"].Value?.ToString(), out int qtdMin);
                int.TryParse(row.Cells["colQtdMax"].Value?.ToString(), out int qtdMax);

                var variacao = new ProdutoVariacao
                {
                    Id = idVariacao, // Importante passar o ID
                    ProdutoId = produtoId,
                    Tamanho = tamanho,
                    CodigoBarrasEAN = ean,
                    QtdAtual = qtdAtual,
                    QtdMin = qtdMin,
                    QtdMax = qtdMax
                };

                if (idVariacao > 0)
                {
                    // Se tem ID, ATUALIZA (UPDATE produtos_variacoes SET ... WHERE Id = @id)
                    variacao.Atualizar();
                }
                else
                {
                    // Se ID é 0, INSERE (INSERT INTO ...)
                    variacao.Salvar();
                }
            }
        }

        // ==========================================
        // 5. UTILITÁRIOS E AUXILIARES
        // ==========================================

        private void Btn_Limpar_Click(object sender, EventArgs e) => ResetarEstadoFormulario();

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar a operação?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                ResetarEstadoFormulario();
        }

        private void ResetarEstadoFormulario()
        {
            _idProdutoAtual = 0; // Volta para INSERT

            // Limpa Busca Rápida sem disparar eventos
            cmb_BuscaRapida.SelectedIndexChanged -= Cmb_BuscaRapida_SelectedIndexChanged;
            cmb_BuscaRapida.SelectedIndex = -1;
            cmb_BuscaRapida.Text = "";
            cmb_BuscaRapida.SelectedIndexChanged += Cmb_BuscaRapida_SelectedIndexChanged;

            // Limpa Controles
            LimparControlesRecursivo(this.Controls);
            pic_Foto.Image = null;
            dgv_VariaçõesProd.Rows.Clear();

            // Reseta Combos Dependentes
            cmb_SubCategoria.DataSource = null;
            cmb_SubCategoria.Enabled = false;
            Cmb_Composição.DataSource = null;
            cmb_Modelagem.DataSource = null;

            btn_Cadastrar.Text = "Cadastrar"; // Texto Original
            txt_Nome.Focus();
        }

        private void LimparControlesRecursivo(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is TextBox txt) txt.Clear();
                else if (ctrl is KryptonComboBox kCbo) { kCbo.SelectedIndex = -1; kCbo.Text = ""; }

                if (ctrl.HasChildren) LimparControlesRecursivo(ctrl.Controls);
            }
        }

        private Produtos MapearFormularioParaModelo()
        {
            return new Produtos
            {
                Id = _idProdutoAtual,
                Nome = txt_Nome.Text.Trim(),
                Colecao = txt_Coleção.Text.Trim(),
                Descricao = txt_DescriçãoProd.Text.Trim(),
                Categoria = cmb_Categoria.Text,
                SubCategoria = cmb_SubCategoria.Text,
                Estilo = cmb_Estilo.Text,
                Composicao = Cmb_Composição.Text,
                Modelagem = cmb_Modelagem.Text,
                Cor = txt_Cor.Text.Trim(),
                ValorCompra = decimal.TryParse(txt_CustoMedio.Text, out decimal val) ? val : 0m,
                FotoCapa = ConverterImagemParaBytes(pic_Foto.Image),
                DataCadastro = DateTime.Now
            };
        }

        private bool FormularioEstaValido()
        {
            StringBuilder erros = new StringBuilder();
            if (string.IsNullOrWhiteSpace(txt_Nome.Text)) erros.AppendLine("- Nome é obrigatório.");
            if (cmb_Categoria.SelectedIndex < 0) erros.AppendLine("- Categoria é obrigatória.");
            if (cmb_SubCategoria.SelectedIndex < 0) erros.AppendLine("- SubCategoria é obrigatória.");

            bool temGrade = false;
            foreach (DataGridViewRow row in dgv_VariaçõesProd.Rows)
            {
                if (!row.IsNewRow && row.Cells["colTamanho"].Value != null)
                {
                    temGrade = true;
                    break;
                }
            }
            if (!temGrade) erros.AppendLine("- Informe ao menos um tamanho na grade.");

            if (erros.Length > 0)
            {
                MessageBox.Show($"Corrija:\n{erros}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ConfigurarComboBoxPadrao(KryptonComboBox cbo, object dataSource)
        {
            // Remove handlers temporariamente
            if (cbo == cmb_Categoria) cbo.SelectedIndexChanged -= Cmb_Categoria_SelectedIndexChanged;
            if (cbo == cmb_SubCategoria) cbo.SelectedIndexChanged -= Cmb_SubCategoria_SelectedIndexChanged;

            cbo.DataSource = dataSource;
            cbo.DisplayMember = "Nome";
            cbo.ValueMember = "Id";
            cbo.SelectedIndex = -1;

            // Religa handlers
            if (cbo == cmb_Categoria) cbo.SelectedIndexChanged += Cmb_Categoria_SelectedIndexChanged;
            if (cbo == cmb_SubCategoria) cbo.SelectedIndexChanged += Cmb_SubCategoria_SelectedIndexChanged;
        }

        private void LimparCombosDependentes()
        {
            cmb_SubCategoria.DataSource = null;
            cmb_SubCategoria.Enabled = false;
            Cmb_Composição.DataSource = null;
            cmb_Modelagem.DataSource = null;
            dgv_VariaçõesProd.Rows.Clear();
        }

        private void Btn_AdicionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                    pic_Foto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private byte[] ConverterImagemParaBytes(Image img)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void ExibirMensagemSucesso(string msg) => MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void TratarErroGlobal(Exception ex, string titulo) => MessageBox.Show($"{titulo}\n\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // Métodos sem uso mas mantidos para evitar quebra de designer antigo
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void Btn_BuscarProd_Click(object sender, EventArgs e) { }

        private void btn_BuscarProd_Click_1(object sender, EventArgs e)
        {

        }
    }
}