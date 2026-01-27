using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Projeto_FinalOficial
{
    public class ProdutoVariacao : Service
    {
        private const string TABELA = "Produtos_Variacoes";

        // ==========================================
        // PROPRIEDADES
        // ==========================================
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Tamanho { get; set; }
        public string CodigoBarrasEAN { get; set; }
        public decimal ValorVendaAtual { get; set; }
        public int QtdAtual { get; set; }
        public int QtdMin { get; set; }
        public int QtdMax { get; set; }

        // Propriedade de exibição (DTO)
        public string NomeProdutoPai { get; set; }

        // ==========================================
        // MÉTODOS DE PERSISTÊNCIA (Escrita)
        // ==========================================

        public bool Salvar()
        {
            var dados = MapearObjetoParaDicionario();
            dados.Remove("Id"); // Remove Id pois é Auto Increment no banco

            string sql = GerarSqlInsert(TABELA, dados);
            return ExecutarComando(sql, AdicionarArrobaParametros(dados));
        }

        public bool Atualizar()
        {
            var dados = MapearObjetoParaDicionario();

            // Separa os dados: Remove o ID e o ProdutoId do UPDATE
            // (Não devemos alterar o ProdutoId de uma variação já criada, nem a chave primária)
            var dadosParaUpdate = dados
                .Where(k => k.Key != "Id" && k.Key != "ProdutoId")
                .ToDictionary(k => k.Key, k => k.Value);

            // Gera: UPDATE Produtos_Variacoes SET Tamanho=@Tamanho... WHERE Id=@Id
            string sql = GerarSqlUpdate(TABELA, dadosParaUpdate, "Id");

            // Passamos 'dados' completo para o comando, pois ele precisa do @Id para a cláusula WHERE
            return ExecutarComando(sql, AdicionarArrobaParametros(dados));
        }

        public bool Excluir(int id)
        {
            string sql = $"DELETE FROM {TABELA} WHERE Id = @Id";
            return ExecutarComando(sql, new Dictionary<string, object> { { "@Id", id } });
        }

        // CUIDADO: Este método não deve ser usado na Edição de Produtos para evitar erro de Foreign Key
        public void ExcluirPorProdutoPai(int idProdutoPai)
        {
            string sql = $"DELETE FROM {TABELA} WHERE ProdutoId = @ProdutoId";

            try
            {
                ExecutarComando(sql, new Dictionary<string, object> { { "@ProdutoId", idProdutoPai } });
            }
            catch (Exception ex)
            {
                // Se der erro de FK, é porque tem pedidos vinculados.
                throw new Exception($"Não é possível limpar todas as variações pois existem vendas/compras vinculadas. Detalhes: {ex.Message}", ex);
            }
        }

        // ==========================================
        // MÉTODOS DE CONSULTA (Leitura)
        // ==========================================

        public DataTable ListarParaGrid(int produtoId)
        {
            string sql = $@"
                SELECT 
                    Id,
                    Tamanho, 
                    CodigoBarrasEAN, 
                    QtdAtual,
                    QtdMin,
                    QtdMax,
                    ValorVendaAtual
                FROM {TABELA} 
                WHERE ProdutoId = @ProdutoId 
                ORDER BY Tamanho";

            return ExecutarConsultaDataTable(sql, new Dictionary<string, object> { { "@ProdutoId", produtoId } });
        }

        public List<ProdutoVariacao> BuscarPorProdutoPai(int produtoId)
        {
            // Importante trazer o ID para saber se é edição ou novo cadastro no Grid
            string sql = $"SELECT * FROM {TABELA} WHERE ProdutoId = @ProdutoId ORDER BY Tamanho";
            return ExecutarConsulta(sql, ReaderParaObjeto, new Dictionary<string, object> { { "@ProdutoId", produtoId } });
        }

        public ProdutoVariacao BuscarPorEAN(string ean)
        {
            if (string.IsNullOrWhiteSpace(ean)) return null;

            string sql = $@"
                SELECT v.*, p.Nome as NomePai 
                FROM {TABELA} v
                INNER JOIN Produtos p ON v.ProdutoId = p.Id
                WHERE v.CodigoBarrasEAN = @EAN";

            return ExecutarConsulta(sql, ReaderParaObjetoComPai, new Dictionary<string, object> { { "@EAN", ean } })
                   .FirstOrDefault();
        }

        // ==========================================
        // MAPPERS E AUXILIARES
        // ==========================================

        private Dictionary<string, object> MapearObjetoParaDicionario()
        {
            return new Dictionary<string, object>
            {
                { "Id", Id },
                { "ProdutoId", ProdutoId },
                { "Tamanho", Tamanho },
                // Garante que se o EAN for nulo, envia DBNull para o banco
                { "CodigoBarrasEAN", (object)CodigoBarrasEAN ?? DBNull.Value },
                { "ValorVendaAtual", ValorVendaAtual },
                { "QtdAtual", QtdAtual },
                { "QtdMin", QtdMin },
                { "QtdMax", QtdMax }
            };
        }

        private ProdutoVariacao ReaderParaObjeto(MySqlDataReader reader)
        {
            return new ProdutoVariacao
            {
                Id = Convert.ToInt32(reader["Id"]),
                ProdutoId = Convert.ToInt32(reader["ProdutoId"]),
                Tamanho = reader["Tamanho"].ToString(),
                CodigoBarrasEAN = reader["CodigoBarrasEAN"] is DBNull ? null : reader["CodigoBarrasEAN"].ToString(),
                ValorVendaAtual = reader["ValorVendaAtual"] != DBNull.Value ? Convert.ToDecimal(reader["ValorVendaAtual"]) : 0,
                QtdAtual = reader["QtdAtual"] != DBNull.Value ? Convert.ToInt32(reader["QtdAtual"]) : 0,
                QtdMin = reader["QtdMin"] != DBNull.Value ? Convert.ToInt32(reader["QtdMin"]) : 0,
                QtdMax = reader["QtdMax"] != DBNull.Value ? Convert.ToInt32(reader["QtdMax"]) : 0
            };
        }

        private ProdutoVariacao ReaderParaObjetoComPai(MySqlDataReader reader)
        {
            var variacao = ReaderParaObjeto(reader);

            if (ColunaExiste(reader, "NomePai"))
            {
                variacao.NomeProdutoPai = reader["NomePai"].ToString();
            }

            return variacao;
        }

        // --- Helpers de SQL (Mantidos aqui para compatibilidade) ---

        private string GerarSqlInsert(string tabela, Dictionary<string, object> dados)
        {
            var colunas = string.Join(", ", dados.Keys);
            var parametros = string.Join(", ", dados.Keys.Select(k => "@" + k));
            return $"INSERT INTO {tabela} ({colunas}) VALUES ({parametros})";
        }

        private string GerarSqlUpdate(string tabela, Dictionary<string, object> dados, string chave)
        {
            // Cria a string: Coluna=@Coluna, Coluna2=@Coluna2...
            var sets = string.Join(", ", dados.Keys.Select(k => $"{k}=@{k}"));
            // Adiciona o WHERE Chave=@Chave
            return $"UPDATE {tabela} SET {sets} WHERE {chave}=@{chave}";
        }

        private Dictionary<string, object> AdicionarArrobaParametros(Dictionary<string, object> dados)
        {
            return dados.ToDictionary(k => "@" + k.Key, k => k.Value);
        }

        private bool ColunaExiste(IDataReader reader, string nomeColuna)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(nomeColuna, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        public class ItemPedidoTransfer
        {
            public int IdVariacao { get; set; }
            public string NomeProduto { get; set; }
            public int QtdSugestao { get; set; } // Sugestão baseada no Máximo - Atual
        }
    }

}