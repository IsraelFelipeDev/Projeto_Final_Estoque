using System;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_ValidacaoGerente : UserControl
    {
        private Action _acaoAposLiberacao; // A tela que vai abrir se a senha estiver certa
        private Action _acaoCancelar;      // Para voltar ao menu se cancelar

        public UC_ValidacaoGerente(Action acaoAposLiberacao, Action acaoCancelar)
        {
            InitializeComponent();
            _acaoAposLiberacao = acaoAposLiberacao;
            _acaoCancelar = acaoCancelar;

            txtSenhaGerente.PasswordChar = '*';
        }

        

        private void LiberarAcesso()
        {
            MessageBox.Show("Acesso Autorizado pelo Gerente!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _acaoAposLiberacao?.Invoke(); // Executa a abertura da tela desejada
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _acaoCancelar?.Invoke(); // Limpa a tela ou volta ao início
        }

        private void btnAutorizar_Click_1(object sender, EventArgs e)
        {
            // 1. Verifica login Hardcoded (Admin)
            if (txtUserGerente.Text == "admin" && txtSenhaGerente.Text == "admin123")
            {
                LiberarAcesso();
                return;
            }

            try
            {
                // 2. Verifica no Banco de Dados se é um Gerente válido
                Usuario usuarioCheck = new GerenteUser();
                Usuario gerenteEncontrado = usuarioCheck.BuscarLogin(txtUserGerente.Text, txtSenhaGerente.Text);

                // Verifica se achou alguém E se essa pessoa é Gerente
                if (gerenteEncontrado != null && gerenteEncontrado.CargoFuncionario == "Gerente")
                {
                    LiberarAcesso();
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas ou usuário não é Gerente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao validar: " + ex.Message);
            }
        }


        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            // Se existir uma ação de cancelar específica, executa
            _acaoCancelar?.Invoke();

          
        }
    }
}
