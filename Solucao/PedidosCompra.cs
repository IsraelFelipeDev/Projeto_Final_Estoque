using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Projeto_FinalOficial
{
    public class PedidosCompraDAO
    {
        // 1. LISTAR PEDIDOS PENDENTES
        public DataTable ListarPedidosPendentes()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conn.Open();
                string sql = "SELECT * FROM vw_PedidosPendentes ORDER BY DataPedido DESC";

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // 2. LISTAR ITENS DO PEDIDO
        public DataTable ListarItensDoPedido(int idPedido)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conn.Open();
                string sql = "SELECT * FROM vw_ItensRecebimento WHERE PedidoId = @id";

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", idPedido);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // 3. EXCLUIR PEDIDO
        public void ExcluirPedido(int idPedido)
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conn.Open();
                string sql = "DELETE FROM PedidosCompra WHERE Id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idPedido);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. CONFIRMAR ENTRADA (TRANSAÇÃO)
        public void ConfirmarEntradaEstoque(int idPedido, string observacao, DataTable itensParaEntrada)
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction(); // Inicia segurança

                try
                {
                    // A. Muda status do pedido
                    string sqlPedido = @"UPDATE PedidosCompra 
                                         SET Status = 'Recebido', 
                                             Observacoes = CONCAT(IFNULL(Observacoes,''), ' | Recebido: ', @obs) 
                                         WHERE Id = @pid";

                    using (MySqlCommand cmd = new MySqlCommand(sqlPedido, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid", idPedido);
                        cmd.Parameters.AddWithValue("@obs", observacao);
                        cmd.ExecuteNonQuery();
                    }

                    // B. Atualiza Estoque item a item
                    string sqlEstoque = @"UPDATE Produtos_Variacoes 
                                          SET QtdAtual = QtdAtual + @qtd 
                                          WHERE Id = @vid";

                    foreach (DataRow row in itensParaEntrada.Rows)
                    {
                        int variacaoId = Convert.ToInt32(row["VariacaoId"]);
                        int qtdComprada = Convert.ToInt32(row["QtdComprada"]);

                        using (MySqlCommand cmdEst = new MySqlCommand(sqlEstoque, conn, transaction))
                        {
                            cmdEst.Parameters.AddWithValue("@qtd", qtdComprada);
                            cmdEst.Parameters.AddWithValue("@vid", variacaoId);
                            cmdEst.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit(); // Salva tudo
                }
                catch
                {
                    transaction.Rollback(); // Desfaz tudo se der erro
                    throw; // Joga o erro para o Form avisar o usuário
                }
            }
        }
    }
}