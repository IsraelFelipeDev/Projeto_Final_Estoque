using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks; // Necessário para Task.Delay
using System.Windows.Forms;
using System.Linq; // Necessário para linq
using Projeto_FinalOficial.Modelos; // Assumindo que Sessao e UserLogger estão aqui ou ajustados

namespace Projeto_FinalOficial
{
    public partial class Principla : Form
    {
        // --- CONSTANTES PARA EVITAR ERROS DE DIGITAÇÃO ---
        private const string CARGO_GERENTE = "Gerente";
        private const string CARGO_VENDEDOR = "Vendedor";
        private const string CARGO_ESTOQUISTA = "Estoquista";

        private bool modoEscuroAtivo = false;
        private readonly UserLogger _logger = new UserLogger();

        // Variável global para armazenar o controle atual (navegação)
        private UserControl controleAtivo;

        // Configuração da animação do Menu
        int panelMinSize = 50;
        int panelMaxSize = 200;
        int step = 10;

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
        }

        private void AplicarPermissoesDeCargo()
        {
            // Se não for gerente, esconde os botões administrativos
            if (Sessao.Cargo != CARGO_GERENTE)
            {
                Btn_MenuGerente.Visible = false;
                btn_SubMenuFinanceiro.Visible = false;
                subMenuFinanceiro.Visible = false;
            }
        }

        private void CustomizarSubMenus()
        {
            pn_SubMenuGerente.Visible = false;
            pn_SubMenuVendedor.Visible = false;
            pn_SubMenuEstoque.Visible = false;
        }

        // --- SISTEMA DE NAVEGAÇÃO (CORE) ---
        public void RenderizarControl(UserControl novoControl)
        {
            // 1. Limpeza de memória do controle anterior
            if (controleAtivo != null)
            {
                pnlConteudo.Controls.Remove(controleAtivo);
                controleAtivo.Dispose();
            }

            // 2. Configuração do novo controle
            controleAtivo = novoControl;
            novoControl.Dock = DockStyle.Fill;

            // 3. Adição à tela
            pnlConteudo.Controls.Add(novoControl);

            // 4. Garante que o novo controle ganhe foco (opcional, mas bom para UX)
            novoControl.Focus();
        }

        // --- MANIPULAÇÃO DE SUBMENUS ---
        private void EsconderSubMenusAtivos()
        {
            if (pn_SubMenuGerente.Visible) pn_SubMenuGerente.Visible = false;
            if (pn_SubMenuVendedor.Visible) pn_SubMenuVendedor.Visible = false;
            if (pn_SubMenuEstoque.Visible) pn_SubMenuEstoque.Visible = false;
        }

        private void AlternarSubMenu(Panel subMenu)
        {
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

        // --- EVENTOS DE TELA E JANELA ---
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

        // --- MENU GERENTE ---
        private void Btn_MenuGerente_Click(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuGerente);

        // AQUI ESTAVA O PROBLEMA DE TRAVAMENTO: Use async/await
        private async void btn_CadFun_Click(object sender, EventArgs e)
        {
            _logger.LogClick(sender, this);

            // Animação Assíncrona (Não trava a tela)
            cyberProgressBar1.Visible = true;
            cyberProgressBar1.Value = 0;

            for (int i = 0; i <= 100; i += 2) // Acelerado para UX melhor
            {
                cyberProgressBar1.Value = i;
                await Task.Delay(1); // Libera a thread de UI para desenhar
            }

            cyberProgressBar1.Visible = false;
            EsconderSubMenusAtivos();

            RenderizarControl(new UC_CadastroFuncionario());
        }

        private void btn_CadProd_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            RenderizarControl(new CadastroProdutos());
        }

