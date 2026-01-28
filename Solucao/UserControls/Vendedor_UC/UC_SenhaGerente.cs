using FontAwesome.Sharp;
using System;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_ValidacaoGerente : UserControl
    {
       private Action<string> _acaoAposLiberacao; 
        
        private Action _acaoCancelar;
        public UC_ValidacaoGerente(Action<string> acaoAposLiberacao, Action acaoCancelar)
        {
            InitializeComponent();
            _acaoAposLiberacao = acaoAposLiberacao;
            _acaoCancelar = acaoCancelar;

            // Configuração visual da senha
            txtSenhaGerente.PasswordChar = '*';
        }
        private void UC_ValidacaoGerente_Load(object sender, EventArgs e)
        {
            txtSenhaGerente.UseSystemPasswordChar = true;
        }



        private void LiberarAcesso(string nomeGerente)
        {
            MessageBox.Show("Acesso Autorizado pelo Gerente!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _acaoAposLiberacao?.Invoke(nomeGerente); 
        }

        

        private void btnAutorizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 2. Verifica no Banco de Dados se é um Gerente válido
                Usuario usuarioCheck = new GerenteUser();

                // OBS: Certifique-se que seu método BuscarLogin retorna o objeto preenchido
                Usuario gerenteEncontrado = usuarioCheck.VerificaçãoSenhaGerente(txtUserGerente.Text, txtSenhaGerente.Text);

                // Verifica se achou alguém E se essa pessoa é Gerente
                if (gerenteEncontrado != null && gerenteEncontrado.CargoFuncionario == "Gerente")
                {
                    // --- CORREÇÃO 4: Passamos o nome vindo do banco ---
                    // (Verifique se a propriedade no seu modelo é 'Nome', 'NomeUsuario' ou similar)
                    LiberarAcesso(gerenteEncontrado.Nome);
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
            _acaoCancelar?.Invoke(); // Limpa a tela ou volta ao início
        }

        private void eye_Icon_Click(object sender, EventArgs e)
        {
            // Verifica se a senha está sendo ocultada pelo sistema (bolinhas)
            if (txtSenhaGerente.UseSystemPasswordChar)
            {
                // AÇÃO: MOSTRAR SENHA
                txtSenhaGerente.UseSystemPasswordChar = false;
                eye_Icon.IconChar = IconChar.EyeSlash; // Muda para ícone "Ocultar" (Olho cortado)
            }
            else
            {
                // AÇÃO: OCULTAR SENHA
                txtSenhaGerente.UseSystemPasswordChar = true;
                eye_Icon.IconChar = IconChar.Eye; // Muda para ícone "Mostrar" (Olho aberto)
            }
        }

        
    }
}

