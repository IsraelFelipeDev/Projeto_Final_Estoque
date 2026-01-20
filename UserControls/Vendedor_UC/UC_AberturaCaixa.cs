using System;
using System.Windows.Forms;
using System.Globalization;
using Projeto_FinalOficial.Modelos; // Certifique-se que FluxoCaixa está aqui

namespace Projeto_FinalOficial
{
    public partial class UC_AberturaCaixa : UserControl
    {
        // Variáveis para guardar o que veio do Principal
        private string _gerenteAutorizador;
        private Action _aoAbrirComSucesso;

        // CONSTRUTOR PADRÃO (Necessário para o Visual Studio Designer não quebrar)
        public UC_AberturaCaixa()
        {
            InitializeComponent();
        }

        // NOVO CONSTRUTOR (Esse é o que tira o erro do Principal)
        public UC_AberturaCaixa(string gerenteAutorizador, Action aoAbrirComSucesso)
        {
            InitializeComponent();
            _gerenteAutorizador = gerenteAutorizador;
            _aoAbrirComSucesso = aoAbrirComSucesso;
        }

       
           

        

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validação se está vazio
                if (string.IsNullOrWhiteSpace(txtValorInicial.Text))
                {
                    MessageBox.Show("Digite o valor inicial.");
                    return;
                }

                // --- A MÁGICA ACONTECE AQUI ---
                // Pega o texto e troca a vírgula por ponto (ex: "100,00" vira "100.00")
                string textoFormatado = txtValorInicial.Text.Replace(",", ".");

                decimal valorInicial = 0;

                // Tenta converter usando o padrão "Invariant" (que usa ponto para decimais)
                // Isso garante que 100.00 seja lido como 100 reais, e não 10 mil.
                bool conversaoSucesso = decimal.TryParse(
                    textoFormatado,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out valorInicial
                );

                if (!conversaoSucesso)
                {
                    MessageBox.Show("Valor inválido. Digite apenas números.");
                    return;
                }
                // -----------------------------

                if (valorInicial < 0)
                {
                    MessageBox.Show("O valor inicial não pode ser negativo.");
                    return;
                }

                // 2. Prepara o objeto (Restante do seu código normal)
                FluxoCaixa novoCaixa = new FluxoCaixa();
                novoCaixa.ValorInicial = valorInicial;
                novoCaixa.UsuarioResponsavel = Sessao.Nome;
                novoCaixa.GerenteLiberacao = _gerenteAutorizador;
                novoCaixa.DataAbertura = DateTime.Now;

                // 3. Salva no Banco e pega o ID
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
        

        private void UC_AberturaCaixa_Load_1(object sender, EventArgs e)
        {
            // Opcional: Se tiver gerente, mostra na tela, senão mostra o usuário logado
            if (!string.IsNullOrEmpty(_gerenteAutorizador))
            {
                btn_GerenteLib.Text = _gerenteAutorizador;
                btn_GerenteLib.Enabled = true;
                btn_GerenteLib.ReadOnly = true;
                btn_ResponsavelCaixa.Text = Sessao.Nome;
                btn_ResponsavelCaixa.Enabled = true;
                btn_ResponsavelCaixa.ReadOnly = true;
            }

            // Sugestão: Já preencher o valor inicial com 0,00
            txtValorInicial.Text = "0.00";
        }

    }
}

