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

        }

        private void txt_Email_Enter(object sender, EventArgs e)
        {
            if (txt_Email.Text == "exemplo@gmail.com")
            {
                txt_Email.Text = ""; // Apaga o texto de exemplo
                txt_Email.ForeColor = Color.Black; // Muda a cor para escrita normal
            }
        }
    }
}
