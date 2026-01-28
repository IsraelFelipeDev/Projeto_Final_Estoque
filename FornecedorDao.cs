using MySql.Data.MySqlClient;
using Projeto_FinalOficial.Modelos; // Certifique-se que o namespace do modelo está aqui
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Projeto_FinalOficial
{
    // 1. HERANÇA: Agora FinanceiroDAL herda tudo de Service
    public class FinanceiroDAL : Service
    {
        // =========================================================================
        // MÉTODO 1: Preencher o ComboBox de Fornecedores
        // =========================================================================
        public DataTable ListarFornecedoresCombo()
        {
            string sql = "SELECT Id, NomeFantasia FROM Fornecedores ORDER BY NomeFantasia";

            // Usa o método da Service que já retorna o DataTable pronto
            return ExecutarConsultaDataTable(sql);
        }

        // =========================================================================
        // MÉTODO 2: Cadastrar a Conta (Insert)
        // =========================================================================
        public void CadastrarConta(ContaPagar conta)
        {
            string sql = @"INSERT INTO ContasPagar 
                          (Descricao, Categoria, FornecedorId, FavorecidoAvulso, Valor, DataVencimento, Observacoes) 
                          VALUES 
                          (@desc, @cat, @fornId, @favorecido, @valor, @venc, @obs)";

            // Na classe Service, usamos Dictionary para passar parâmetros
            var parametros = new Dictionary<string, object>();

            parametros.Add("@desc", conta.Descricao);
            parametros.Add("@cat", conta.Categoria);
            parametros.Add("@valor", conta.Valor);
            parametros.Add("@venc", conta.DataVencimento);
            parametros.Add("@obs", conta.Observacoes ?? ""); // Trata nulo com string vazia

            // Lógica para nulos (Service já converte null para DBNull.Value, mas é bom ser explícito na lógica)
            if (conta.FornecedorId != null && conta.FornecedorId > 0)
            {
                parametros.Add("@fornId", conta.FornecedorId);
            }
            else
            {
                parametros.Add("@fornId", null);
            }

            if (!string.IsNullOrEmpty(conta.FavorecidoAvulso))
            {
                parametros.Add("@favorecido", conta.FavorecidoAvulso);
            }
            else
            {
                parametros.Add("@favorecido", null);
            }

            // Executa usando o método da Service
            bool sucesso = ExecutarComando(sql, parametros);

            if (!sucesso)
            {
                throw new Exception("Falha ao inserir o registro no banco de dados.");
            }
        }

        // =========================================================================
        // MÉTODO 3: Listar Contas para o Grid (NOVO - Para a Tela Principal)
        // =========================================================================
        // Este método recupera os dados para preencher o DataGridView
        public List<ContaPagar> ListarContas(string filtroStatus = "Todos")
        {
            // SQL Inteligente com COALESCE para pegar o nome certo (Fornecedor ou Avulso)
            string sql = @"
                SELECT 
                    cp.Id, 
                    cp.Descricao, 
                    cp.Categoria,
                    cp.Valor, 
                    cp.DataVencimento, 
                    cp.DataPagamento, 
                    cp.FavorecidoAvulso,
                    cp.FornecedorId,
                    f.NomeFantasia AS NomeFornecedorBanco,
                    cp.Observacoes
                FROM ContasPagar cp
                LEFT JOIN Fornecedores f ON cp.FornecedorId = f.Id
                WHERE 1=1"; // 1=1 facilita adicionar filtros dinâmicos

            // Se quiser filtrar por Status (Opcional, mas útil)
            /* if (filtroStatus == "Pendentes") sql += " AND cp.DataPagamento IS NULL";
            if (filtroStatus == "Pagas") sql += " AND cp.DataPagamento IS NOT NULL";
            */

            sql += " ORDER BY cp.DataVencimento ASC";

            // Usamos o ExecutarConsulta genérico da Service mapeando o retorno
            return ExecutarConsulta<ContaPagar>(sql, MapearConta);
        }

        // Método auxiliar para transformar a linha do banco em Objeto C#
        private ContaPagar MapearConta(MySqlDataReader reader)
        {
            var conta = new ContaPagar();

            conta.Id = Convert.ToInt32(reader["Id"]);
            conta.Descricao = reader["Descricao"].ToString();
            conta.Categoria = reader["Categoria"].ToString();
            conta.Valor = Convert.ToDecimal(reader["Valor"]);
            conta.DataVencimento = Convert.ToDateTime(reader["DataVencimento"]);
            conta.Observacoes = reader["Observacoes"].ToString();

            // Verifica se DataPagamento não é nula no banco
            if (reader["DataPagamento"] != DBNull.Value)
                conta.DataPagamento = Convert.ToDateTime(reader["DataPagamento"]);
            else
                conta.DataPagamento = null;

            // Preenche dados de fornecedor
            if (reader["FornecedorId"] != DBNull.Value)
                conta.FornecedorId = Convert.ToInt32(reader["FornecedorId"]);

            conta.FavorecidoAvulso = reader["FavorecidoAvulso"] != DBNull.Value ? reader["FavorecidoAvulso"].ToString() : null;

            // Dica: Você pode preencher uma propriedade extra no objeto só para exibir o nome do fornecedor vindo do JOIN
            // Mas a propriedade 'NomeFavorecidoExibicao' na classe ContaPagar já resolve isso visualmente.

            return conta;
        }
        public void ExcluirConta(int id)
        {          
          string sql = "DELETE FROM ContasPagar WHERE Id = @id";            
            { 
                var parametros = new Dictionary<string, object>
                {
                   { "@id", id }
                };
                    bool sucesso = ExecutarComando(sql, parametros);
                if (!sucesso)
                {
                    throw new Exception("Falha ao excluir o registro no banco de dados.");
                }
            }
        }
    }
}