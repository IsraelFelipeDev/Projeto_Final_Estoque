using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_AberturaCaixa : UserControl
    {
        public UC_AberturaCaixa()
        {
            InitializeComponent();
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            UC_Vendas vendas = new UC_Vendas();
            vendas.Show();
        }
    }
}
