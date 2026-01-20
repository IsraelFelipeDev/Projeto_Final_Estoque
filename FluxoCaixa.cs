using System;
using MySql.Data.MySqlClient; // Certifique-se de ter esta biblioteca
using System.Data;

namespace Projeto_FinalOficial.Modelos
{
    public class FluxoCaixa
    {
    

        public int ID { get; set; }
        public DateTime DataAbertura { get; set; }

        // O "?" significa que aceita NULO (pois ao abrir, ainda não tem data de fechamento)
        public DateTime? DataFechamento { get; set; }

        public decimal ValorInicial { get; set; } // Fundo de Troco
        public decimal? ValorFinal { get; set; }   // Valor contado na mão (Gaveta)
        public decimal? TotalVendasSistema { get; set; } // Valor que o sistema calculou

        public string UsuarioResponsavel { get; set; }
        public string GerenteLiberacao { get; set; }
        public string Status { get; set; } // "Aberto" ou "Fechado"

        // Variável de conexão (Ajuste para puxar da sua classe de Conexão se tiver uma)
        private readonly string _Conexao = Conexao.ConexãoServidor; 
        // --- MÉTODOS ---

        // 1. ABRIR CAIXA (Retorna o ID gerado)
        public int AbrirCaixa()
        {
            int idGerado = 0;

            using (MySqlConnection conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                // O comando SQL insere e logo depois pede o ID gerado (SELECT LAST_INSERT_ID())
                string sql = @"INSERT INTO PDV_Caixa 
                               (DataAbertura, ValorInicial, UsuarioResponsavel, GerenteLiberacao, StatusCaixa) 
                               VALUES 
                               (NOW(), @ValorInicial, @UsuarioResponsavel, @GerenteLiberacao, 'Aberto');
                               
                               SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ValorInicial", this.ValorInicial);
                    cmd.Parameters.AddWithValue("@UsuarioResponsavel", this.UsuarioResponsavel);
                   cmd.Parameters.AddWithValue("@DataAbertura", this.DataAbertura);
                    // Se não tiver gerente (null), gravamos DBNull no banco
                    if (string.IsNullOrEmpty(this.GerenteLiberacao))
                        cmd.Parameters.AddWithValue("@GerenteLiberacao", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@GerenteLiberacao", this.GerenteLiberacao);

                    // ExecuteScalar executa o INSERT e retorna o resultado do SELECT LAST_INSERT_ID()
                    // Convertemos para int para usar no programa
                    idGerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return idGerado; // Retorna, por exemplo, 540
        }

        // 2. BUSCAR TOTAL VENDIDO (Para saber quanto o sistema acusa)
        public decimal BuscarTotalVendasSistema(int idCaixa)
        {
            decimal total = 0;

            using (MySqlConnection conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();
                // Soma todas as vendas vinculadas a este ID de caixa
                string sql = "SELECT IFNULL(SUM(ValorTotal), 0) FROM Vendas WHERE ID_FluxoCaixa = @ID";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", idCaixa);
                    total = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return total;
        }

        // 3. FECHAR CAIXA (Atualiza com os valores finais)
        public void FecharCaixa(int idCaixa, decimal valorNaGaveta, decimal totalSistema)
        {
            using (MySqlConnection conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                string sql = @"UPDATE PDV_Caixa
                               SET DataFechamento = NOW(), 
                                   ValorFinal = @ValorFinal, 
                                   ValorTotalVendas = @TotalSistema, 
                                   StatusCaixa = 'Fechado'
                               WHERE ID = @ID";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ValorFinal", valorNaGaveta);
                    cmd.Parameters.AddWithValue("@TotalSistema", totalSistema);
                    cmd.Parameters.AddWithValue("@ID", idCaixa);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}