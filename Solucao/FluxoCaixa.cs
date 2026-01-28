using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Projeto_FinalOficial.Modelos
{
    public class FluxoCaixa
    {
        // Propriedades
        public int ID { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal? ValorFinal { get; set; }
        public string UsuarioResponsavel { get; set; }
        public string GerenteLiberacao { get; set; }
        public string StatusCaixa { get; set; }

        // ⚠️ IMPORTANTE: Ajuste sua string de conexão aqui se não tiver a classe Conexao
        // Se você tiver a classe Conexao, mantenha: Conexao.ConexãoServidor
        //private readonly string _Conexao = Conexao.ConexãoServidor();
        private readonly string _Conexao = Conexao.ConexãoServidor;

        // --- MÉTODOS ---

        // 1. ABRIR CAIXA
        public int AbrirCaixa()
        {
            int idGerado = 0;

            using (MySqlConnection conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                string sql = @"INSERT INTO PDV_Caixa 
                               (DataAbertura, ValorInicial, UsuarioResponsavel, GerenteLiberacao, StatusCaixa) 
                               VALUES 
                               (NOW(), @ValorInicial, @UsuarioResponsavel, @GerenteLiberacao, 'Aberto');
                               
                               SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@ValorInicial", this.ValorInicial);
                    cmd.Parameters.AddWithValue("@UsuarioResponsavel", this.UsuarioResponsavel);

                    // Tratamento para Gerente (pode ser nulo na abertura se não precisar de senha)
                    if (string.IsNullOrEmpty(this.GerenteLiberacao))
                        cmd.Parameters.AddWithValue("@GerenteLiberacao", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@GerenteLiberacao", this.GerenteLiberacao);

                    idGerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return idGerado;
        }

        // 2. BUSCAR TOTAL VENDIDO (Soma das vendas para exibir na tela)
        public (decimal valorInicial, decimal totalVendas) ObterResumoFechamento(int idCaixa)
        {
            decimal vInicial = 0;
            decimal vVendas = 0;

            using (var conn = new MySqlConnection(_Conexao))
            {
                conn.Open();

                // Busca Valor Inicial e Soma das Vendas
                string sql = @"
                    SELECT 
                        c.ValorInicial, 
                        COALESCE(SUM(v.valor_total), 0) as TotalVendas
                    FROM PDV_Caixa c
                    LEFT JOIN Vendas v ON c.ID = v.ID_FluxoCaixa
                    WHERE c.ID = @id
                    GROUP BY c.ValorInicial";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idCaixa);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vInicial = reader.GetDecimal("ValorInicial");
                            vVendas = reader.GetDecimal("TotalVendas");
                        }
                    }
                }
            }
            return (vInicial, vVendas);
        }

        // 3. BUSCAR LISTA DE VENDAS (Para o Grid)
        public DataTable ObterVendasDoCaixa(int idCaixa)
        {
            DataTable dt = new DataTable();
            using (var conn = new MySqlConnection(_Conexao))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        id AS 'Cód.', 
                        data_venda AS 'Hora', 
                        forma_pagamento AS 'Pagamento', 
                        valor_total AS 'Valor'
                    FROM Vendas 
                    WHERE ID_FluxoCaixa = @id
                    ORDER BY data_venda DESC";

                using (var dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@id", idCaixa);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        // 4. FECHAR CAIXA
        public bool FecharCaixa(int idCaixa, decimal valorFinal, string nomeGerente)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_Conexao))
                {
                    conexao.Open();

                    // Removi 'ValorTotalVendas' pois não existe na sua tabela PDV_Caixa original
                    string sql = @"UPDATE PDV_Caixa
                                   SET DataFechamento = NOW(), 
                                       ValorFinal = @ValorFinal, 
                                       StatusCaixa = 'Fechado',
                                       GerenteLiberacao = @Gerente
                                   WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@ValorFinal", valorFinal);
                        cmd.Parameters.AddWithValue("@Gerente", nomeGerente);
                        cmd.Parameters.AddWithValue("@ID", idCaixa);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // É bom saber se deu erro
                Console.WriteLine("Erro ao fechar caixa: " + ex.Message);
                return false;
            }
        }
    }
}