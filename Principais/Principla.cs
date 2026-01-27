using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Projeto_FinalOficial.Modelos;

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

        // Variável global para armazenar o controle atual
        private UserControl controleAtivo;

        // Configuração da animação do Menu
        int panelMinSize = 60; // Ajustado levemente para caber ícones centralizados
        int panelMaxSize = 220; // Ajustado para o novo layout
        int step = 20; // Aumentei o passo para a animação ser mais fluida e rápida

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

            // --- ADICIONE ESTAS LINHAS AQUI ---

            // 1. Configurar o Timer (caso não esteja configurado no Designer)
            if (timerSidebar == null)
            {
                timerSidebar = new System.Windows.Forms.Timer();
                this.components.Add(timerSidebar); // Adiciona ao container de componentes
            }

            timerSidebar.Interval = 10; // Velocidade da animação (menor = mais rápido)
            timerSidebar.Tick += timerSidebar_Tick; // Conecta o "tic-tac" do relógio ao código

            // 2. Conectar os eventos do Mouse ao Painel Principal
            // Removemos antes para não duplicar, caso já exista
            pn_Principal.MouseEnter -= pn_Principal_MouseEnter;
            pn_Principal.MouseEnter += pn_Principal_MouseEnter;

            pn_Principal.MouseLeave -= pn_Principal_MouseLeave;
            pn_Principal.MouseLeave += pn_Principal_MouseLeave;

            // 3. (Opcional) Fazer o mesmo para os botões dentro do painel
            // Isso evita que o menu feche se você passar o mouse devagar sobre um botão
            foreach (Control c in pn_Principal.Controls)
            {
                c.MouseEnter += pn_Principal_MouseEnter;
                // Não adicione MouseLeave nos botões filhos, deixe o Timer gerenciar a saída
            }
        }

        private void AplicarPermissoesDeCargo()
        {
            if (Sessao.Cargo != CARGO_GERENTE)
            {
                // Verifica se o botão existe antes de tentar esconder (para evitar null reference)
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

        // --- SISTEMA DE NAVEGAÇÃO (CORE) ---
        public void RenderizarControl(UserControl novoControl)
        {
            // 1. Limpeza de memória
            if (controleAtivo != null)
            {
                pnlConteudo.Controls.Remove(controleAtivo);
                controleAtivo.Dispose();
            }

            // 2. Configuração
            controleAtivo = novoControl;
            novoControl.Dock = DockStyle.Fill;

            // 3. Adição
            pnlConteudo.Controls.Add(novoControl);
            novoControl.Focus();
        }

        // --- MANIPULAÇÃO DE SUBMENUS ---
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

        // --- EVENTOS DE JANELA ---
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

        // GERENTE
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

            // Task.Run para não travar a UI enquanto processa o loop
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i += 5)
                {
                    // Invoke necessário pois estamos em outra thread
                    this.Invoke((MethodInvoker)delegate {
                        cyberProgressBar1.Value = i;
                    });
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


        //VENDEDOR
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



        // ESTOQUISTA
        private void btn_MenuEstoque_Click_1(object sender, EventArgs e) => AlternarSubMenu(pn_SubMenuEstoque);
        

        private void btn_EstoqGeral_Click_1(object sender, EventArgs e)
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

        private void btn_FazerPed_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
             RenderizarControl(new UC_FazerPedido());
        }

        private void btn_LançarNota_Click_1(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
            _logger.LogClick(sender, this);
             RenderizarControl(new UC_EntradaNota());
        }







        //Financeiro
        private void btn_SubMenuFinanceiro_Click_1(object sender, EventArgs e) => AlternarSubMenu(subMenuFinanceiro);
      

        private void btn_SalarioFunc_Click(object sender, EventArgs e)
        {
            EsconderSubMenusAtivos();
           // RenderizarControl(new UC_SalarioFuncionarios());

        }

        private void btn_ContasPagar_Click(object sender, EventArgs e)
        {

        }

        private void btn_Lucro_Click(object sender, EventArgs e)
        {

        }
        

        // --- TEMA (DARK MODE) ---
        private void iconButton2_Click(object sender, EventArgs e)
        {
            modoEscuroAtivo = !modoEscuroAtivo;

            // Configura cores bases
            if (modoEscuroAtivo)
            {
                this.BackColor = Color.FromArgb(20, 20, 20); // Cinza bem escuro
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
            }

            AtualizarCoresRecursivo(this, modoEscuroAtivo);
        }

        private void AtualizarCoresRecursivo(Control container, bool escuro)
        {
            Color corFundo = escuro ? Color.FromArgb(30, 30, 30) : Color.White;
            Color corTexto = escuro ? Color.White : Color.Black;
            Color corPainel = escuro ? Color.FromArgb(45, 45, 48) : Color.White;

            foreach (Control c in container.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == "Fixo") continue;

                if (c is Label)
                {
                    c.ForeColor = corTexto;
                }
                else if (c is Panel || c is UserControl)
                {
                    // Não altera a cor do Menu Principal se for vermelho fixo
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

        // --- LÓGICA DE ANIMAÇÃO DO MENU (CORRIGIDA) ---

        private void Principla_Load_1(object sender, EventArgs e)
        {
            _logger.LogOpen(this);

            // NOVO: Salva as tags de forma recursiva para garantir que funcione em qualquer layout
            SalvarTagsRecursivo(pn_Principal);
        }

        // Método recursivo auxiliar para salvar o texto na TAG
        private void SalvarTagsRecursivo(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn && string.IsNullOrEmpty((string)btn.Tag))
                {
                    btn.Tag = btn.Text; // Salva o texto original
                }

                if (c.HasChildren)
                {
                    SalvarTagsRecursivo(c);
                }
            }
        }

        private void timerSidebar_Tick(object sender, EventArgs e)
        {
            // Verifica se o mouse está sobre o painel principal
            bool mouseOver = pn_Principal.ClientRectangle.Contains(pn_Principal.PointToClient(Cursor.Position));

            if (mouseOver)
            {
                // EXPANDIR
                if (pn_Principal.Width < panelMaxSize)
                {
                    pn_Principal.Width += step;
                }
                else
                {
                    pn_Principal.Width = panelMaxSize;
                    timerSidebar.Stop();
                    // Mostra o texto APÓS expandir totalmente
                    AlterarTextoBotoesRecursivo(pn_Principal, true);
                }
            }
            else
            {
                // RECOLHER
                if (pn_Principal.Width == panelMaxSize)
                {
                    // Esconde o texto ANTES de começar a recolher
                    AlterarTextoBotoesRecursivo(pn_Principal, false);
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

        private void pn_Principal_MouseLeave(object sender, EventArgs e) => timerSidebar.Start();
        private void pn_Principal_MouseEnter(object sender, EventArgs e) => timerSidebar.Start();

        // NOVO: Método recursivo para mostrar/esconder texto (funciona com Panels aninhados)
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
                        btn.Padding = new Padding(10, 0, 0, 0); // Ajuste estético
                    }
                    else
                    {
                        btn.Text = "";
                        btn.ImageAlign = ContentAlignment.MiddleCenter;
                        btn.Padding = new Padding(0);
                    }
                }

                if (c.HasChildren)
                {
                    AlterarTextoBotoesRecursivo(c, mostrar);
                }
            }
        }

        // --- LÓGICA DE NEGÓCIO ---
        private void VerificarFluxoCaixa(string nomeGerenteAutorizador)
        {
            if (Sessao.IDCaixaAtual > 0)
            {
                RenderizarControl(new UC_Vendas());
            }
            else
            {
                UC_AberturaCaixa telaAbertura = new UC_AberturaCaixa(
                    nomeGerenteAutorizador,
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

                // Criação simples de borda ou fundo
                formPopup.BackColor = Color.DimGray;
                formPopup.Padding = new Padding(1); // Borda falsa

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

        private void AbrirTelaEstoque()
        {
            RenderizarControl(new UC_EstoqueGeral());
        }

        public void DefinirModoTelaCheia(bool telaCheia)
        {
            pn_Principal.Visible = !telaCheia;
        }

        
    }
}