using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_FinalOficial.Modelos;

namespace Projeto_FinalOficial.UserControls
{
    public partial class UC_ContasAPagar : UserControl
    {
        private FinanceiroDAL dal = new FinanceiroDAL();
        private List<ContaPagar> _listaContas = new List<ContaPagar>();

        public UC_ContasAPagar()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void UC_ContasAPagar_Load(object sender, EventArgs e)
        {
            // Estado inicial: Cadastro escondido, Resumo visível
            pn_CadastroContas.Visible = false;

            // Verifica se o painel existe antes de tentar acessar
            if (pn_ResumoContas != null) pn_ResumoContas.Visible = true;

            CarregarCombosIniciais();
            CarregarDadosDoBanco();

            // Garante que o filtro "Todas" comece marcado
            if (rb_Todos != null) rb_Todos.Checked = true;
        }

        // =======================================================
        // 1. CARREGAMENTO DE DADOS
        // =======================================================
        private void CarregarDadosDoBanco()
        {
            try
            {
                _listaContas = dal.ListarContas();
                AplicarFiltroVisual(); // Aplica o filtro selecionado nos RadioButtons
                CalcularResumoFinanceiro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar contas: " + ex.Message);
            }
        }

        private void CarregarCombosIniciais()
        {
            cmb_Categoria.Items.Clear();
            cmb_Categoria.Items.Add("Custo Mercadoria (Fornecedores)");
            cmb_Categoria.Items.Add("Despesa Pessoal (Salários/Comissões)");
            cmb_Categoria.Items.Add("Despesa Ocupação (Aluguel/Condomínio)");
            cmb_Categoria.Items.Add("Despesa Operacional (Luz/Água/Sist)");
            cmb_Categoria.Items.Add("Impostos e Taxas");
            cmb_Categoria.Items.Add("Outros");
            cmb_Categoria.SelectedIndex = 0;

            try
            {
                DataTable dtFornecedores = dal.ListarFornecedoresCombo();
                cmb_FornecedorCad.DataSource = dtFornecedores;
                cmb_FornecedorCad.DisplayMember = "NomeFantasia";
                cmb_FornecedorCad.ValueMember = "Id";
                cmb_FornecedorCad.SelectedIndex = -1;
            }
            catch { }
        }

        private void ConfigurarGrid()
        {
            dgvContas.AutoGenerateColumns = false;
            dgvContas.Columns.Clear();
            dgvContas.AllowUserToAddRows = false;
            dgvContas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContas.RowHeadersVisible = false;
            dgvContas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContas.RowTemplate.Height = 35;

            dgvContas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Situacao", HeaderText = "Status", Width = 80 });
            dgvContas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição" });
            dgvContas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoria", Width = 150 });
            dgvContas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NomeFavorecidoExibicao", HeaderText = "Favorecido" });
            dgvContas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataVencimento", HeaderText = "Vencimento", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvContas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor (R$)", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });

            dgvContas.CellFormatting += DgvContas_CellFormatting;
        }

        // =======================================================
        // 2. EXCLUIR REGISTRO
        // =======================================================
        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (dgvContas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma conta na lista para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ContaPagar contaSelecionada = dgvContas.SelectedRows[0].DataBoundItem as ContaPagar;
            if (contaSelecionada == null) return;

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir a conta '{contaSelecionada.Descricao}' de valor {contaSelecionada.Valor:C2}?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    dal.ExcluirConta(contaSelecionada.Id);
                    MessageBox.Show("Conta excluída com sucesso!");
                    CarregarDadosDoBanco();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        // =======================================================
        // 3. FILTROS COLORIDOS (RADIO BUTTONS)
        // =======================================================

        private void AplicarFiltroVisual()
        {
            if (_listaContas == null || _listaContas.Count == 0) return;

            DateTime hoje = DateTime.Now.Date;
            List<ContaPagar> listaFiltrada = new List<ContaPagar>();

            if (rb_Atrasadas.Checked)
            {
                listaFiltrada = _listaContas.Where(c => c.DataPagamento == null && c.DataVencimento.Date < hoje).ToList();
            }
            else if (rb_Hoje.Checked)
            {
                listaFiltrada = _listaContas.Where(c => c.DataPagamento == null && c.DataVencimento.Date == hoje).ToList();
            }
            else if (rb_AVencer.Checked)
            {
                listaFiltrada = _listaContas.Where(c => c.DataPagamento == null && c.DataVencimento.Date > hoje).ToList();
            }
            else if (rb_Pagas.Checked)
            {
                listaFiltrada = _listaContas.Where(c => c.DataPagamento != null).ToList();
            }
            else
            {
                // rb_Todos
                listaFiltrada = _listaContas.ToList();
            }

            dgvContas.DataSource = null;
            dgvContas.DataSource = listaFiltrada;
        }

        // Eventos INDIVIDUAIS chamando o método centralizado
        // IMPORTANTE: Certifique-se que no Designer esses eventos estão vinculados
        // =======================================================
        // EVENTOS DOS RADIO BUTTONS (FILTROS)
        // =======================================================

        // =======================================================
        // EVENTOS DOS RADIO BUTTONS (CORRIGIDO PARA REALTAIIZOR)
        // =======================================================

        // Note que removemos o ", EventArgs e" de todos os métodos abaixo

        private void rb_Todos_CheckedChanged(object sender)
        {
            // O evento dispara quando marca e desmarca. 
            // Só queremos atualizar se o botão foi MARCADO.
            // O 'sender' é o próprio botão que foi clicado.
            var radio = sender as ReaLTaiizor.Controls.RadioButton;

            if (radio != null && radio.Checked)
            {
                AplicarFiltroVisual();
            }
        }

        private void rb_Atrasadas_CheckedChanged(object sender)
        {
            var radio = sender as ReaLTaiizor.Controls.RadioButton;
            if (radio != null && radio.Checked)
            {
                AplicarFiltroVisual();
            }
        }

        private void rb_Hoje_CheckedChanged(object sender)
        {
            var radio = sender as ReaLTaiizor.Controls.RadioButton;
            if (radio != null && radio.Checked)
            {
                AplicarFiltroVisual();
            }
        }

        private void rb_AVencer_CheckedChanged(object sender)
        {
            var radio = sender as ReaLTaiizor.Controls.RadioButton;
            if (radio != null && radio.Checked)
            {
                AplicarFiltroVisual();
            }
        }

        private void rb_Pagas_CheckedChanged(object sender)
        {
            var radio = sender as ReaLTaiizor.Controls.RadioButton;
            if (radio != null && radio.Checked)
            {
                AplicarFiltroVisual();
            }
        }

        // =======================================================
        // 4. LÓGICA DO PAINEL DE CADASTRO (VISIBILIDADE)
        // =======================================================

        // BOTÃO ADICIONAR (Abre cadastro, esconde resumo)
        private void btn_AdicionarRegistro_1(object sender, EventArgs e)
        {
            LimparCamposCadastro();

            // 1. Esconde o resumo lateral
            if (pn_ResumoContas != null) pn_ResumoContas.Visible = false;

            // 2. Configura e mostra o cadastro
            pn_CadastroContas.Parent = this;
            pn_CadastroContas.Dock = DockStyle.Fill;
            pn_CadastroContas.BringToFront();
            pn_CadastroContas.Visible = true;

            txtDescricao.Focus();
        }

        // BOTÃO CANCELAR (Fecha cadastro, mostra resumo)
        private void btn_Cancelar_Click_1(object sender, EventArgs e)
        {
            pn_CadastroContas.Visible = false;

            // Traz o resumo de volta
            if (pn_ResumoContas != null) pn_ResumoContas.Visible = true;
        }

        // BOTÃO SALVAR (Salva, fecha cadastro, mostra resumo)
        private void btn_CadastarConta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text)) { MessageBox.Show("Descrição obrigatória"); return; }
            if (!decimal.TryParse(txt_Valor.Text, out decimal valor)) { MessageBox.Show("Valor inválido"); return; }

            ContaPagar conta = new ContaPagar();
            conta.Descricao = txtDescricao.Text;
            conta.Categoria = cmb_Categoria.Text;
            conta.Valor = valor;
            conta.DataVencimento = dtp_DataVencimento.Value;
            conta.Observacoes = txt_Observação.Text;

            if (chk_Cadastrados.Checked)
            {
                if (cmb_FornecedorCad.SelectedValue == null) { MessageBox.Show("Selecione o fornecedor"); return; }
                conta.FornecedorId = Convert.ToInt32(cmb_FornecedorCad.SelectedValue);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_FornecedorAvulso.Text)) { MessageBox.Show("Digite o favorecido"); return; }
                conta.FavorecidoAvulso = txt_FornecedorAvulso.Text;
            }

            try
            {
                dal.CadastrarConta(conta);
                MessageBox.Show("Conta salva!");

                // FECHA O PAINEL DE CADASTRO
                pn_CadastroContas.Visible = false;

                // MOSTRA O PAINEL DE RESUMO DE VOLTA
                if (pn_ResumoContas != null) pn_ResumoContas.Visible = true;

                CarregarDadosDoBanco();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        // =======================================================
        // 5. MÉTODOS AUXILIARES
        // =======================================================
        private void btn_LimparDadosCP_Click(object sender, EventArgs e)
        {
            LimparCamposCadastro();
        }

        private void LimparCamposCadastro()
        {
            txtDescricao.Clear();
            txt_Valor.Clear();
            txt_FornecedorAvulso.Clear();
            txt_Observação.Clear();
            dtp_DataVencimento.Value = DateTime.Now;
            chk_Avulsos.Checked = true;
            chk_Cadastrados.Checked = false;
            AtualizarCamposFornecedor();
        }

        private void chk_Avulsos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Avulsos.Checked) { chk_Cadastrados.Checked = false; AtualizarCamposFornecedor(); }
        }

        private void chk_Cadastrados_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Cadastrados.Checked) { chk_Avulsos.Checked = false; AtualizarCamposFornecedor(); }
        }

        private void AtualizarCamposFornecedor()
        {
            txt_FornecedorAvulso.Enabled = chk_Avulsos.Checked;
            if (!chk_Avulsos.Checked) txt_FornecedorAvulso.Clear();
            cmb_FornecedorCad.Enabled = !chk_Avulsos.Checked;
        }

        private void CalcularResumoFinanceiro()
        {
            DateTime hoje = DateTime.Now.Date;
            var qryAtrasadas = _listaContas.Where(c => c.DataPagamento == null && c.DataVencimento.Date < hoje).ToList();
            var qryVenceHoje = _listaContas.Where(c => c.DataPagamento == null && c.DataVencimento.Date == hoje).ToList();
            var qryAVencer = _listaContas.Where(c => c.DataPagamento == null && c.DataVencimento.Date > hoje).ToList();
            var qryPagas = _listaContas.Where(c => c.DataPagamento != null).ToList();

            lblQtdAtrasadas.Text = qryAtrasadas.Count.ToString();
            lblValorAtrasadas.Text = qryAtrasadas.Sum(c => c.Valor).ToString("C2");
            lblQtdHoje.Text = qryVenceHoje.Count.ToString();
            lblValorHoje.Text = qryVenceHoje.Sum(c => c.Valor).ToString("C2");
            lblQtdAVencer.Text = qryAVencer.Count.ToString();
            lblValorAVencer.Text = qryAVencer.Sum(c => c.Valor).ToString("C2");
            lblQtdPagas.Text = qryPagas.Count.ToString();
            lblValorPagas.Text = qryPagas.Sum(c => c.Valor).ToString("C2");

            decimal total = qryAtrasadas.Sum(c => c.Valor) + qryVenceHoje.Sum(c => c.Valor) + qryAVencer.Sum(c => c.Valor);
            lblTotalQtd.Text = (qryAtrasadas.Count + qryVenceHoje.Count + qryAVencer.Count).ToString();
            lblTotalValor.Text = total.ToString("C2");
        }

        private void DgvContas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvContas.Columns[e.ColumnIndex].DataPropertyName == "Situacao" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Atrasada") { e.CellStyle.ForeColor = Color.Red; e.CellStyle.Font = new Font(dgvContas.Font, FontStyle.Bold); }
                else if (status == "Vence Hoje") { e.CellStyle.ForeColor = Color.DarkOrange; e.CellStyle.Font = new Font(dgvContas.Font, FontStyle.Bold); }
                else if (status == "Paga") { e.CellStyle.ForeColor = Color.Gray; }
                else { e.CellStyle.ForeColor = Color.Green; }
            }
        }
    }
}