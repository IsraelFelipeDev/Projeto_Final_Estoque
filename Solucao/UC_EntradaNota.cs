using System;
using System.Data;
using System.Windows.Forms;
using FontAwesome.Sharp; // Importante para os ícones
using System.Drawing;    // Importante para as Cores (Color)
using Projeto_FinalOficial.Properties; // Necessário para acessar as imagens nos Resources

namespace Projeto_FinalOficial
{
    public partial class UC_EntradaNota : UserControl
    {
        // Instância da classe que cuida do banco
        private PedidosCompraDAO _dao = new PedidosCompraDAO();
        private int _idPedidoSelecionado;

        public UC_EntradaNota()
        {
            InitializeComponent();
            ConfigurarGrids();
        }

        private void UC_EntradaNota_Load(object sender, EventArgs e)
        {
            MostrarTelaLista();
        }

        // ==========================================
        // MÉTODOS DE NAVEGAÇÃO
        // ==========================================

        private void MostrarTelaLista()
        {
            pnl_Conferencia.Visible = false;
            pnl_ListaPedidos.Visible = true;
            pnl_ListaPedidos.BringToFront();

            CarregarPedidosPendentes();
        }

        private void MostrarTelaConferencia(int idPedido)
        {
            _idPedidoSelecionado = idPedido;

            pnl_ListaPedidos.Visible = false;
            pnl_Conferencia.Visible = true;
            pnl_Conferencia.BringToFront();

            txt_Obs.Clear();
            CarregarItensDoPedido(_idPedidoSelecionado);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            MostrarTelaLista();
        }

        // ==========================================
        // PARTE 1: LÓGICA DA LISTA (GRID 1)
        // ==========================================

