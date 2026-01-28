using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_Relatorio : UserControl
    {
        private RelatorioRepository _repo = new RelatorioRepository();

        public UC_Relatorio()
        {
            InitializeComponent();
            ConfigurarEsteticaDosGrids();
        }

        private void UC_Relatorio_Load(object sender, EventArgs e)
        {
            DefinirTelaCheia(true);
            dtpInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Força o carregamento inicial
            rbSaldo.Checked = true;
            ExibirPainel(pnlVendas);
        }

        private void DefinirTelaCheia(bool ativar)
        {
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            formPrincipal?.DefinirModoTelaCheia(ativar);
        }

        private void ConfigurarEsteticaDosGrids()
        {
            var grids = new List<DataGridView> { dgvVendas, dgv_RelEstoque };
            foreach (var g in grids)
            {
                g.BackgroundColor = Color.White;
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                g.ColumnHeadersHeight = 45;
                g.RowTemplate.Height = 35;
                g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                g.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
                g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void ExibirPainel(Panel p)
        {
            pnlVendas.Visible = (p == pnlVendas);
            pnlEstoque.Visible = (p == pnlEstoque);
            p.Dock = DockStyle.Fill;
            p.BringToFront();

            if (p == pnlVendas) AtualizarVendas();
            else AtualizarEstoque();
        }

        private void AtualizarEstoque()
        {
            if (!pnlEstoque.Visible) return;
            try
            {
                DataTable dt = _repo.ObterDadosEstoque(rbSaldo.Checked, txt_BuscarProd.Text);
                dgv_RelEstoque.DataSource = dt;
                OrganizarColunasEstoque();
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar estoque: " + ex.Message); }
        }

        private void OrganizarColunasEstoque()
        {
            if (dgv_RelEstoque.Columns.Count == 0) return;

            // Ajusta os nomes dos cabeçalhos para ficarem profissionais
            if (dgv_RelEstoque.Columns.Contains("Produto")) dgv_RelEstoque.Columns["Produto"].HeaderText = "NOME DO PRODUTO";
            if (dgv_RelEstoque.Columns.Contains("Saldo")) dgv_RelEstoque.Columns["Saldo"].HeaderText = "QTD ATUAL";
            if (dgv_RelEstoque.Columns.Contains("Tipo")) dgv_RelEstoque.Columns["Tipo"].HeaderText = "MOVIMENTAÇÃO";

            // Aplica as cores de Entrada/Saída
            ColorirMovimentacoes();
        }

        private void ColorirMovimentacoes()
        {
            foreach (DataGridViewRow row in dgv_RelEstoque.Rows)
            {
                if (row.Cells["Tipo"]?.Value != null)
                {
                    string tipo = row.Cells["Tipo"].Value.ToString().ToUpper();
                    row.Cells["Tipo"].Style.ForeColor = (tipo == "SAIDA") ? Color.Red : Color.DarkGreen;
                    row.Cells["Tipo"].Style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                }
            }
        }

        // --- CLIQUES DOS BOTÕES E RADIOS ---
        private void btnMenuVendas_Click(object sender, EventArgs e) => ExibirPainel(pnlVendas);
        private void btnMenuEstoque_Click(object sender, EventArgs e) => ExibirPainel(pnlEstoque);

        private void rbSaldo_CheckedChanged(object sender, EventArgs e) { if (rbSaldo.Checked) AtualizarEstoque(); }
        private void rbHistorico_CheckedChanged(object sender, EventArgs e) { if (rbHistorico.Checked) AtualizarEstoque(); }

        private void rd_MelhorVendedor_CheckedChanged(object sender, EventArgs e) { if (rd_MelhorVendedor.Checked) AtualizarVendas(); }
        private void rd_PiorVendedor_CheckedChanged(object sender, EventArgs e) { if (rd_PiorVendedor.Checked) AtualizarVendas(); }

        private void AtualizarVendas()
        {
            try
            {
                dgvVendas.DataSource = _repo.ObterRankingVendedores(rd_MelhorVendedor.Checked, dtpInicio.Value, DateTime.Now, txt_BuscarVendedor.Text);
                if (dgvVendas.Columns.Contains("Total")) dgvVendas.Columns["Total"].DefaultCellStyle.Format = "C2";
            }
            catch { }
        }
    }
}