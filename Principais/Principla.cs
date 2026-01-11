using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using System.Drawing.Drawing2D;
using System.Drawing.Configuration;
using Color = System.Drawing.Color;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class Principla : Form

    {
       

        private bool modoEscuroAtivo = false;
        private readonly UserLogger _logger = new UserLogger();

      

        public Principla()
        {
            InitializeComponent();
            customizando();
            cyberProgressBar1.Visible = false;
            ocultarTelasGerente();

        }
        private void ocultarTelasGerente()
        {
            if(Sessao.Sessão.Cargo != "Gerente")
            {
                Btn_MenuGerente.Visible = false;
                btn_SubMenuFinanceiro.Visible = false;
                subMenuFinanceiro.Visible = false;
            }
        }


        private void customizando()
        {
            pn_SubMenuGerente.Visible = false;
            pn_SubMenuVendedor.Visible = false;
            pn_SubMenuEstoque.Visible = false;
        }
        private void esconderSubMenu()
        {
            if (pn_SubMenuGerente.Visible == true)
                pn_SubMenuGerente.Visible = false;
            if (pn_SubMenuVendedor.Visible == true)
                pn_SubMenuVendedor.Visible = false;
            if (pn_SubMenuEstoque.Visible == true)
                pn_SubMenuEstoque.Visible = false;
        }
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                esconderSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        


        // Variável global para armazenar o controle atual
        private UserControl controleAtivo;

        private void RenderizarControl(UserControl novoControl)
        {
            // Se já houver algo na tela, removemos
            if (controleAtivo != null)
            {
                pnlConteudo.Controls.Remove(controleAtivo);
                controleAtivo.Dispose(); // Libera a memória
            }

            // Configura o novo controle
            controleAtivo = novoControl;
            novoControl.Dock = DockStyle.Fill;

            // Adiciona ao painel branco
            pnlConteudo.Controls.Add(novoControl);
        }




        private void icon_mod_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                // Maximiza a janela
                this.WindowState = FormWindowState.Maximized;

                // Muda o ícone para o de "Restaurar" (dois quadradinhos)
                icon_mod.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            }
            else
            {
                // Volta ao tamanho normal
                this.WindowState = FormWindowState.Normal;

                // Muda o ícone de volta para o de "Maximizar" (um quadradinho)
                icon_mod.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            }
        }


        //******************** Gerente*********************//
        private void Btn_MenuGerente_Click(object sender, EventArgs e)
        {



            mostrarSubMenu(pn_SubMenuGerente);

        }
        private void btn_CadFun_Click(object sender, EventArgs e)
        {
            cyberProgressBar1.Visible = true;
            for (int i = 0; i < 101; i++)

            {
                cyberProgressBar1.Value = i * i;
                Thread.Sleep(1);
            }
            esconderSubMenu();
            cyberProgressBar1.Visible = false;

            _logger.LogClick(sender, this);// Loga o clique no botão de cadastro de funcionário

            RenderizarControl(new UC_CadastroFuncionario());

        }
        private void btn_CadProd_Click(object sender, EventArgs e)
        {
            esconderSubMenu();

            _logger.LogClick(sender, this);

            RenderizarControl(new CadastroProdutos());
        }

        private void btn_Monitoramento_Click(object sender, EventArgs e)
        {
            esconderSubMenu();

            _logger.LogClick(sender, this);

            RenderizarControl(new UC_Monitoramento());
        }

        private void btn_CadForn_Click(object sender, EventArgs e)
        {
            esconderSubMenu();

            _logger.LogClick(sender, this);

            RenderizarControl(new UC_CadastroFornecedores());
        }
        //____________________________________________________




        private void btn_MenuVendas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pn_SubMenuVendedor);
        }

        private void btn_Vendedor_Click(object sender, EventArgs e)
        {
            esconderSubMenu(); // Esconde o menu primeiro
            _logger.LogClick(sender, this);

            // Verifica o cargo
            if (Sessao.Sessão.Cargo == "Gerente")
            {
                // Se é gerente, abre direto
                AbrirTelaVendas();
            }
            else
            {
                // Se não é gerente, pede senha. 
                // A tela de vendas só abrirá se a senha estiver correta (dentro do método SolicitarAutorizacaoGerente)
                SolicitarAutorizacaoGerente(AbrirTelaVendas);
            }
        }

        private void btn_Desemp_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            _logger.LogClick(sender, this);
            // RenderizarControl(new UC_Vendas());
        }


        private void btn_MenuEstoque_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(pn_SubMenuEstoque);
        }



        private void btn_EstoqGeral_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            _logger.LogClick(sender, this);
            // RenderizarControl(new UC_EstoqueGeral());
        }

        private void btn_FazerPed_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            _logger.LogClick(sender, this);
            // RenderizarControl(new UC_FazerPedido());
        }

        private void btn_LançarNota_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            _logger.LogClick(sender, this);
            // RenderizarControl(new UC_LancarNota());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

            modoEscuroAtivo = !modoEscuroAtivo;

            // 1. Muda as cores do Próprio Form Principal
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

            // 2. Chama a mágica para atualizar todos os UserControls e Labels internos
            AtualizarCoresRecursivo(this, modoEscuroAtivo);
        }

        private void AplicarTema()
        {
            if (modoEscuroAtivo)
            {
                // --- CONFIGURAÇÃO DO TEMA ESCURO ---

                // Cor de fundo do formulário principal (Cinza Escuro Profundo)
                this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                pn_MenuSup.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);

                // Se você tiver Painéis (Menu Lateral, Topo), mude a cor deles também
                // Exemplo: panelMenu.BackColor = Color.FromArgb(45, 45, 48);

                // Mudar a cor do texto para Branco para dar leitura
                this.ForeColor = System.Drawing.Color.Red;

                // Exemplo alterando botões específicos (se necessário)
                //btnVendas.BackColor = Color.FromArgb(60, 60, 60);
                //btnVendas.ForeColor = Color.White;

            }
            else
            {
                // --- CONFIGURAÇÃO DO TEMA CLARO (Original) ---

                this.BackColor = System.Drawing.Color.White; // Ou SystemColors.Control

                // Restaurar cores dos painéis
                // panelMenu.BackColor = Color.Gray; (ou a cor original da sua imagem)

                // Restaurar cor do texto para Preto
                this.ForeColor = System.Drawing.Color.Black;

                // Restaurar botões
                // btnVendas.BackColor = Color.LightGray;
                // btnVendas.ForeColor = Color.Black;
            }
        }
        // Importante para evitar o erro de ambiguidade


        // ... dentro da sua classe do Form ...

        private void AtualizarCoresRecursivo(Control container, bool escuro)
        {

            Color corFundo = escuro ? Color.FromArgb(30, 30, 30) : Color.White;
            Color corTexto = escuro ? Color.White : Color.Black; // inicia com a cor padrão do texto quando e pressionado o botão a cor do texto muda para branco
            Font fontTexto = escuro ? new Font("Segoe UI", 8, FontStyle.Bold) : new Font("Segoe UI", 8, FontStyle.Regular);

            // Cor para os painéis que VÃO mudar (UserControls/Paineis comuns)
            Color corFundoContainer = escuro ? Color.FromArgb(45, 45, 48) : Color.WhiteSmoke; // ele 

            foreach (Control c in container.Controls)
            {
                // --- AQUI ESTÁ A MUDANÇA ---
                // Se a propriedade Tag estiver escrita "fixo", o código PULA este controle e não faz nada nele.
                if (c.Tag != null && c.Tag.ToString() == "Fixo") // Utiliza "Fixo" para evitar mudanças"
                {
                    continue;
                }
                // ---------------------------

                if (c is Label) // Pega todas as Labels e muda a cor do texto
                {
                    c.Font = fontTexto;


                    c.ForeColor = corTexto;
                }
                else if (c is UserControl || c is Panel)
                {
                    c.BackColor = corFundoContainer;
                    c.ForeColor = corTexto;

                    // Continua procurando dentro dele (recursão)
                    AtualizarCoresRecursivo(c, escuro);
                }
                else if (c is GroupBox)
                {
                    c.ForeColor = corTexto;
                    AtualizarCoresRecursivo(c, escuro);
                }
            }
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            // sair

            Application.Exit();
            _logger.LogClose(this);
        }









        int panelMinSize = 50;  // Tamanho quando recolhido (só ícones)
        int panelMaxSize = 200; // Tamanho quando expandido (texto visível)
        int step = 10;          // Velocidade da animação

        private void timerSidebar_Tick(object sender, EventArgs e)
        {
            bool mouseOver = pn_Principal.ClientRectangle.Contains(pn_Principal.PointToClient(Cursor.Position));

            if (mouseOver)
            {
                // --- EXPANDINDO ---
                if (pn_Principal.Width < panelMaxSize)
                {
                    pn_Principal.Width += step;
                }
                else
                {
                    pn_Principal.Width = panelMaxSize;
                    timerSidebar.Stop();

                    // Quando terminar de abrir, MOSTRA O TEXTO
                    ShowButtonText();
                }
            }
            else
            {
                // --- RECOLHENDO ---
                // Antes de começar a diminuir, ESCONDE O TEXTO para não ficar feio
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

        // Funções auxiliares para limpar/mostrar texto
        private void HideButtonText()
        {
            foreach (Control c in pn_Principal.Controls)
            {
                if (c is Button)
                {
                    c.Text = ""; // Limpa o texto visualmente
                }
            }
        }

        private void ShowButtonText()
        {
            foreach (Control c in pn_Principal.Controls)
            {
                if (c is Button && c.Tag != null)
                {
                    c.Text = c.Tag.ToString(); // Recupera o texto salvo na Tag
                }
            }
        }

        private void pn_Principal_MouseLeave(object sender, EventArgs e)
        {
            timerSidebar.Start();
        }

        private void pn_Principal_MouseEnter(object sender, EventArgs e)
        {
            timerSidebar.Start();
        }



        private void Principla_Load_1(object sender, EventArgs e)
        {
            _logger.LogOpen(this);
            // Salva o texto atual na propriedade Tag para usar depois
            Btn_MenuGerente.Tag = Btn_MenuGerente.Text;
            btn_MenuVendas.Tag = btn_MenuVendas.Text;
            btn_MenuEstoque.Tag = btn_MenuEstoque.Text;

            // Se o menu começar fechado, já limpa o texto:
            // btnGerenciamento.Text = "";
            // btnVendas.Text = "";
            // ...

        }

        private void btn_SubMenuFinanceiro_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            // RenderizarControl(new UC_Financeiro());

        }




        // Variável para controlar o painel de fundo (para podermos removê-lo depois)
        private Panel _painelOverlay;

        private void SolicitarAutorizacaoGerente(Action acaoSeAutorizado)
        {
            // Cria uma janela padrão do Windows via código
            using (Form formPopup = new Form())
            {
                // --- Configuração da Janela "Normal" ---
                formPopup.Text = "Autorização de Gerente"; // Título da janela
                formPopup.StartPosition = FormStartPosition.CenterParent; // Aparece no meio da tela principal
                formPopup.Size = new Size(424, 249); // Tamanho da janela
                formPopup.FormBorderStyle = FormBorderStyle.None; // Janela com borda fina e botão de fechar
                formPopup.ShowInTaskbar = false;

                // Instancia o seu UserControl de Senha
                UC_ValidacaoGerente ucValidacao = new UC_ValidacaoGerente(
                    // Ação se a senha estiver CORRETA
                    acaoAposLiberacao: () =>
                    {
                        formPopup.DialogResult = DialogResult.OK; // Sinaliza sucesso
                        formPopup.Close(); // Fecha a janelinha
                    },
                    // Ação se Clicar em CANCELAR
                    acaoCancelar: () =>
                    {
                        formPopup.DialogResult = DialogResult.Cancel; // Sinaliza cancelamento
                        formPopup.Close(); // Fecha a janelinha
                    }
                );

                // Coloca o UC dentro da janela
                ucValidacao.Dock = DockStyle.Fill;
                formPopup.Controls.Add(ucValidacao);

                // Exibe a janela e trava o código aqui até ela ser fechada
                DialogResult resultado = formPopup.ShowDialog(this);

                // Se o resultado foi OK (senha certa), executa o que você queria (ex: abrir vendas)
                if (resultado == DialogResult.OK)
                {
                    acaoSeAutorizado();
                }
            }
        }

        private void FecharOverlay()
        {
            if (_painelOverlay != null)
            {
                this.Controls.Remove(_painelOverlay);
                _painelOverlay.Dispose();
                _painelOverlay = null;
            }
        }
        // Métodos auxiliares para abrir as telas
        private void AbrirTelaVendas()
        {
            // Confirme se o nome do seu controle é UC_AberturaCaixa
            RenderizarControl(new UC_AberturaCaixa());
        }

        private void AbrirTelaEstoque()
        {
            // Confirme se o nome do seu controle é UC_EstoqueGeral
            RenderizarControl(new UC_EstoqueGeral());
        }

    }
}
