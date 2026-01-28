using System;
using System.Windows.Forms;
using System.Globalization;
using Projeto_FinalOficial.Modelos;

namespace Projeto_FinalOficial
{
    public partial class UC_AberturaCaixa : UserControl
    {
        // Variáveis locais
        private string _gerenteAutorizador;
        private Action _aoAbrirComSucesso;

        // Construtor Padrão
        public UC_AberturaCaixa()
        {
            InitializeComponent();
        }

        // Construtor com Parâmetros
        public UC_AberturaCaixa(string gerenteAutorizador, Action aoAbrirComSucesso)
        {
            InitializeComponent();
            _gerenteAutorizador = gerenteAutorizador;
            _aoAbrirComSucesso = aoAbrirComSucesso;
        }

        private void UC_AberturaCaixa_Load_1(object sender, EventArgs e)
        {
            // --- 1. CONFIGURA O RESPONSÁVEL (SEMPRE O USUÁRIO LOGADO) ---
            // Independentemente de quem autorizou, quem abre é quem está logado
            btn_ResponsavelCaixa.Text = Sessao.Nome;
            btn_ResponsavelCaixa.Enabled = false; // Trava para não editar
            // Se o controle tiver propriedade ReadOnly, use também:
            // btn_ResponsavelCaixa.ReadOnly = true; 

            // --- 2. CONFIGURA O GERENTE DE LIBERAÇÃO ---
            btn_GerenteLib.Text = _gerenteAutorizador; // Coloca o texto (Vazio ou Nome)

            // Lógica visual do campo Gerente
            if (string.IsNullOrEmpty(_gerenteAutorizador))
            {
                // CASO VENDEDOR: Campo fica vazio e inoperante
                btn_GerenteLib.Enabled = false;
                // btn_GerenteLib.ReadOnly = true; 
            }
            else
            {
                // CASO GERENTE/AUTORIZADO: Campo preenchido e travado
                btn_GerenteLib.Enabled = false;
                // btn_GerenteLib.ReadOnly = true;
            }

            // --- 3. CONFIGURA VALOR INICIAL ---
            txtValorInicial.Text = "0.00";
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtValorInicial.Text))
                {
                    MessageBox.Show("Digite o valor inicial.");
                    return;
                }

                string textoFormatado = txtValorInicial.Text.Replace(",", ".");
                decimal valorInicial = 0;

                bool conversaoSucesso = decimal.TryParse(
                    textoFormatado,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out valorInicial
                );

                if (!conversaoSucesso)
                {
                    MessageBox.Show("Valor inválido. Digite apenas números.");
                    return;
                }

                if (valorInicial < 0)
                {
                    MessageBox.Show("O valor inicial não pode ser negativo.");
                    return;
                }

                FluxoCaixa novoCaixa = new FluxoCaixa();
                novoCaixa.ValorInicial = valorInicial;
                novoCaixa.UsuarioResponsavel = Sessao.Nome; // Garante que salva o nome da Sessão
                novoCaixa.GerenteLiberacao = _gerenteAutorizador; // Salva vazio ou o nome do gerente
                novoCaixa.DataAbertura = DateTime.Now;

                int idGerado = novoCaixa.AbrirCaixa();

                if (idGerado > 0)
                {
                    Sessao.IDCaixaAtual = idGerado;
                    MessageBox.Show("Caixa aberto com sucesso!");
                    _aoAbrirComSucesso?.Invoke();
                }
                else
                {
                    MessageBox.Show("Erro ao obter ID do caixa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir caixa: " + ex.Message);
            }
        }
    }
}