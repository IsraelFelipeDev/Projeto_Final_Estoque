using Projeto_FinalOficial.Modelos;
using Projeto_FinalOficial.UserControls;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class Principla : Form
    {
        // --- CONSTANTES ---
        private const string CARGO_GERENTE = "Gerente";
        private const string CARGO_VENDEDOR = "Vendedor";
        private const string CARGO_ESTOQUISTA = "Estoquista";

        private bool modoEscuroAtivo = false;
        private readonly UserLogger _logger = new UserLogger();
        private UserControl controleAtivo;
        private bool _permissaoEstoqueConcedida = false;

        // Configuração Menu
        int panelMinSize = 60;
        int panelMaxSize = 220;
        int step = 20;

        public Principla()
        {
            InitializeComponent();
            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            CustomizarSubMenus();
            cyberProgressBar1.Visible = false;
            AplicarPermissoesDeCargo();

            if (timerSidebar == null)
            {
                timerSidebar = new System.Windows.Forms.Timer();
                this.components.Add(timerSidebar);
            }

            timerSidebar.Interval = 10;
            timerSidebar.Tick += timerSidebar_Tick;

            pn_Principal.MouseEnter -= pn_Principal_MouseEnter;
            pn_Principal.MouseEnter += pn_Principal_MouseEnter;
            pn_Principal.MouseLeave -= pn_Principal_MouseLeave;
            pn_Principal.MouseLeave += pn_Principal_MouseLeave;

            foreach (Control c in pn_Principal.Controls)
            {
                c.MouseEnter += pn_Principal_MouseEnter;
            }
        }

        private void AplicarPermissoesDeCargo()
        {
            if (Sessao.Cargo != CARGO_GERENTE)
            {
                if (Btn_MenuGerente != null) Btn_MenuGerente.Visible = false;
                if (btn_SubMenuFinanceiro != null) btn_SubMenuFinanceiro.Visible = false;
                if (subMenuFinanceiro != null) subMenuFinanceiro.Visible = false;
            }
        }

        private void CustomizarSubMenus()
        {
            if (pn_SubMenuGerente != null) pn_SubMenuGerente.Visible = false;
            if (pn_SubMenuVendedor != null) pn_SubMenuVendedor.Visible = false;
            if (pn_SubMenuEstoque != null) pn_SubMenuEstoque.Visible = false;
            if (subMenuFinanceiro != null) subMenuFinanceiro.Visible = false;
        }

        public void RenderizarControl(UserControl novoControl)
        {
            if (controleAtivo != null)
            {
                pnlConteudo.Controls.Remove(controleAtivo);
                controleAtivo.Dispose();
            }
            controleAtivo = novoControl;
            novoControl.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(novoControl);
            novoControl.Focus();
        }

        private void EsconderSubMenusAtivos()
        {
            if (pn_SubMenuGerente != null && pn_SubMenuGerente.Visible) pn_SubMenuGerente.Visible = false;
            if (pn_SubMenuVendedor != null && pn_SubMenuVendedor.Visible) pn_SubMenuVendedor.Visible = false;
            if (pn_SubMenuEstoque != null && pn_SubMenuEstoque.Visible) pn_SubMenuEstoque.Visible = false;
        }

        private void AlternarSubMenu(Panel subMenu)
        {
            if (subMenu == null) return;
            if (subMenu.Visible == false)
            {
                EsconderSubMenusAtivos();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private bool PossuiPermissaoEstoque()
        {
            return Sessao.Cargo == CARGO_GERENTE ||
                   Sessao.Cargo == CARGO_ESTOQUISTA ||
                   _permissaoEstoqueConcedida;
        }

        private void icon_mod_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                icon_mod.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                icon_mod.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            }
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logger.LogClose(this);
                Application.Exit();
            }
        }

        // --- MÉTODOS DE BOTÕES ---
        private void Btn_MenuGerente_Click_1(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuGerente);

        private void btn_Monitoramento_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            RenderizarControl(new UC_Monitoramento());
        }

        private void btn_CadProd_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            RenderizarControl(new CadastroProdutos());
        }

        private async void btn_CadFun_Click(object sender, EventArgs e)
        {
            _logger.LogClick(sender, this);
            cyberProgressBar1.Visible = true;
            cyberProgressBar1.Value = 0;
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i += 5)
                {
                    this.Invoke((MethodInvoker)delegate { cyberProgressBar1.Value = i; });
                    await Task.Delay(10);
                }
            });
            cyberProgressBar1.Visible = false;
            EsconderSubMenusAtivos();
            RenderizarControl(new UC_CadastroFuncionario());
        }

        private void btn_CadForn_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            RenderizarControl(new UC_CadastroFornecedores());
        }

        private void btn_MenuVendas_Click_1(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuVendedor);

        private void btn_Desemp_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            MessageBox.Show("Módulo de Relatórios em desenvolvimento.");
        }

        private void btn_Vendedor_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            if (Sessao.Cargo == CARGO_GERENTE)
            {
                VerificarFluxoCaixa(Sessao.Nome);
            }
            else if (Sessao.Cargo == CARGO_VENDEDOR)
            {
                // VENDEDOR: Passa vazio para que o campo Gerente fique vazio
                VerificarFluxoCaixa(string.Empty);
            }
            else
            {
                SolicitarAutorizacaoGerente((nomeGerente) =>
                {
                    VerificarFluxoCaixa(nomeGerente);
                });
            }
        }

        private void btn_MenuEstoque_Click_1(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuEstoque);

        private void btn_EstoqGeral_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            if (PossuiPermissaoEstoque()) AbrirTelaEstoque();
            else SolicitarAutorizacaoGerente((nome) => { _permissaoEstoqueConcedida = true; AbrirTelaEstoque(); });
        }

        private void btn_FazerPed_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            if (PossuiPermissaoEstoque()) RenderizarControl(new UC_FazerPedido());
            else SolicitarAutorizacaoGerente((nome) => { _permissaoEstoqueConcedida = true; RenderizarControl(new UC_FazerPedido()); });
        }

        private void btn_LançarNota_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            if (PossuiPermissaoEstoque()) RenderizarControl(new UC_EntradaNota());
            else SolicitarAutorizacaoGerente((nome) => { _permissaoEstoqueConcedida = true; RenderizarControl(new UC_EntradaNota()); });
        }

        private void btn_SubMenuFinanceiro_Click_1(object sender, EventArgs e) => AlternarSubMenu(subMenuFinanceiro);

        private void btn_SalarioFunc_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            // RenderizarControl(new UC_SalarioFuncionarios());
        }

        private void btn_ContasPagar_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            RenderizarControl(new UC_ContasAPagar());
        }

        private void btn_Lucro_Click(object sender, EventArgs e) { }

        // --- TEMA E UI ---
        private void iconButton2_Click(object sender, EventArgs e)
        {
            modoEscuroAtivo = !modoEscuroAtivo;
            this.BackColor = modoEscuroAtivo ? Color.FromArgb(20, 20, 20) : Color.WhiteSmoke;
            AtualizarCoresRecursivo(this, modoEscuroAtivo);
        }

        private void AtualizarCoresRecursivo(Control container, bool escuro)
        {
            Color corTexto = escuro ? Color.White : Color.Black;
            Color corPainel = escuro ? Color.FromArgb(45, 45, 48) : Color.White;

            foreach (Control c in container.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == "Fixo") continue;

                if (c is Label) c.ForeColor = corTexto;
                else if (c is Panel || c is UserControl)
                {
                    if (c.Name != "pn_Principal")
                    {
                        c.BackColor = corPainel;
                        c.ForeColor = corTexto;
                    }
                    AtualizarCoresRecursivo(c, escuro);
                }
                else if (c is GroupBox)
                {
                    c.ForeColor = corTexto;
                    AtualizarCoresRecursivo(c, escuro);
                }
            }
        }

        private void Principla_Load_1(object sender, EventArgs e)
        {
            _logger.LogOpen(this);
            SalvarTagsRecursivo(pn_Principal);
        }

        private void SalvarTagsRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && string.IsNullOrEmpty((string)btn.Tag)) btn.Tag = btn.Text;
                if (c.HasChildren) SalvarTagsRecursivo(c);
            }
        }

        private void timerSidebar_Tick(object sender, EventArgs e)
        {
            bool mouseOver = pn_Principal.ClientRectangle.Contains(pn_Principal.PointToClient(Cursor.Position));
            if (mouseOver)
            {
                if (pn_Principal.Width < panelMaxSize) pn_Principal.Width += step;
                else { pn_Principal.Width = panelMaxSize; timerSidebar.Stop(); AlterarTextoBotoesRecursivo(pn_Principal, true); }
            }
            else
            {
                if (pn_Principal.Width == panelMaxSize) AlterarTextoBotoesRecursivo(pn_Principal, false);
                if (pn_Principal.Width > panelMinSize) pn_Principal.Width -= step;
                else { pn_Principal.Width = panelMinSize; timerSidebar.Stop(); }
            }
        }

        private void pn_Principal_MouseLeave(object sender, EventArgs e) => timerSidebar.Start();
        private void pn_Principal_MouseEnter(object sender, EventArgs e) => timerSidebar.Start();

        private void AlterarTextoBotoesRecursivo(Control parent, bool mostrar)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && c.Tag != null)
                {
                    if (mostrar)
                    {
                        btn.Text = c.Tag.ToString();
                        btn.ImageAlign = ContentAlignment.MiddleLeft;
                        btn.Padding = new Padding(10, 0, 0, 0);
                    }
                    else
                    {
                        btn.Text = "";
                        btn.ImageAlign = ContentAlignment.MiddleCenter;
                        btn.Padding = new Padding(0);
                    }
                }
                if (c.HasChildren) AlterarTextoBotoesRecursivo(c, mostrar);
            }
        }

        private void VerificarFluxoCaixa(string nomeResponsavel)
        {
            if (Sessao.IDCaixaAtual > 0)
            {
                RenderizarControl(new UC_Vendas());
            }
            else
            {
                UC_AberturaCaixa telaAbertura = new UC_AberturaCaixa(
                    nomeResponsavel, // Passa Vazio (se vendedor) ou Nome (se gerente)
                    () => { RenderizarControl(new UC_Vendas()); }
                );
                RenderizarControl(telaAbertura);
            }
        }

        private void SolicitarAutorizacaoGerente(Action<string> acaoSeAutorizado)
        {
            using (Form formPopup = new Form())
            {
                formPopup.Text = "Autorização";
                formPopup.StartPosition = FormStartPosition.CenterParent;
                formPopup.Size = new Size(652, 367);
                formPopup.FormBorderStyle = FormBorderStyle.None;
                formPopup.BackColor = Color.DimGray;
                formPopup.Padding = new Padding(1);

                UC_ValidacaoGerente ucValidacao = new UC_ValidacaoGerente(
                    acaoAposLiberacao: (nome) => { formPopup.DialogResult = DialogResult.OK; formPopup.Close(); acaoSeAutorizado(nome); },
                    acaoCancelar: () => { formPopup.DialogResult = DialogResult.Cancel; formPopup.Close(); }
                );

                ucValidacao.Dock = DockStyle.Fill;
                formPopup.Controls.Add(ucValidacao);
                formPopup.ShowDialog(this);
            }
        }

        private void AbrirTelaEstoque() => RenderizarControl(new UC_EstoqueGeral());


        public void DefinirModoTelaCheia(bool telaCheia)
        {
            pn_Principal.Visible = !telaCheia;
            pn_MenuSup.Visible = true;

            // Opcional: ajusta layout do conteúdo
            pnlConteudo.Dock = DockStyle.Fill;
        }




        private void btn_Relatorio_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            RenderizarControl(new UC_Relatorio());
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            Form1 home = new Form1();
            this.Hide();
            home.Show();
        }

    }
}
