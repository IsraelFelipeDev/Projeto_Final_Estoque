using Projeto_FinalOficial.Servicos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Projeto_FinalOficial.ProdutoVariacao;

namespace Projeto_FinalOficial
{
    public partial class UC_FazerPedido : UserControl
    {
        // ============================================================================
        // 1. VARIÁVEIS GLOBAIS
        // ============================================================================
        // Inicializamos a lista aqui para NUNCA ser null (evita o erro fatal)
        private List<ItemTelaPedido> _itensNoCarrinho = new List<ItemTelaPedido>();

        private ServicoCotacaoInteligente _servicoCotacao;
        private CotacaoDAL _dal;

        // ============================================================================
        // 2. CONSTRUTORES
        // ============================================================================

        // Construtor Padrão (Vazio)
        public UC_FazerPedido()
        {
            InitializeComponent();
            InicializarTudo();
        }

        // Construtor 2: Recebe dados do ESTOQUE (ItemPedidoTransfer) e converte
        public UC_FazerPedido(List<ItemPedidoTransfer> itensDoEstoque)
        {
            InitializeComponent();
            InicializarTudo();

            if (itensDoEstoque != null)
            {
                foreach (var item in itensDoEstoque)
                {
                    // BUSCAR DADOS ATUALIZADOS DO BANCO
                    // Assumindo que seu DAL tem um método para pegar detalhes pelo ID
                    // Se não tiver, você pode usar o método de busca existente
                    var dadosProduto = _dal.BuscarProdutosParaAdicionar(item.NomeProduto)
                                           .AsEnumerable()
                                           .FirstOrDefault(r => (int)r["IdVariacao"] == item.IdVariacao);

                    int estAtual = 0, estMin = 0, estMax = 0;

                    if (dadosProduto != null)
                    {
                        estAtual = Convert.ToInt32(dadosProduto["EstoqueAtual"]);
                        estMin = Convert.ToInt32(dadosProduto["EstoqueMinimo"]);
                        estMax = Convert.ToInt32(dadosProduto["EstoqueMaximo"]);
                    }

                    _itensNoCarrinho.Add(new ItemTelaPedido
                    {
                        IdVariacao = item.IdVariacao,
                        NomeProduto = item.NomeProduto,
                        Quantidade = item.QtdSugestao,
                        // CORREÇÃO: Preenche com os dados reais
                        EstoqueAtual = estAtual,
                        EstoqueMinimo = estMin,
                        EstoqueMaximo = estMax
                    });
                }
            }
        }

        // Método auxiliar para iniciar serviços e configurações visuais
        private void InicializarTudo()
        {
            _servicoCotacao = new ServicoCotacaoInteligente();
            _dal = new CotacaoDAL();

            ConfigurarGridPrincipal();
            ConfigurarGridBusca();
        }

        // ============================================================================
        // 3. EVENTO LOAD (Carregamento da Tela)
        // ============================================================================
        private void UC_FazerPedido_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Se a lista tem itens (vinda do construtor), carrega no grid
                if (_itensNoCarrinho.Count > 0)
                {
                    CarregarGridPrincipalPelaLista();
                    MessageBox.Show($"{_itensNoCarrinho.Count} itens importados do estoque.", "Início do Pedido");
                }
                else
                {
                    pnlTopo.Visible = false; // Esconde o painel verde de resumo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a tela: " + ex.Message);
            }
        }

