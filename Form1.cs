using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(701, 455);
        }

        private void kryptonButton1_Click(object sender, System.EventArgs e)
        {
            Principla acesso = new Principla();
            this.Hide();
            acesso.ShowDialog();
        }

        private void pictureBox3_Click(object sender, System.EventArgs e)
        {

        }
    }
}
