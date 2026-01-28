using Projeto_FinalOficial.Modelos; // Ajuste conforme seus namespaces reais
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
        private List<ItemTelaPedido> _itensNoCarrinho = new List<ItemTelaPedido>();
        private ServicoCotacaoInteligente _servicoCotacao;
        private CotacaoDAL _dal;

        // ============================================================================
        // 2. CONSTRUTORES
        // ============================================================================

        public UC_FazerPedido()
        {
            InitializeComponent();
            InicializarTudo();
        }

        // Construtor que recebe dados vindos do Estoque
        public UC_FazerPedido(List<ItemPedidoTransfer> itensDoEstoque)
        {
            InitializeComponent();
            InicializarTudo();

            if (itensDoEstoque != null)
            {
                foreach (var item in itensDoEstoque)
                {
                    // Busca dados atualizados do banco para garantir consistência
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
                        EstoqueAtual = estAtual,
                        EstoqueMinimo = estMin,
                        EstoqueMaximo = estMax
                    });
                }
            }
        }

        private void InicializarTudo()
        {
            _servicoCotacao = new ServicoCotacaoInteligente();
            _dal = new CotacaoDAL();

            ConfigurarGridPrincipal();
            ConfigurarGridBusca();
        }

        // ============================================================================
        // 3. EVENTO LOAD
        // ============================================================================
        private void UC_FazerPedido_Load_1(object sender, EventArgs e)
        {
            try
            {
                if (_itensNoCarrinho.Count > 0)
                {
                    CarregarGridPrincipalPelaLista();
                    MessageBox.Show($"{_itensNoCarrinho.Count} itens importados do estoque.", "Início do Pedido");
                }
                else
                {
                    pnlTopo.Visible = false; // Esconde o painel de resumo
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
            dgvItens.DefaultCellStyle.Font = new Font("Segoe UI", 12F); // Fonte ajustada

            // Evita crash de DataError em Combos
            dgvItens.DataError += (s, e) => { e.Cancel = true; };

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

            // Coluna Frete (ReadOnly para exibir o cálculo rateado)
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Frete",
                HeaderText = "Frete (Rateio)",
                ReadOnly = true,
                FillWeight = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight, ForeColor = Color.DarkBlue }
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
        // 5. CARREGAMENTO DE DADOS (GRIDS E COMBOS)
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
                row.Cells["Frete"].Value = 0; // Inicia zerado

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
                    Random rnd = new Random(); // Simulação de variação de preço (Remover em produção se tiver preço real)
                    foreach (DataRow dbRow in dtOfertas.Rows)
                    {
                        int idForn = Convert.ToInt32(dbRow["IdFornecedor"]);
                        string nome = dbRow["NomeFornecedor"].ToString();
                        decimal preco = 0;

                        if (dbRow["PrecoCustoTabela"] != DBNull.Value)
                        {
                            decimal precoBase = Convert.ToDecimal(dbRow["PrecoCustoTabela"]);
                            // Apenas simulando uma variação para testes, usar valor real do banco
                            double fator = 0.95 + (rnd.NextDouble() * 0.10);
                            preco = precoBase * (decimal)fator;
                        }

                        string display = $"{nome} - {preco:C2}";
                        listaOpcoes.Rows.Add(idForn, display);
                    }
                }
                else
                {
                    listaOpcoes.Rows.Add(0, "(Sem fornecedores)");
                }

                var cellCombo = (DataGridViewComboBoxCell)row.Cells["cmbFornecedor"];
                cellCombo.DataSource = listaOpcoes;
                cellCombo.DisplayMember = "TextoExibicao";
                cellCombo.ValueMember = "IdFornecedor";
            }
            catch
            {
                // Log de erro opcional
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
                MessageBox.Show("Este item já está na lista.");
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
                Quantidade = 10 // Qtd Padrão
            };

            _itensNoCarrinho.Add(novoItem);

            // Adiciona visualmente ao grid
            int idx = dgvItens.Rows.Add();
            var gridRow = dgvItens.Rows[idx];
            gridRow.Cells["IdVariacao"].Value = novoItem.IdVariacao;
            gridRow.Cells["Produto"].Value = novoItem.NomeProduto;
            gridRow.Cells["EstAtual"].Value = novoItem.EstoqueAtual;
            gridRow.Cells["EstMin"].Value = novoItem.EstoqueMinimo;
            gridRow.Cells["EstMax"].Value = novoItem.EstoqueMaximo;
            gridRow.Cells["Qtd"].Value = novoItem.Quantidade;
            gridRow.Cells["Frete"].Value = 0;

            CarregarComboDeFornecedoresDaLinha(gridRow, novoItem.IdVariacao);

            dgvResultadosBusca.Visible = false;
            txt_BuscarProd.Text = "";
        }

        // ============================================================================
        // 7. COTAÇÃO INTELIGENTE (COM CORREÇÃO DE FRETE VISUAL)
        // ============================================================================
        private void btnCalcularInteligencia_Click(object sender, EventArgs e)
        {
            SincronizarListaMemoria();

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

                // APLICA O RESULTADO NO GRID COM O RATEIO CORRETO
                var (freteTotalReal, maiorPrazo) = AplicarSugestaoNoGrid(melhorCenario);

                // Atualiza Painel de Resumo
                pnlTopo.Visible = true;
                decimal custoProdutos = melhorCenario.CustoTotalGeral;
                decimal custoFinal = custoProdutos + freteTotalReal;

                lblResumo.Text = $"VENCEDOR: {melhorCenario.NomeFornecedor.ToUpper()}  |  " +
                                 $"PRODUTOS: {custoProdutos:C2}  |  " +
                                 $"FRETE TOTAL: {freteTotalReal:C2}  |  " +
                                 $"TOTAL GERAL: {custoFinal:C2}  |  " +
                                 $"ENTREGA: {maiorPrazo} DIAS";
                pnlTopo.BackColor = Color.LightGreen;

                MessageBox.Show($"O fornecedor '{melhorCenario.NomeFornecedor}' venceu a cotação.\n" +
                                $"Valor Total: {custoFinal:C2} (Produtos + Frete)\n" +
                                $"O valor do frete foi rateado visualmente entre os itens.",
                                "Inteligência de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível encontrar uma cotação completa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Aplica o fornecedor vencedor e calcula o frete rateado por item
        /// </summary>
        private (decimal freteTotalReal, int maiorPrazo) AplicarSugestaoNoGrid(CenarioCotacao cenario)
        {
            int idVencedor = cenario.IdFornecedor;
            int maxPrazo = 0;
            int qtdTotalParaOFornecedor = 0;

            // PASSO 1: Calcular o volume TOTAL para este fornecedor (para saber o divisor do rateio)
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                var cellCombo = (DataGridViewComboBoxCell)row.Cells["cmbFornecedor"];
                bool fornecedorExisteNoItem = false;

                // Verifica se o fornecedor vencedor existe na lista de opções deste produto
                foreach (DataRowView item in cellCombo.Items)
                {
                    if (Convert.ToInt32(item["IdFornecedor"]) == idVencedor)
                    {
                        fornecedorExisteNoItem = true;
                        break;
                    }
                }

                if (fornecedorExisteNoItem)
                {
                    if (row.Cells["Qtd"].Value != null)
                    {
                        qtdTotalParaOFornecedor += Convert.ToInt32(row.Cells["Qtd"].Value);
                    }
                }
            }

            if (qtdTotalParaOFornecedor == 0) return (0, 0);

            // PASSO 2: Calcular o Valor Real do Frete (Regra de Negócio)
            decimal taxaFixaEntrega = 35.00m;
            decimal taxaPorUnidade = 0.10m;
            decimal freteTotalReal = taxaFixaEntrega + (qtdTotalParaOFornecedor * taxaPorUnidade);

            // PASSO 3: Preencher o Grid aplicando o Rateio Proporcional
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                var cellCombo = (DataGridViewComboBoxCell)row.Cells["cmbFornecedor"];

                foreach (DataRowView item in cellCombo.Items)
                {
                    if (Convert.ToInt32(item["IdFornecedor"]) == idVencedor)
                    {
                        cellCombo.Value = idVencedor; // Seleciona o fornecedor

                        int qtdItem = Convert.ToInt32(row.Cells["Qtd"].Value);

                        // FÓRMULA DO RATEIO: (QtdItem / QtdTotal) * FreteTotal
                        decimal freteDesteItem = 0;
                        if (qtdTotalParaOFornecedor > 0)
                        {
                            freteDesteItem = (decimal)qtdItem / qtdTotalParaOFornecedor * freteTotalReal;
                        }

                        row.Cells["Frete"].Value = freteDesteItem; // Exibe o valor fracionado

                        // Prazo Simulado
                        int prazoItem = 13;
                        row.Cells["Prazo"].Value = prazoItem;
                        if (prazoItem > maxPrazo) maxPrazo = prazoItem;

                        break;
                    }
                }
            }

            return (freteTotalReal, maxPrazo);
        }

        private void SincronizarListaMemoria()
        {
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.Cells["IdVariacao"].Value == null) continue;
                int id = Convert.ToInt32(row.Cells["IdVariacao"].Value);

                int novaQtd = 0;
                if (row.Cells["Qtd"].Value != null)
                {
                    int.TryParse(row.Cells["Qtd"].Value.ToString(), out novaQtd);
                }

                var itemMemoria = _itensNoCarrinho.FirstOrDefault(x => x.IdVariacao == id);
                if (itemMemoria != null)
                {
                    itemMemoria.Quantidade = novaQtd > 0 ? novaQtd : 1;
                }
            }
        }

        // ============================================================================
        // 8. SALVAR E IMPRIMIR
        // ============================================================================
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            SincronizarListaMemoria();

            // Dicionários para agrupar os dados por Fornecedor
            var pedidosParaProcessar = new Dictionary<int, List<ItemPedidoFinal>>();
            var prazosPorFornecedor = new Dictionary<int, int>();
            var qtdTotalPorFornecedor = new Dictionary<int, int>();

            bool haItensParaSalvar = false;

            // ETAPA 1: AGRUPAMENTO
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.Cells["cmbFornecedor"].Value == null) continue;

                int idForn = 0;
                if (!int.TryParse(row.Cells["cmbFornecedor"].Value.ToString(), out idForn) || idForn == 0)
                    continue;

                haItensParaSalvar = true;

                int idVariacao = Convert.ToInt32(row.Cells["IdVariacao"].Value);
                int quantidade = Convert.ToInt32(row.Cells["Qtd"].Value);
                string nomeProduto = row.Cells["Produto"].Value?.ToString() ?? "PRODUTO";
                int prazoItem = row.Cells["Prazo"].Value != null ? Convert.ToInt32(row.Cells["Prazo"].Value) : 7;

                // Captura preço do texto do combo
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

                if (!pedidosParaProcessar.ContainsKey(idForn))
                {
                    pedidosParaProcessar[idForn] = new List<ItemPedidoFinal>();
                    prazosPorFornecedor[idForn] = 0;
                    qtdTotalPorFornecedor[idForn] = 0;
                }

                pedidosParaProcessar[idForn].Add(new ItemPedidoFinal
                {
                    IdVariacao = idVariacao,
                    Quantidade = quantidade,
                    PrecoUnitario = precoCapturado,
                    NomeProduto = nomeProduto
                });

                qtdTotalPorFornecedor[idForn] += quantidade;

                if (prazoItem > prazosPorFornecedor[idForn])
                    prazosPorFornecedor[idForn] = prazoItem;
            }

            // ETAPA 2: GERAÇÃO DOS PEDIDOS
            if (haItensParaSalvar)
            {
                ImpressoraService impressora = new ImpressoraService();
                int contadorPedidos = 0;

                foreach (var idFornecedor in pedidosParaProcessar.Keys)
                {
                    var listaItens = pedidosParaProcessar[idFornecedor];
                    int prazoMaximo = prazosPorFornecedor[idFornecedor];
                    int totalItensVolume = qtdTotalPorFornecedor[idFornecedor];

                    // Recalcula o Frete Total Oficial para Salvar no Banco (Garante precisão)
                    decimal taxaFixa = 35.00m;
                    decimal taxaVariavel = totalItensVolume * 0.10m;
                    decimal valorFreteTotal = taxaFixa + taxaVariavel;

                    var dadosFornecedor = _dal.ObterFornecedorPorId(idFornecedor);

                    int idNovoPedido = _dal.SalvarPedidoUnico(idFornecedor, listaItens, valorFreteTotal, prazoMaximo);

                    if (idNovoPedido > 0)
                    {
                        contadorPedidos++;

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
                            ValorFrete = valorFreteTotal,
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

                        if (MessageBox.Show($"Pedido Nº {idNovoPedido} gerado para {dadosFornecedor.Nome}.\nValor Frete: {valorFreteTotal:C2}\nDeseja salvar o PDF?",
                            "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            impressora.ImprimirPedidoCompra(pedidoPrint);
                        }
                    }
                }

                MessageBox.Show($"Processo concluído! {contadorPedidos} pedidos gerados.");
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