        // ============================================================================
        // 4. CONFIGURAÇÃO DOS GRIDS
        // ============================================================================
        private void ConfigurarGridPrincipal()
        {
            dgvItens.AutoGenerateColumns = false;
            dgvItens.Columns.Clear();
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItens.RowTemplate.Height = 40;
            dgvItens.DefaultCellStyle.Font = new Font("Segoe UI", 14F);

            // IMPORTANTE: Evita crash quando o ComboBox tenta desenhar um valor que não existe
            dgvItens.DataError += DgvItens_DataError;

            // --- Colunas ---
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdVariacao", Visible = false });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Produto",
                HeaderText = "Produto",
                ReadOnly = true,
                FillWeight = 200
            });

            var estiloCentro = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, BackColor = Color.LightGray };
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstAtual", HeaderText = "Atual", ReadOnly = true, DefaultCellStyle = estiloCentro, FillWeight = 40 });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstMin", HeaderText = "Min", ReadOnly = true, DefaultCellStyle = estiloCentro, FillWeight = 40 });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstMax", HeaderText = "Max", ReadOnly = true, DefaultCellStyle = estiloCentro, FillWeight = 40 });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qtd", HeaderText = "Qtd", FillWeight = 50 });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Frete",
                HeaderText = "Frete (R$)",
                ReadOnly = true,
                FillWeight = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Prazo",
                HeaderText = "Prazo (Dias)",
                ReadOnly = true,
                FillWeight = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            var colCombo = new DataGridViewComboBoxColumn();
            colCombo.Name = "cmbFornecedor";
            colCombo.HeaderText = "Fornecedor Selecionado";
            colCombo.FlatStyle = FlatStyle.Flat;
            colCombo.FillWeight = 200;
            dgvItens.Columns.Add(colCombo);
        }

        private void DgvItens_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void ConfigurarGridBusca()
        {
            dgvResultadosBusca.Visible = false;
            dgvResultadosBusca.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultadosBusca.AllowUserToAddRows = false;
            dgvResultadosBusca.RowHeadersVisible = false;
            dgvResultadosBusca.ReadOnly = true;
            dgvResultadosBusca.BackgroundColor = Color.WhiteSmoke;
            dgvResultadosBusca.CellDoubleClick += dgvResultadosBusca_CellDoubleClick;
        }

        // ============================================================================
        // 5. LÓGICA DE DADOS (CARREGAR GRID E COMBOS)
        // ============================================================================
        private void CarregarGridPrincipalPelaLista()
        {
            dgvItens.Rows.Clear();
            foreach (var item in _itensNoCarrinho)
            {
                int idx = dgvItens.Rows.Add();
                var row = dgvItens.Rows[idx];

                row.Cells["IdVariacao"].Value = item.IdVariacao;
                row.Cells["Produto"].Value = item.NomeProduto;
                row.Cells["EstAtual"].Value = item.EstoqueAtual;
                row.Cells["EstMin"].Value = item.EstoqueMinimo;
                row.Cells["EstMax"].Value = item.EstoqueMaximo;
                row.Cells["Qtd"].Value = item.Quantidade;

                CarregarComboDeFornecedoresDaLinha(row, item.IdVariacao);
            }
        }

        private void CarregarComboDeFornecedoresDaLinha(DataGridViewRow row, int idVariacao)
        {
            try
            {
                DataTable dtOfertas = _dal.BuscarOfertasParaLista(new List<int> { idVariacao });
                var listaOpcoes = new DataTable();
                listaOpcoes.Columns.Add("IdFornecedor", typeof(int));
                listaOpcoes.Columns.Add("TextoExibicao", typeof(string));

                if (dtOfertas.Rows.Count > 0)
                {
                    Random rnd = new Random();
                    foreach (DataRow dbRow in dtOfertas.Rows)
                    {
                        int idForn = Convert.ToInt32(dbRow["IdFornecedor"]);
                        string nome = dbRow["NomeFornecedor"].ToString();
                        decimal preco = 0;

                        if (dbRow["PrecoCustoTabela"] != DBNull.Value)
                        {
                            decimal precoBase = Convert.ToDecimal(dbRow["PrecoCustoTabela"]);
                            double fator = 0.85 + (rnd.NextDouble() * (1.15 - 0.85));
                            preco = precoBase * (decimal)fator;
                        }

                        string display = $"{nome} - {preco:C2}";
                        listaOpcoes.Rows.Add(idForn, display);
                    }
                }
                else
                {
                    listaOpcoes.Rows.Add(0, "(Sem fornecedores vinculados)");
                }

                var cellCombo = (DataGridViewComboBoxCell)row.Cells["cmbFornecedor"];
                cellCombo.DataSource = listaOpcoes;
                cellCombo.DisplayMember = "TextoExibicao";
                cellCombo.ValueMember = "IdFornecedor";
            }
            catch (Exception ex)
            {
                // Ignora erro visual silenciosamente ou loga se necessário
            }
        }

        // ============================================================================
        // 6. BUSCA MANUAL DE PRODUTOS
        // ============================================================================
        private void btn_BuscarProd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_BuscarProd.Text)) return;
            var dt = _dal.BuscarProdutosParaAdicionar(txt_BuscarProd.Text);
            dgvResultadosBusca.DataSource = dt;
            dgvResultadosBusca.Visible = (dt.Rows.Count > 0);
            if (dt.Rows.Count > 0) dgvResultadosBusca.BringToFront();
        }

        private void dgvResultadosBusca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvResultadosBusca.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["IdVariacao"].Value);

            if (_itensNoCarrinho.Any(x => x.IdVariacao == id))
            {
                MessageBox.Show("Já está na lista.");
                dgvResultadosBusca.Visible = false;
                return;
            }

            var novoItem = new ItemTelaPedido
            {
                IdVariacao = id,
                NomeProduto = row.Cells["NomeProduto"].Value.ToString(),
                EstoqueAtual = Convert.ToInt32(row.Cells["EstoqueAtual"].Value),
                EstoqueMinimo = Convert.ToInt32(row.Cells["EstoqueMinimo"].Value),
                EstoqueMaximo = Convert.ToInt32(row.Cells["EstoqueMaximo"].Value),
                Quantidade = 10
            };

            _itensNoCarrinho.Add(novoItem);

            int idx = dgvItens.Rows.Add();
            var gridRow = dgvItens.Rows[idx];
            gridRow.Cells["IdVariacao"].Value = novoItem.IdVariacao;
            gridRow.Cells["Produto"].Value = novoItem.NomeProduto;
            gridRow.Cells["EstAtual"].Value = novoItem.EstoqueAtual;
            gridRow.Cells["EstMin"].Value = novoItem.EstoqueMinimo;
            gridRow.Cells["EstMax"].Value = novoItem.EstoqueMaximo;
            gridRow.Cells["Qtd"].Value = novoItem.Quantidade;

            CarregarComboDeFornecedoresDaLinha(gridRow, novoItem.IdVariacao);

            dgvResultadosBusca.Visible = false;
            txt_BuscarProd.Text = "";
        }

        // ============================================================================
        // 7. COTAÇÃO INTELIGENTE
        // ============================================================================
        private void btnCalcularInteligencia_Click(object sender, EventArgs e)
        {
            SincronizarListaMemoria(); // Atualiza qtds editadas no grid para a lista

            if (_itensNoCarrinho.Count == 0) return;

            var necessidades = _itensNoCarrinho.Select(x => new ItemNecessidade
            {
                IdVariacao = x.IdVariacao,
                QtdNecessaria = x.Quantidade
            }).ToList();

            var cenarios = _servicoCotacao.GerarMelhoresCenarios(necessidades);

            if (cenarios.Count > 0)
            {
                var melhorCenario = cenarios.First();

                // Aplica a sugestão e recebe os totais calculados
                var (freteTotal, maiorPrazo) = AplicarSugestaoNoGrid(melhorCenario);

                // Atualiza Painel de Resumo
                pnlTopo.Visible = true;
                decimal custoProdutos = melhorCenario.CustoTotalGeral;
                decimal custoFinal = custoProdutos + freteTotal;

                lblResumo.Text = $"VENCEDOR: {melhorCenario.NomeFornecedor.ToUpper()}  |  " +
                                 $"PRODUTOS: {custoProdutos:C2}  |  " +
                                 $"FRETE: {freteTotal:C2}  |  " +
                                 $"TOTAL GERAL: {custoFinal:C2}  |  " +
                                 $"ENTREGA EM: {maiorPrazo} DIAS";
                pnlTopo.BackColor = Color.LightGreen;

                string explicacao = "Análise da Inteligência de Compras:\n\n" +
                                    $"O fornecedor '{melhorCenario.NomeFornecedor}' foi escolhido como a Melhor Opção.\n\n" +
                                    "CRITÉRIOS DA ESCOLHA:\n" +
                                    $"1. Disponibilidade: Ele possui todos os itens.\n" +
                                    $"2. Custo Total: {custoFinal:C2}.\n" +
                                    $"3. Agilidade: Entrega em {maiorPrazo} dias.\n\n" +
                                    "Deseja gerar o pedido agora?";

                MessageBox.Show(explicacao, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível encontrar uma cotação completa para todos os itens.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private (decimal freteTotal, int maiorPrazo) AplicarSugestaoNoGrid(CenarioCotacao cenario)
        {
            int maxPrazo = 0;
            int qtdTotalItensParaOFornecedor = 0;
            bool fornecedorFoiSelecionado = false;

            // 1. Aplica o fornecedor nas linhas e conta a quantidade total
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                var cellCombo = (DataGridViewComboBoxCell)row.Cells["cmbFornecedor"];
                if (cellCombo.Items.Count == 0) continue;

                int idVencedor = cenario.IdFornecedor;

                // Tenta selecionar o fornecedor no combo
                foreach (DataRowView item in cellCombo.Items)
                {
                    if (Convert.ToInt32(item["IdFornecedor"]) == idVencedor)
                    {
                        cellCombo.Value = idVencedor;
                        fornecedorFoiSelecionado = true;

                        // Estética: Limpa o frete individual da tela para não confundir
                        // Ou mostra um valor simbólico de "rateio"
                        row.Cells["Frete"].Value = 0;

                        // Prazo (Simulado)
                        int prazoItem = 13;
                        row.Cells["Prazo"].Value = prazoItem;
                        if (prazoItem > maxPrazo) maxPrazo = prazoItem;

                        // Soma quantidade para cálculo de frete por volume
                        int qtdLinha = Convert.ToInt32(row.Cells["Qtd"].Value);
                        qtdTotalItensParaOFornecedor += qtdLinha;

                        break;
                    }
                }
            }

            // 2. Calcula o Frete Realista (Apenas 1 vez por fornecedor)
            decimal freteTotal = 0;
            if (fornecedorFoiSelecionado)
            {
                decimal taxaFixaEntrega = 35.00m;       // Valor fixo do caminhão/correio
                decimal taxaPorUnidade = 0.10m;         // R$ 0,10 por peça (peso)

                freteTotal = taxaFixaEntrega + (qtdTotalItensParaOFornecedor * taxaPorUnidade);
            }

            return (freteTotal, maxPrazo);
        }
        private void SincronizarListaMemoria()
        {
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                // Pula linhas vazias ou inválidas
                if (row.Cells["IdVariacao"].Value == null) continue;

                int id = Convert.ToInt32(row.Cells["IdVariacao"].Value);

                // Tenta ler a quantidade editada pelo usuário
                int novaQtd = 0;
                if (row.Cells["Qtd"].Value != null)
                {
                    int.TryParse(row.Cells["Qtd"].Value.ToString(), out novaQtd);
                }

                // Busca o item na lista da memória e atualiza
                var itemMemoria = _itensNoCarrinho.FirstOrDefault(x => x.IdVariacao == id);
                if (itemMemoria != null)
                {
                    itemMemoria.Quantidade = novaQtd > 0 ? novaQtd : 1; // Garante mínimo de 1
                }
            }
        }

        // ============================================================================
        // 8. SALVAR E IMPRIMIR
        // ============================================================================
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            // 1. Garante que o que está no Grid reflete na lista em memória
            SincronizarListaMemoria();

            // Dicionários para agrupar os dados por Fornecedor
            // Chave = ID do Fornecedor
            var pedidosParaProcessar = new Dictionary<int, List<ItemPedidoFinal>>();
            var prazosPorFornecedor = new Dictionary<int, int>();
            var qtdTotalPorFornecedor = new Dictionary<int, int>(); // Novo: para cálculo de volume

            bool haItensParaSalvar = false;

            // =================================================================================
            // ETAPA 1: ITERAR O GRID E AGRUPAR ITENS POR FORNECEDOR
            // =================================================================================
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                // Validações básicas da linha
                if (row.Cells["cmbFornecedor"].Value == null) continue;

                int idForn = 0;
                if (!int.TryParse(row.Cells["cmbFornecedor"].Value.ToString(), out idForn) || idForn == 0)
                    continue;

                haItensParaSalvar = true;

                // Extração de dados da linha
                int idVariacao = Convert.ToInt32(row.Cells["IdVariacao"].Value);
                int quantidade = Convert.ToInt32(row.Cells["Qtd"].Value);
                string nomeProduto = row.Cells["Produto"].Value?.ToString() ?? "PRODUTO SEM NOME";

                // O prazo consideramos o maior entre os itens daquele fornecedor
                int prazoItem = row.Cells["Prazo"].Value != null ? Convert.ToInt32(row.Cells["Prazo"].Value) : 7;

                // Tenta extrair preço do texto do Combo (Ex: "Forn A - R$ 50,00")
                decimal precoCapturado = 0;
                var cellCombo = (DataGridViewComboBoxCell)row.Cells["cmbFornecedor"];
                string textoCombo = cellCombo.EditedFormattedValue?.ToString() ?? "";

                try
                {
                    if (textoCombo.Contains("R$"))
                    {
                        string valorString = textoCombo.Split(new[] { "R$" }, StringSplitOptions.None)[1].Trim();
                        decimal.TryParse(valorString, out precoCapturado);
                    }
                }
                catch { precoCapturado = 0; }

                // Inicializa as listas/contadores para este fornecedor se for a primeira vez que ele aparece
                if (!pedidosParaProcessar.ContainsKey(idForn))
                {
                    pedidosParaProcessar[idForn] = new List<ItemPedidoFinal>();
                    prazosPorFornecedor[idForn] = 0;
                    qtdTotalPorFornecedor[idForn] = 0;
                }

                // Adiciona o item à lista do fornecedor
                pedidosParaProcessar[idForn].Add(new ItemPedidoFinal
                {
                    IdVariacao = idVariacao,
                    Quantidade = quantidade,
                    PrecoUnitario = precoCapturado,
                    NomeProduto = nomeProduto
                });

                // Atualiza totais para cálculo posterior
                qtdTotalPorFornecedor[idForn] += quantidade;

                // Mantém o maior prazo (se um item demora 15 dias e outro 2, o pedido todo leva 15)
                if (prazoItem > prazosPorFornecedor[idForn])
                    prazosPorFornecedor[idForn] = prazoItem;
            }

            // =================================================================================
            // ETAPA 2: PROCESSAR, CALCULAR FRETE FINAL E SALVAR
            // =================================================================================
            if (haItensParaSalvar)
            {
                ImpressoraService impressora = new ImpressoraService();
                int contadorPedidos = 0;

                foreach (var idFornecedor in pedidosParaProcessar.Keys)
                {
                    var listaItens = pedidosParaProcessar[idFornecedor];
                    int prazoMaximo = prazosPorFornecedor[idFornecedor];
                    int totalItensVolume = qtdTotalPorFornecedor[idFornecedor];

                    // --- LÓGICA DE FRETE REALISTA ---
                    // Taxa fixa de entrega (ex: R$ 35,00) + R$ 0,10 por unidade de produto
                    decimal taxaFixa = 35.00m;
                    decimal taxaVariavel = totalItensVolume * 0.10m;
                    decimal valorFreteTotal = taxaFixa + taxaVariavel;
                    // --------------------------------

                    // Busca dados cadastrais do fornecedor para impressão
                    var dadosFornecedor = _dal.ObterFornecedorPorId(idFornecedor);

                    // Salva no banco de dados e recupera o ID do pedido gerado
                    int idNovoPedido = _dal.SalvarPedidoUnico(idFornecedor, listaItens, valorFreteTotal, prazoMaximo);

                    if (idNovoPedido > 0)
                    {
                        contadorPedidos++;

                        // Monta o objeto para impressão
                        var pedidoPrint = new PedidoCompraImpressao
                        {
                            IdPedido = idNovoPedido,
                            DataEmissao = DateTime.Now,
                            FornecedorNome = dadosFornecedor.Nome,
                            FornecedorCNPJ = dadosFornecedor.Cnpj,
                            FornecedorEndereco = dadosFornecedor.EnderecoCompleto,
                            LojaNome = "CRIMSON SUIT LTDA",
                            LojaCNPJ = "10.897.345/0001-00",
                            LojaEndereco = "Rua Rio de Janeiro, 473 - Centro - BH/MG",
                            ValorFrete = valorFreteTotal, // Aqui vai o frete único recalculado
                            PrazoEntregaDias = prazoMaximo
                        };

                        foreach (var item in listaItens)
                        {
                            pedidoPrint.Itens.Add(new ItemPedidoImpressao
                            {
                                Codigo = item.IdVariacao.ToString(),
                                Descricao = item.NomeProduto,
                                Quantidade = item.Quantidade,
                                ValorUnitario = item.PrecoUnitario,
                                Unidade = "UN"
                            });
                        }

                        // Pergunta se deseja imprimir
                        if (MessageBox.Show($"Pedido Nº {idNovoPedido} gerado para {dadosFornecedor.Nome}.\nValor Frete: {valorFreteTotal:C2}\nDeseja salvar o PDF?",
                            "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            impressora.ImprimirPedidoCompra(pedidoPrint);
                        }
                    }
                }

                MessageBox.Show($"Processo concluído! {contadorPedidos} pedidos gerados com sucesso.");

                // Limpa a tela após concluir
                dgvItens.Rows.Clear();
                _itensNoCarrinho.Clear();
                pnlTopo.Visible = false;
            }
            else
            {
                MessageBox.Show("Selecione fornecedores para os itens antes de salvar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}