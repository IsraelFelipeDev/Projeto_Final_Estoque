using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Projeto_FinalOficial.Modelos;

namespace Projeto_FinalOficial
{
    public partial class UC_Vendas : UserControl    
    {
        public UC_Vendas()
        {
            InitializeComponent();
        }

        private Cliente _clienteParaImpressao = null;
        private decimal _valorTotalVenda = 0;

        // 1. Variável para guardar o ID do produto que está na tela no momento
        private int _idProdutoAtual = 0;

        private void UC_Vendas_Load(object sender, EventArgs e)
        {
            CarregarDataGridView();

            // Lógica robusta para Tela Cheia
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.DefinirModoTelaCheia(true);
            }
        }

        private void CarregarDataGridView()
        {
            // Configura as colunas do DataGridView
            dgv_Carrinho.Columns.Clear();
            dgv_Carrinho.Columns.Add("Nome", "Nome do Produto");
            dgv_Carrinho.Columns.Add("Cor", "Cor");
            dgv_Carrinho.Columns.Add("ValorUnitario", "Valor Unitário");
            dgv_Carrinho.Columns.Add("Quantidade", "Quantidade");
            dgv_Carrinho.Columns.Add("TotalItem", "Total do Item");
            // Define o estilo das colunas, se necessário
            dgv_Carrinho.Columns["ValorUnitario"].DefaultCellStyle.Format = "N2";
            dgv_Carrinho.Columns["TotalItem"].DefaultCellStyle.Format = "N2";
        }
        private void UC_Vendas_Leave(object sender, EventArgs e)
        {
            // Ao sair, volta o menu ao normal
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.DefinirModoTelaCheia(false);
            }
        }

       
        

        private void PreencherDadosDoProduto(string codigo)
        {
        
            try
            {
                Produtos produtoDAO = new Produtos();
                Produtos produtoEncontrado = produtoDAO.Buscar(codigo);

                if (produtoEncontrado != null)
                {
                    _idProdutoAtual = produtoEncontrado.Id;
                    txt_NomeProd.Text = produtoEncontrado.Nome;
                    txt_CorProd.Text = produtoEncontrado.Cor;
                    txt_ValorUnitario.Text = produtoEncontrado.Valor.ToString("N2");
                    num_Quantidade.Value = 1;

                    if (produtoEncontrado.Foto != null && produtoEncontrado.Foto.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(produtoEncontrado.Foto))
                        {
                            pick_FotoProd.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pick_FotoProd.Image = null;
                    }

                    num_Quantidade.Focus();
                    num_Quantidade.Select(0, num_Quantidade.Value.ToString().Length);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimparCampos();
                    txt_CodigoProd.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados: " + ex.Message);
            }
        }

        // Método auxiliar para limpar a tela
        private void LimparCampos()
        {
            _idProdutoAtual = 0;
            txt_NomeProd.Clear();
            txt_CorProd.Clear();
            txt_ValorUnitario.Clear();
            pick_FotoProd.Image = null;
            num_Quantidade.Value = 0;
        }

        private void txt_CodigoProd_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi ENTER (o scanner envia um Enter no final)
            if (e.KeyCode == Keys.Enter)
            {
                // Remove o som de "bip" do Windows e previne quebra de linha
                e.SuppressKeyPress = true;

                string codigo = txt_CodigoProd.Text.Trim();

                if (!string.IsNullOrEmpty(codigo))
                {
                    PreencherDadosDoProduto(codigo);
                }
            }
        }
        
        private void btn_AdicionarItem_Click(object sender, EventArgs e)
        {
            // Variável global na classe para controlar o total da venda


            // 1. Validação (Guard Clause)
            if (!CamposEstaoValidos())
            {
                MessageBox.Show("Preencha o produto e a quantidade corretamente.", "Atenção");
                return;
            }

            // 2. Coleta os dados
            string nome = txt_NomeProd.Text;
            string cor = txt_CorProd.Text;
            decimal valorUnitario = Convert.ToDecimal(txt_ValorUnitario.Text);
            int quantidade = (int)num_Quantidade.Value;

            // Calcula o subtotal deste item
            decimal totalItem = valorUnitario * quantidade;
            
            


            // 3. ADICIONA NO GRID E GUARDA O ID NA TAG
            // Pega o índice da linha que acabou de ser criada
            int indexLinha = dgv_Carrinho.Rows.Add(nome, cor, valorUnitario, quantidade, totalItem);
            dgv_Carrinho.Rows[indexLinha].Tag = _idProdutoAtual;
            // 4. Atualiza o Total Geral da Venda
            AtualizarTotalVenda(totalItem);
            //Logica para calcular o valor total da compra

            

            // 5. Limpa para o próximo item
            LimparCamposAposAdicionar();
          
        }

        // --- MÉTODOS AUXILIARES (CLEAN CODE) ---

        private bool CamposEstaoValidos()
        {
            // Verifica se tem nome e se a quantidade é maior que zero
            return !string.IsNullOrEmpty(txt_NomeProd.Text) && num_Quantidade.Value > 0;
        }

        private void AtualizarTotalVenda(decimal valorItem)
        {
            _valorTotalVenda += valorItem;
            // Supondo que você tenha um Label grande mostrando o total (lblTotalVenda)
            txt_ValorFinal.Text = _valorTotalVenda.ToString("C2"); // Formata como R$
        }

        private void LimparCamposAposAdicionar()
        {
            txt_CodigoProd.Clear();
            txt_NomeProd.Clear();
            txt_CorProd.Clear();
            txt_ValorUnitario.Clear();
            num_Quantidade.Value = 0;
            pick_FotoProd.Image = null;

            // Joga o foco de volta para o código de barras para bipar o próximo rapido
            txt_CodigoProd.Focus();
        }

        private void btn_LimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void txt_ValorFinal_TextChanged(object sender, EventArgs e)
        {
            txt_ValorFinal.Text = _valorTotalVenda.ToString("N2");
        }

        private void btn_ExcluirItemCarrinho_Click(object sender, EventArgs e)
        {
            dgv_Carrinho.Rows.RemoveAt(dgv_Carrinho.CurrentRow.Index);
            RecalcularTotalVenda();


        }

        private void Btn_AlterarItem_Click(object sender, EventArgs e)
        {
            // Logica para alterar apenas a quantidade do item selecionado no carrinho
            if (dgv_Carrinho.CurrentRow != null)
            {
                // Pega a linha selecionada
                DataGridViewRow linhaSelecionada = dgv_Carrinho.CurrentRow;
                // Pega a nova quantidade do campo numérico
                int novaQuantidade = (int)num_Quantidade.Value;
                if (novaQuantidade > 0)
                {
                    // Atualiza a quantidade na linha selecionada
                    linhaSelecionada.Cells["Quantidade"].Value = novaQuantidade;
                    // Recalcula o total do item
                    decimal valorUnitario = Convert.ToDecimal(linhaSelecionada.Cells["ValorUnitario"].Value);
                    decimal novoTotalItem = valorUnitario * novaQuantidade;
                    linhaSelecionada.Cells["TotalItem"].Value = novoTotalItem;
                    // Recalcula o total geral da venda
                    RecalcularTotalVenda();
                }
                else
                {
                    MessageBox.Show("A quantidade deve ser maior que zero.", "Atenção");
                }
            }
           
        }
        private void RecalcularTotalVenda()
        {
            _valorTotalVenda = 0;
            foreach (DataGridViewRow row in dgv_Carrinho.Rows)
            {
                decimal totalItem = Convert.ToDecimal(row.Cells["TotalItem"].Value);
                _valorTotalVenda += totalItem;
            }
            txt_ValorFinal.Text = _valorTotalVenda.ToString("N2");
        }

        private void btn_FinalizarVenda_Click(object sender, EventArgs e)
        {
            // 1. Validação básica
            if (dgv_Carrinho.Rows.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!");
                return;
            }

            try
            {
                // 2. Criar Lista de Itens para passar para a próxima tela
                List<ItemVenda> listaDeItens = new List<ItemVenda>();

                foreach (DataGridViewRow row in dgv_Carrinho.Rows)
                {
                    if (row.IsNewRow) continue; // Ignora a linha em branco do grid
                    if (row.Cells["Nome"].Value == null) continue; // Proteção extra

                    ItemVenda item = new ItemVenda();

                    // Pega o ID que guardamos escondido na Tag
                    if (row.Tag != null)
                        item.IdProduto = Convert.ToInt32(row.Tag);
                    else
                    {
                        MessageBox.Show($"Produto {row.Cells["Nome"].Value} está sem ID. Remova e adicione novamente.");
                        return;
                    }

                    // Preenche os dados visuais (para o Cupom)
                    item.NomeProduto = row.Cells["Nome"].Value.ToString();
                    item.Cor = row.Cells["Cor"].Value != null ? row.Cells["Cor"].Value.ToString() : "";

                    // Preenche os dados numéricos (para o Banco e Cálculo)
                    item.ValorUnitario = Convert.ToDecimal(row.Cells["ValorUnitario"].Value);
                    item.Quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    // OBS: NÃO colocamos item.Subtotal = ... aqui.
                    // A classe ItemVenda já calcula sozinha (Qtd * Valor).

                    listaDeItens.Add(item);
                }

                // 3. Chamar a Tela de Pagamento
                // Passamos o valor total e a lista de itens preenchida
                

                // Exibir a tela no formulário principal
                var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
                if (formPrincipal != null)
                {
                    formPrincipal.RenderizarControl(new UC_Pagamento(_valorTotalVenda, listaDeItens, _clienteParaImpressao));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar itens: " + ex.Message);
            }
        }

        private void btn_CadastraCLiente_Click(object sender, EventArgs e)
        {

            CadastroCliente telaCadastroCliente = new CadastroCliente();
            // Exibir a tela no formulário principal
            var formPrincipal = Application.OpenForms.OfType<Principla>().FirstOrDefault();
            if (formPrincipal != null)
            {
                formPrincipal.RenderizarControl(telaCadastroCliente);
            }

        }

        private void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            // 1. Pega o texto digitado e remove espaços das pontas
            string termoDigitado = txt_BuscaCliente.Text.Trim();

            // Validação básica
            if (string.IsNullOrEmpty(termoDigitado))
            {
                MessageBox.Show("Por favor, digite um Nome ou CPF.");
                return;
            }

            try
            {
                // Instancia a classe Cliente (que herda aquele método lá de cima)
                Cliente clienteService = new Cliente();

                // --- AQUI ESTÁ A CHAMADA CORRETA ---
                // Passamos apenas a variável 'termoDigitado'. 
                // O banco que se vire para decidir se parece nome ou CPF.
                // Precisamos fazer o cast (Cliente) porque o método retorna um 'Usuario' genérico.
                Cliente resultado = (Cliente)clienteService.BuscarPorNomeOuCPF(termoDigitado);


                if (resultado != null && resultado.Id > 0)
                {
                    // === SUCESSO: CLIENTE ENCONTRADO ===

                    // AQUI VOCÊ GUARDA O RESULTADO NA VARIÁVEL OCULTA
                    _clienteParaImpressao = resultado;

                    MessageBox.Show($"Cliente encontrado: {resultado.Nome}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Opcional: limpar o campo de busca
                    // txt_BuscaCliente.Clear();
                }
                else
                {
                    // === NÃO ENCONTRADO ===
                    _clienteParaImpressao = null; // Garante que está nulo
                    MessageBox.Show("Nenhum cliente encontrado com esses dados.");
                    txt_BuscaCliente.SelectAll();
                    txt_BuscaCliente.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}






