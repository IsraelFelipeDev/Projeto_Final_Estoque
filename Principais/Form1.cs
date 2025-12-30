using System;
using System.Drawing.Text;
using System.Windows.Forms;
using static Projeto_FinalOficial.Sessao;

namespace Projeto_FinalOficial
{
    public partial class Form1 : Form
    {
        private string senhaAdm = "admin123";
        private string usuarioAdm = "admin";
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void kryptonButton1_Click(object sender, System.EventArgs e)
        {
             
        
            if (string.IsNullOrEmpty(txt_Login.Text) || string.IsNullOrEmpty(txt_Senha.Text))
            {
                MessageBox.Show("Preencha todos os campos. ");
                return;
            }
            if(txt_Login.Text == usuarioAdm && txt_Senha.Text == senhaAdm)
            {
                MessageBox.Show("Login realizado com sucesso! ");
                Principla formMenu = new Principla();
                formMenu.ShowDialog();
                this.Hide();
                return;
            }

            try
            {
                Usuario usuario = new GerenteUser();

                Usuario usuarioEcontrado = usuario.BuscarLogin(txt_Login.Text, txt_Senha.Text);
                

                if (usuarioEcontrado != null)
                {
                    Sessão.Nome = usuarioEcontrado.Nome;
                    Sessão.Cargo = usuarioEcontrado.CargoFuncionario;
                    Sessão.Id = usuarioEcontrado.Id;

                    MessageBox.Show("Login realizado com sucesso! ");
                    Principla formMenu = new Principla();
                    formMenu.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos. ");
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Principla acesso = new Principla();
         //   this.Hide();
        //acesso.ShowDialog();

    }

}

