using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_CadastroFuncionario : UserControl
    {
        public UC_CadastroFuncionario()
        {
            InitializeComponent();
        }
       

        private void UC_CadastroFuncionario_Load(object sender, EventArgs e)
        {
            string[] listaCargos = { "Gerente", "Vendedor", "Estoquista" };

            cmb_Cargo.Items.Clear();
            cmb_Cargo.Items.AddRange(listaCargos); // AddRange adiciona todos de uma vez
        }

        private void txt_Email_Enter(object sender, EventArgs e)
        {
            if (txt_Email.Text == "exemplo@gmail.com")
            {
                txt_Email.Text = ""; // Apaga o texto de exemplo
                txt_Email.ForeColor = Color.Black; // Muda a cor para escrita normal
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Nome.Text) ||
               string.IsNullOrWhiteSpace(txt_Senha.Text) ||
               string.IsNullOrWhiteSpace(txt_Email.Text) ||
               string.IsNullOrWhiteSpace(txt_CPF.Text) ||
               string.IsNullOrWhiteSpace(txt_Telefone.Text) ||
               string.IsNullOrWhiteSpace(txt_Cidade.Text) ||
               string.IsNullOrWhiteSpace(txt_Estado.Text) ||
               string.IsNullOrWhiteSpace(txt_Bairro.Text) ||
               string.IsNullOrWhiteSpace(txt_Rua.Text) ||
               string.IsNullOrWhiteSpace(txt_Numero.Text) ||
               string.IsNullOrWhiteSpace(cmb_Cargo.Text) ||
               string.IsNullOrWhiteSpace(dtp_DataNasc.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            Usuario usuario = null;
            try
            {
                switch (cmb_Cargo.Text)
                {
                    case "Gerente":
                        usuario = new GerenteUser();
                        break;
                    case "Vendedor":
                        usuario = new VendedorUser();
                        break;
                    case "Estoquista":
                        usuario = new EstoquistaUser();
                        break;
                    default:
                        MessageBox.Show("Cargo inválido selecionado.");
                        return;
                }

                usuario.Nome = txt_Nome.Text;
                usuario.Senha = txt_Senha.Text;
                usuario.Email = txt_Email.Text;
                usuario.CPF = txt_CPF.Text;
                usuario.Telefone = txt_Telefone.Text;
                usuario.Cidade = txt_Cidade.Text;
                usuario.Estado = txt_Estado.Text;
                usuario.Bairro = txt_Bairro.Text;
                usuario.Rua = txt_Rua.Text;
                usuario.Numero = txt_Numero.Text;
                usuario.CargoFuncionario = cmb_Cargo.Text;
                usuario.DataNascimento = dtp_DataNasc.Value;

                bool sucesso = usuario.InserirDados();

                MessageBox.Show($"Cadastro de {cmb_Cargo.Text} realizado com sucesso!");
                Form1 acesso = new Form1();
                this.Hide();
                acesso.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao cadastrar {cmb_Cargo.Text}: " + ex.Message);
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            txt_Nome.Clear();
            txt_Senha.Clear();
            txt_Email.Clear();
            txt_CPF.Clear();
            txt_Telefone.Clear();
            txt_Cidade.Clear();
            txt_Estado.Clear();
            txt_Bairro.Clear();
            txt_Rua.Clear();
            txt_Numero.Clear();
            cmb_Cargo.SelectedIndex = -1;
            dtp_DataNasc.Value = DateTime.Now;
            txt_Nome.Focus();

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
