using Projeto_FinalOficial.Modelos;
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
    public partial class CadastroCliente : UserControl
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

       

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Nome.Text) ||
               string.IsNullOrWhiteSpace(txt_CPF.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios (Nome e CPF).");
                return;
            }

            try
            {
                // === CORREÇÃO AQUI ===
                // Instancie a classe Cliente (não Usuario, pois é ela que sabe salvar na tabela Clientes)
                Cliente novoCliente = new Cliente();

                novoCliente.Nome = txt_Nome.Text;
                novoCliente.CPF = txt_CPF.Text;
                novoCliente.Telefone = txt_Telefone.Text;
                novoCliente.CEP = txt_CEP.Text;
                novoCliente.Cidade = txt_Cidade.Text;
                novoCliente.Estado = txt_Estado.Text;
                novoCliente.Rua = txt_Rua.Text;
                novoCliente.Bairro = txt_Bairro.Text;
                novoCliente.Numero = txt_Numero.Text;

                // Chama o método InserirDados() da classe pai
                bool sucesso = novoCliente.InserirDados();

                if (sucesso)
                {
                    // Mensagem de sucesso
                    MessageBox.Show($"Cliente {novoCliente.Nome} cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // --- LÓGICA PARA VOLTAR PARA A TELA DE VENDAS ---

                    // 1. Encontra o formulário principal (pai deste UserControl)
                    // (Assumindo que o nome do seu form principal é 'Principla')
                    var formPrincipal = this.ParentForm as Principla;

                    if (formPrincipal != null)
                    {
                        // 2. Renderiza novamente a tela de vendas
                        // Isso vai remover a tela de cadastro e mostrar uma nova tela de vendas
                        formPrincipal.RenderizarControl(new UC_Vendas());
                    }
                    else
                    {
                        // Fallback: Se por algum motivo não achar o pai, tenta apenas esconder a tela atual
                        this.Hide();
                    }
                }
            }
            // --------
            catch (Exception ex)
            {
                // Mostra a exceção real (ex: erro de banco de dados, CPF duplicado, etc.)
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message);
            }
        }

    

        private async void txt_CEP_Leave(object sender, EventArgs e)
        {
            

            string cepDigitado = txt_CEP.Text;

            if (string.IsNullOrWhiteSpace(cepDigitado)) return;

            try
            {
                // Chama o serviço que criamos
                var endereco = await ViaCepService.BuscarEndereco(cepDigitado);

                if (endereco != null)
                {
                    txt_Rua.Text = endereco.logradouro;
                    txt_Bairro.Text = endereco.bairro;
                    txt_Cidade.Text = endereco.localidade;
                    txt_Estado.Text = endereco.uf;
                    txt_Numero.Focus(); // Pula para o número para facilitar
                }
                else
                {
                    MessageBox.Show("CEP não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message);
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            txt_Nome.Clear();
            txt_CPF.Clear();
            txt_Telefone.Clear();
            txt_CEP.Clear();
            txt_Cidade.Clear();
            txt_Estado.Clear();
            txt_Rua.Clear();
            txt_Bairro.Clear();
            txt_Numero.Clear();
            txt_Nome.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {

            var formPrincipal = this.ParentForm as Principla;

            if (formPrincipal != null)
            {
                // 2. Renderiza novamente a tela de vendas
                // Isso vai remover a tela de cadastro e mostrar uma nova tela de vendas
                formPrincipal.RenderizarControl(new UC_Vendas());
            }
            else
            {
                // Fallback: Se por algum motivo não achar o pai, tenta apenas esconder a tela atual
                this.Hide();
            }


        }
    }
}