        private void ConfigurarGrids()
        {
            // =================================================================
            // GRID PEDIDOS (Mantém igual)
            // =================================================================
            dgvPedidos.AutoGenerateColumns = false;
            dgvPedidos.Columns.Clear();
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.RowHeadersVisible = false;

            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PedidoId",
                DataPropertyName = "PedidoId",
                HeaderText = "Nº Pedido",
                Width = 80
            });

            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fornecedor", DataPropertyName = "Fornecedor", HeaderText = "Fornecedor", Width = 200, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataPedido", DataPropertyName = "DataPedido", HeaderText = "Data", Width = 100 });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "ValorTotal", DataPropertyName = "ValorTotal", HeaderText = "Total", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status", Width = 100 });

            // Ícones do FontAwesome
            DataGridViewImageColumn btnPdf = new DataGridViewImageColumn();
            btnPdf.Name = "colPdf";
            btnPdf.HeaderText = "PDF";
            btnPdf.Image = IconChar.FilePdf.ToBitmap(Color.DarkRed, 24);
            btnPdf.ImageLayout = DataGridViewImageCellLayout.Zoom;
            btnPdf.Width = 50;
            dgvPedidos.Columns.Add(btnPdf);

            DataGridViewImageColumn btnDel = new DataGridViewImageColumn();
            btnDel.Name = "colExcluir";
            btnDel.HeaderText = "Excluir";
            btnDel.Image = IconChar.TrashAlt.ToBitmap(Color.Red, 24);
            btnDel.ImageLayout = DataGridViewImageCellLayout.Zoom;
            btnDel.Width = 50;
            dgvPedidos.Columns.Add(btnDel);

            // =================================================================
            // GRID ITENS (CONFERÊNCIA) - ALTERADO COM CORREÇÃO
            // =================================================================
            dgvItens.ReadOnly = false;
            dgvItens.AllowUserToAddRows = false;
            dgvItens.RowHeadersVisible = false;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.AutoGenerateColumns = false;
            dgvItens.Columns.Clear();

            // Colunas Ocultas
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "VariacaoId", // Já estava aqui, OK
                DataPropertyName = "VariacaoId",
                Visible = false
            });

            // === AQUI ESTAVAM FALTANDO OS NAMES ===

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Produto", // Adicionado
                DataPropertyName = "Produto",
                HeaderText = "Produto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EAN", // Adicionado
                DataPropertyName = "EAN",
                HeaderText = "EAN",
                Width = 120,
                ReadOnly = true
            });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Categoria", // Adicionado
                DataPropertyName = "Categoria",
                HeaderText = "Categoria",
                Width = 100,
                ReadOnly = true
            });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cor", // Adicionado
                DataPropertyName = "Cor",
                HeaderText = "Cor",
                Width = 80,
                ReadOnly = true
            });

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tamanho", // Adicionado
                DataPropertyName = "Tamanho",
                HeaderText = "Tam.",
                Width = 60,
                ReadOnly = true
            });

            // === O ERRO PRINCIPAL ERA AQUI EMBAIXO ===
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QtdComprada", // <--- OBRIGATÓRIO: Sem isso o código não acha a coluna para salvar
                DataPropertyName = "QtdComprada",
                HeaderText = "Qtd.",
                Width = 60,
                ReadOnly = true
            });

            // Coluna Checkbox (Já tinha Name, OK)
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "colConferido";
            colCheck.HeaderText = "OK?";
            colCheck.Width = 50;
            colCheck.ReadOnly = false;
            dgvItens.Columns.Add(colCheck);
        }

        private void CarregarPedidosPendentes()
        {
            try
            {
                // Chama a DAO e joga no Grid
                dgvPedidos.DataSource = _dao.ListarPedidosPendentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar pedidos: " + ex.Message);
            }
        }

        private void dgvPedidos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nomeColuna = dgvPedidos.Columns[e.ColumnIndex].Name;
            int idPedido = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["PedidoId"].Value);

            // Clicou no Ícone PDF?
            if (nomeColuna == "colPdf")
            {
                MessageBox.Show($"Visualizar PDF do Pedido {idPedido} (Implementar Relatório)");
            }
            // Clicou no Ícone Excluir?
            else if (nomeColuna == "colExcluir")
            {
                if (MessageBox.Show("Deseja cancelar esta compra e excluir o pedido?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _dao.ExcluirPedido(idPedido);
                        CarregarPedidosPendentes(); // Atualiza a lista
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir: " + ex.Message);
                    }
                }
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells["PedidoId"].Value);
                MostrarTelaConferencia(id);
            }
            else
            {
                MessageBox.Show("Selecione um pedido na lista.");
            }
        }

        // ==========================================
        // PARTE 2: LÓGICA DA CONFERÊNCIA (GRID 2)
        // ==========================================

        private void CarregarItensDoPedido(int id)
        {
            try
            {
                dgvItens.DataSource = _dao.ListarItensDoPedido(id);

                // Marca todos os itens como "Conferidos" por padrão
                foreach (DataGridViewRow row in dgvItens.Rows)
                {
                    row.Cells["colConferido"].Value = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens: " + ex.Message);
            }
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar entrada no estoque?", "Recebimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RealizarTransacaoBanco();
            }
        }

        private void RealizarTransacaoBanco()
        {
            try
            {
                // Cria uma tabela temporária apenas com os itens CONFERIDOS (Marcados)
                DataTable dtItensConferidos = new DataTable();
                dtItensConferidos.Columns.Add("VariacaoId", typeof(int));
                dtItensConferidos.Columns.Add("QtdComprada", typeof(int));

                bool houveItemRejeitado = false;

                foreach (DataGridViewRow row in dgvItens.Rows)
                {
                    // Verifica se está marcado
                    bool isConferido = Convert.ToBoolean(row.Cells["colConferido"].Value);

                    if (isConferido)
                    {
                        // Adiciona na lista para salvar
                        dtItensConferidos.Rows.Add(
                            row.Cells["VariacaoId"].Value,
                            row.Cells["QtdComprada"].Value
                        );
                    }
                    else
                    {
                        houveItemRejeitado = true;
                    }
                }

                if (dtItensConferidos.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum item foi marcado como conferido! A entrada não pode ser vazia.");
                    return;
                }

                // Adiciona um aviso na observação se houve rejeição
                string obsFinal = txt_Obs.Text;
                if (houveItemRejeitado)
                {
                    obsFinal += " [ATENÇÃO: Houve itens rejeitados/não recebidos nesta conferência]";
                }

                // Envia para a DAO apenas os itens filtrados
                _dao.ConfirmarEntradaEstoque(_idPedidoSelecionado, obsFinal, dtItensConferidos);

                MessageBox.Show("Entrada realizada com sucesso!");
                MostrarTelaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro crítico na entrada: " + ex.Message);
            }
        }


    }
}