        private void btn_Monitoramento_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            RenderizarControl(new UC_Monitoramento());
        }

        private void btn_CadForn_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            RenderizarControl(new UC_CadastroFornecedores());
        }

        // --- MENU VENDAS ---
        private void btn_MenuVendas_Click(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuVendedor);

        private void btn_Vendedor_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            // Se for Gerente ou Vendedor, o sistema deixa passar direto (conforme sua regra)
            // Se for Estoquista tentando vender, pede senha
            if (Sessao.Cargo == CARGO_GERENTE || Sessao.Cargo == CARGO_VENDEDOR)
            {
                VerificarFluxoCaixa(null);
            }
            else
            {
                SolicitarAutorizacaoGerente((nomeGerente) =>
                {
                    VerificarFluxoCaixa(nomeGerente);
                });
            }
        }

        private void btn_Desemp_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            // ATENÇÃO: Aqui não devemos chamar UC_Pagamento, pois pagamento depende de uma venda ativa.
            // Aqui deve ser a tela de Relatórios ou Dashboard.
            MessageBox.Show("Tela de Desempenho/Relatórios em construção.");
            // RenderizarControl(new UC_Relatorios()); 
        }

        // --- MENU ESTOQUE ---
        private void btn_MenuEstoque_Click(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuEstoque);

        private void btn_EstoqGeral_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);

            if (Sessao.Cargo == CARGO_GERENTE || Sessao.Cargo == CARGO_ESTOQUISTA)
            {
                AbrirTelaEstoque();
            }
            else
            {
                SolicitarAutorizacaoGerente((nome) => AbrirTelaEstoque());
            }
        }

        private void btn_FazerPed_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            // RenderizarControl(new UC_FazerPedido());
        }

        private void btn_LançarNota_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
            // RenderizarControl(new UC_LancarNota());
        }

        // --- TEMA (DARK MODE) ---
        private void iconButton2_Click(object sender, EventArgs e)
        {
            modoEscuroAtivo = !modoEscuroAtivo;

            if (modoEscuroAtivo)
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.FromArgb(189, 9, 9);
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }

            AtualizarCoresRecursivo(this, modoEscuroAtivo);
        }

        private void AtualizarCoresRecursivo(Control container, bool escuro)
        {
            Color corFundo = escuro ? Color.FromArgb(30, 30, 30) : Color.White;
            Color corTexto = escuro ? Color.White : Color.Black;
            Font fontTexto = escuro ? new Font("Segoe UI", 8, FontStyle.Bold) : new Font("Segoe UI", 8, FontStyle.Regular);
            Color corFundoContainer = escuro ? Color.FromArgb(45, 45, 48) : Color.WhiteSmoke;

            foreach (Control c in container.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == "Fixo") continue;

                if (c is Label)
                {
                    c.Font = fontTexto;
                    c.ForeColor = corTexto;
                }
                else if (c is UserControl || c is Panel)
                {
                    c.BackColor = corFundoContainer;
                    c.ForeColor = corTexto;
                    AtualizarCoresRecursivo(c, escuro);
                }
                else if (c is GroupBox)
                {
                    c.ForeColor = corTexto;
                    AtualizarCoresRecursivo(c, escuro);
                }
            }
        }

        // --- ANIMAÇÃO MENU LATERAL ---
        private void timerSidebar_Tick(object sender, EventArgs e)
        {
            bool mouseOver = pn_Principal.ClientRectangle.Contains(pn_Principal.PointToClient(Cursor.Position));

            if (mouseOver)
            {
                if (pn_Principal.Width < panelMaxSize)
                {
                    pn_Principal.Width += step;
                }
                else
                {
                    pn_Principal.Width = panelMaxSize;
                    timerSidebar.Stop();
                    ShowButtonText();
                }
            }
            else
            {
                if (pn_Principal.Width == panelMaxSize)
                {
                    HideButtonText();
                }

                if (pn_Principal.Width > panelMinSize)
                {
                    pn_Principal.Width -= step;
                }
                else
                {
                    pn_Principal.Width = panelMinSize;
                    timerSidebar.Stop();
                }
            }
        }

        private void HideButtonText()
        {
            foreach (Control c in pn_Principal.Controls)
            {
                if (c is Button) c.Text = "";
            }
        }

        private void ShowButtonText()
        {
            foreach (Control c in pn_Principal.Controls)
            {
                if (c is Button && c.Tag != null)
                {
                    c.Text = c.Tag.ToString();
                }
            }
        }

        private void pn_Principal_MouseLeave(object sender, EventArgs e) => timerSidebar.Start();
        private void pn_Principal_MouseEnter(object sender, EventArgs e) => timerSidebar.Start();

        private void Principla_Load_1(object sender, EventArgs e)
        {
            _logger.LogOpen(this);
            // Salva o texto dos botões na Tag para recuperar depois da animação
            Btn_MenuGerente.Tag = Btn_MenuGerente.Text;
            btn_MenuVendas.Tag = btn_MenuVendas.Text;
            btn_MenuEstoque.Tag = btn_MenuEstoque.Text;
        }

        private void btn_SubMenuFinanceiro_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            // RenderizarControl(new UC_Financeiro());
        }

        // --- LÓGICA DE NEGÓCIO: FLUXO DE CAIXA E PERMISSÕES ---

        private void VerificarFluxoCaixa(string nomeGerenteAutorizador)
        {
            // 1. Caixa Aberto? Vai pra Venda
            if (Sessao.IDCaixaAtual > 0)
            {
                RenderizarControl(new UC_Vendas());
            }
            // 2. Caixa Fechado? Abre tela de Abertura
            else
            {
                UC_AberturaCaixa telaAbertura = new UC_AberturaCaixa(
                    nomeGerenteAutorizador,
                    () =>
                    {
                        // Callback executado APÓS o caixa abrir com sucesso
                        RenderizarControl(new UC_Vendas());
                    }
                );
                RenderizarControl(telaAbertura);
            }
        }

        private void SolicitarAutorizacaoGerente(Action<string> acaoSeAutorizado)
        {
            using (Form formPopup = new Form())
            {
                formPopup.Text = "Autorização de Gerente";
                formPopup.StartPosition = FormStartPosition.CenterParent;
                formPopup.Size = new Size(424, 249);
                formPopup.FormBorderStyle = FormBorderStyle.None;
                formPopup.ShowInTaskbar = false;

                string nomeGerenteCapturado = "";

                UC_ValidacaoGerente ucValidacao = new UC_ValidacaoGerente(
                    acaoAposLiberacao: (nome) =>
                    {
                        nomeGerenteCapturado = nome;
                        formPopup.DialogResult = DialogResult.OK;
                        formPopup.Close();
                    },
                    acaoCancelar: () =>
                    {
                        formPopup.DialogResult = DialogResult.Cancel;
                        formPopup.Close();
                    }
                );

                ucValidacao.Dock = DockStyle.Fill;
                formPopup.Controls.Add(ucValidacao);

                if (formPopup.ShowDialog(this) == DialogResult.OK)
                {
                    acaoSeAutorizado(nomeGerenteCapturado);
                }
            }
        }

        private void AbrirTelaEstoque()
        {
            RenderizarControl(new UC_EstoqueGeral());
        }

        public void DefinirModoTelaCheia(bool telaCheia)
        {
            if (telaCheia)
                pn_Principal.Visible = false;
            else
                pn_Principal.Visible = true;
        }
    }
}