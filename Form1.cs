using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, System.EventArgs e)
        {
            Principla acesso = new Principla();
            this.Hide();
            acesso.ShowDialog();
        }
    }
}
