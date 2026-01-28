using FontAwesome.Sharp;
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
    public partial class UC_Cartão : UserControl
    {
        public UC_Cartão()
        {
            InitializeComponent();
        }
        private string senhaGerada;
        private string nomeGerado;
        private string numeroCartão;
        private string dataGerada;
        private string CVCGerado;
        // Propriedade para RECEBER o valor total da dívida
        public decimal ValorTotalPendente { get; set; }

        // Propriedade para ENVIAR o valor que faltou pagar (se houver)
        public decimal ValorRestante { get; private set; }
        public string TipoPagamentoSelecionado { get; set; } = "Cartão";
        public decimal ValorPago { get; private set; }

        private void GerarDadosRandomico()
        {
            Random rnd = new Random();
            string[] nomes =
            {
                "Carlos Silva",
                "João Pereira",
                "Ana Paula",
                "Lucas Andrade",
                "Fernanda Rocha",
                "Marcos Lima",
                "Juliana Santos",
                "Ricardo Moreira",
                "José Martins",
                "Bianca Fernandes",
                "Elvis Cardoso"
            };
            nomeGerado = nomes[rnd.Next(nomes.Length)];
            txt_NomeTitular.Text = nomeGerado.ToString();

            CVCGerado = rnd.Next(100, 999).ToString();
            txt_CVC.Text = CVCGerado;

            dataGerada = rnd.Next(1, 12).ToString("D2") + "/" + rnd.Next(26, 30).ToString();
            txt_Venc.Text = dataGerada;

            numeroCartão = rnd.Next(1000, 9999).ToString() +
                rnd.Next(1000, 9999).ToString() +
                rnd.Next(1000, 9999).ToString() +
                rnd.Next(1000, 9999).ToString();
            txt_NumCart.Text = numeroCartão;

            txt_Valor.Focus();

            senhaGerada = "123456";



        }


        private void txt_NumCart_Enter(object sender, EventArgs e)
        {
            if (txt_NumCart.Text == "0000 0000 0000 0000")
            {
                txt_NumCart.Text = ""; // Apaga o texto de exemplo
                txt_NumCart.ForeColor = Color.Black; // Muda a cor para escrita normal
            }
        }

       

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            // 1. Validar se o valor digitado é um número válido
            if (!decimal.TryParse(txt_Valor.Text, out decimal valorInserido))
            {
                MessageBox.Show("Por favor, insira um valor válido.");
                return;
            }

            // 2. Validar se o valor não é negativo ou zero
            if (valorInserido <= 0)
            {
                MessageBox.Show("O valor deve ser maior que zero.");
                return;
            }

            if (Math.Round(valorInserido, 2) > Math.Round(ValorTotalPendente, 2))
            {
                MessageBox.Show($"O valor inserido é maior que o total pendente (R$ {ValorTotalPendente:N2}).");
                return;
            }

            // --- LÓGICA DO PAGAMENTO PARCIAL ---

            // Calcula quanto vai sobrar
            ValorRestante = ValorTotalPendente - valorInserido;
            ValorPago = valorInserido;

            if (ValorRestante > 0)
            {
                MessageBox.Show($"Pagamento de R$ {valorInserido:N2} confirmado!\n\n" +
                                $"Ainda restam R$ {ValorRestante:N2} para pagar.");
            }
            else
            {
                MessageBox.Show("Pagamento total realizado com sucesso!");
            }

            // IMPORTANTE: Isso avisa o UC_Pagamento que deu certo
            if (this.ParentForm != null)
            {
                this.ParentForm.DialogResult = DialogResult.OK;
                this.ParentForm.Close();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            // Procura o formulário onde este User Control está inserido e o fecha
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void UC_Cartão_Load(object sender, EventArgs e)
        {

            AplicarEfeitoVisual();
            // PADRÃO INICIAL: Senha oculta
            txt_Senha.UseSystemPasswordChar = true;
            eye_Icon.IconChar = IconChar.Eye; // Ícone de "Mostrar" (Olho aberto)
            GerarDadosRandomico();
        }

        private void eye_Icon_Click(object sender, EventArgs e)
        {
            // Verifica se a senha está sendo ocultada pelo sistema (bolinhas)
            if (txt_Senha.UseSystemPasswordChar)
            {
                // AÇÃO: MOSTRAR SENHA
                txt_Senha.UseSystemPasswordChar = false;
                eye_Icon.IconChar = IconChar.EyeSlash; // Muda para ícone "Ocultar" (Olho cortado)
            }
            else
            {
                // AÇÃO: OCULTAR SENHA
                txt_Senha.UseSystemPasswordChar = true;
                eye_Icon.IconChar = IconChar.Eye; // Muda para ícone "Mostrar" (Olho aberto)
            }
        }

        private void pic_Debito_Click(object sender, EventArgs e)
        {
            TipoPagamentoSelecionado = "Cartão Débito";
            AplicarEfeitoVisual();
        }

        private void pic_Credito_Click(object sender, EventArgs e)
        {
            TipoPagamentoSelecionado = "Cartão Crédito";
            AplicarEfeitoVisual();
        }
        private void AplicarEfeitoVisual()
        {
            if (TipoPagamentoSelecionado == "Cartão Crédito")
            {
                // Crédito fica com aspecto 3D/Selecionado, Débito fica sem borda
                pic_Credito.BorderStyle = BorderStyle.Fixed3D;
                pic_Debito.BorderStyle = BorderStyle.None;
            }
            else
            {
                // Débito fica com aspecto 3D/Selecionado, Crédito fica sem borda
                pic_Credito.BorderStyle = BorderStyle.None;
                pic_Debito.BorderStyle = BorderStyle.Fixed3D;
            }
        }


    }
}
