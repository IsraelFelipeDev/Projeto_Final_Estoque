using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    // Classe que representa a tabela de ligação (Catálogo de Preços/Referência)
    public class ProdutoFornecedorCatalogo : Service
    {
        // --- PROPRIEDADES (Conforme Tabela SQL) ---
        public int Id { get; set; }
        public int ProdutoPaiId { get; set; }
        public int FornecedorId { get; set; }
        public decimal PrecoCustoTabela { get; set; } // O preço simulado/de referência
        public string CodigoProdutoNoFornecedor { get; set; } // Opcional
        public bool IsFornecedorPrincipal { get; set; } = false;

        private const string TABELA = "Produtos_Fornecedores_Catalogo";

        // =================================================================
        // MÉTODOS DE PERSISTÊNCIA ESPECIALIZADOS
        // =================================================================

        // --- O MÉTODO MÁGICO "UPSERT" ---
        // Este método tenta inserir o vínculo. Se o banco reclamar que a combinação
        // (ProdutoPaiId + FornecedorId) já existe, ele automaticamente faz um UPDATE
        // no preço e nas outras informações.
        // É ideal para sua tela de simulação híbrida.

        // =================================================================
        // MÉTODO NOVO: BUSCA PELO CÓDIGO DO FORNECEDOR
        // =================================================================

        /// <summary>
        /// Procura se existe algum produto vinculado a este código de fornecedor.
        /// Se achar, retorna o ID do Produto (ProdutoPaiId). Se não, retorna 0.
        /// </summary>
        public int BuscarIdProdutoPorCodigoFornecedor(string codigo)
        {
            // Busca exata pelo código que o fornecedor usa
            string sql = $"SELECT ProdutoPaiId FROM {TABELA} WHERE CodigoProdutoNoFornecedor = @cod LIMIT 1";

            var param = new Dictionary<string, object> { { "@cod", codigo } };

            // Executa e retorna o primeiro valor encontrado (que é o ID do produto pai)
            object resultado = ExecutarComandoEscalar(sql, param);

            if (resultado != null && resultado != DBNull.Value)
            {
                return Convert.ToInt32(resultado);
            }

            return 0; // 0 significa que não achou nada
        }
        public bool VincularOuAtualizar()
        {
            // 1. Prepara os dados
            var dados = ObterDicionario();
            dados.Remove("Id");     // Não precisamos do ID para inserir/atualizar
            dados.Remove("DataUltimaAtualizacao"); // O banco gerencia isso

            var parametros = AdicionarArrobaNosParametros(dados);

            // 2. Monta o SQL de UPSERT do MySQL
            // Sintaxe: INSERT INTO ... VALUES ... ON DUPLICATE KEY UPDATE campo=valor, ...
            string colunas = string.Join(", ", dados.Keys);
            string valores = string.Join(", ", dados.Keys.Select(k => "@" + k));

            // Se já existir, atualiza estes campos:
            string updates = "PrecoCustoTabela = @PrecoCustoTabela, CodigoProdutoNoFornecedor = @CodigoProdutoNoFornecedor, IsFornecedorPrincipal = @IsFornecedorPrincipal";

            string sql = $@"INSERT INTO {TABELA} ({colunas}) VALUES ({valores}) 
                            ON DUPLICATE KEY UPDATE {updates}";

            // 3. Executa
            return ExecutarComando(sql, parametros);
        }

        // Método para remover um vínculo específico (caso o usuário desmarque na tela)
        public bool Desvincular(int produtoPaiId, int fornecedorId)
        {
            string sql = $"DELETE FROM {TABELA} WHERE ProdutoPaiId = @pid AND FornecedorId = @fid";
            var param = new Dictionary<string, object> {
                { "@pid", produtoPaiId },
                { "@fid", fornecedorId }
            };
            return ExecutarComando(sql, param);
        }

        // Busca os vínculos de um fornecedor (útil para carregar a tela de edição depois)
        public List<ProdutoFornecedorCatalogo> BuscarPorFornecedor(int fornecedorId)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE FornecedorId = @fid";
            var param = new Dictionary<string, object> { { "@fid", fornecedorId } };
            return ExecutarConsulta(sql, MapearLeitor, param);
        }

        // =================================================================
        // MAPEADORES AUXILIARES
        // =================================================================
        private Dictionary<string, object> ObterDicionario()
        {
            return new Dictionary<string, object>
            {
                { "Id", this.Id },
                { "ProdutoPaiId", this.ProdutoPaiId },
                { "FornecedorId", this.FornecedorId },
                { "PrecoCustoTabela", this.PrecoCustoTabela },
                // Tratamento para nulo
                { "CodigoProdutoNoFornecedor", string.IsNullOrEmpty(this.CodigoProdutoNoFornecedor) ? (object)DBNull.Value : this.CodigoProdutoNoFornecedor },
                // Booleano no C# vira TinyInt(1) no MySQL
                { "IsFornecedorPrincipal", this.IsFornecedorPrincipal ? 1 : 0 }
            };
        }

        private ProdutoFornecedorCatalogo MapearLeitor(MySqlDataReader reader)
        {
            return new ProdutoFornecedorCatalogo
            {
                Id = Convert.ToInt32(reader["Id"]),
                ProdutoPaiId = Convert.ToInt32(reader["ProdutoPaiId"]),
                FornecedorId = Convert.ToInt32(reader["FornecedorId"]),
                PrecoCustoTabela = Convert.ToDecimal(reader["PrecoCustoTabela"]),
                CodigoProdutoNoFornecedor = reader["CodigoProdutoNoFornecedor"] as string,
                // O MySQL retorna o boolean como 1/0, Convert.ToBoolean lida bem com isso
                IsFornecedorPrincipal = Convert.ToBoolean(reader["IsFornecedorPrincipal"])
            };
        }

        private Dictionary<string, object> AdicionarArrobaNosParametros(Dictionary<string, object> dados)
        {
            var novoDic = new Dictionary<string, object>();
            foreach (var item in dados) { novoDic.Add("@" + item.Key, item.Value); }
            return novoDic;
        }
    }
}