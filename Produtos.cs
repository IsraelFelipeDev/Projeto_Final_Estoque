using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public class Produtos: Service
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Categoria { get; set; }
        public int QtdAtual { get; set; }
        public int QtdMax { get; set; }
        public int QtdMin { get; set; }
        public decimal Valor { get; set; }
        public string CodigoBarras { get; set; }
        public byte[] Foto { get; set; }




             
            private const string TABELA = "Produtos";
            private const string COLUNA_CHAVE = "CodigoBarras"; // Qual coluna identifica o produto único?



        public bool Salvar()
        {
            var dados = ObterDicionario(); // Sem passar 'p'
            string sql = GerarSqlInsert(TABELA, dados);
            return ExecutarComando(sql, AdicionarArrobaNosParametros(dados));
        }

        public bool Atualizar()
            {
                var dados = ObterDicionario();

                // Gera: UPDATE Produtos SET Nome=@Nome, Cor=@Cor... WHERE CodigoBarras=@CodigoBarras
                string sql = GerarSqlUpdate(TABELA, dados, COLUNA_CHAVE);

                return ExecutarComando(sql, AdicionarArrobaNosParametros(dados));
            }

            public bool Excluir(string codigoBarras)
            {
                string sql = $"DELETE FROM {TABELA} WHERE {COLUNA_CHAVE} = @cod";
                var param = new Dictionary<string, object> { { "@cod", codigoBarras } };
                return ExecutarComando(sql, param);
            }

            public Produtos Buscar(string codigoBarras)
            {
                string sql = $"SELECT * FROM {TABELA} WHERE {COLUNA_CHAVE} = @cod";
                var param = new Dictionary<string, object> { { "@cod", codigoBarras } };
                return ExecutarConsulta(sql, MapearLeitor, param).FirstOrDefault();
            }

            // --- MÉTODOS GERADORES DE SQL (A MÁGICA) ---

            private string GerarSqlInsert(string tabela, Dictionary<string, object> dados)
            {
                // Pega as chaves "Nome", "Cor", "Valor"
                var colunas = string.Join(", ", dados.Keys);

                // Pega as chaves e coloca @: "@Nome", "@Cor", "@Valor"
                var parametros = string.Join(", ", dados.Keys.Select(k => "@" + k));

                return $"INSERT INTO {tabela} ({colunas}) VALUES ({parametros})";
            }

            private string GerarSqlUpdate(string tabela, Dictionary<string, object> dados, string campoChave)
            {
                // Cria a lista: "Nome=@Nome", "Cor=@Cor"
                // O Where exclui o campo chave (CodigoBarras) para não tentar atualizar ele mesmo no SET
                var sets = dados.Keys.Where(k => k != campoChave)
                                     .Select(k => $"{k}=@{k}");

                string setString = string.Join(", ", sets);

                return $"UPDATE {tabela} SET {setString} WHERE {campoChave}=@{campoChave}";
            }

            // --- MAPEAMENTO DE DADOS ---

            // Método único que define os dados. Mudou aqui, muda tudo.
            // OBS: As chaves AQUI devem ser EXATAMENTE o nome das colunas do MySQL
            private Dictionary<string, object> ObterDicionario()
            {
                return new Dictionary<string, object>
            {
                { "Nome", this.Nome },
                { "Cor", this.Cor },
                { "Categoria", this.Categoria },
                { "QtdAtual", this.QtdAtual },
                { "QtdMax", this.QtdMax },
                { "QtdMin",this.QtdMin },
                { "Valor", this.Valor },
                { "CodigoBarras", this.CodigoBarras },
                { "Foto", Foto ?? (object)DBNull.Value }
            };
            }

            // Ajuda o seu Service a entender os parâmetros colocando "@" nas chaves
            private Dictionary<string, object> AdicionarArrobaNosParametros(Dictionary<string, object> dados)
            {
                var novoDic = new Dictionary<string, object>();
                foreach (var item in dados)
                {
                    novoDic.Add("@" + item.Key, item.Value);
                }
                return novoDic;
            }

            private Produtos MapearLeitor(MySqlDataReader reader)
            {
                return new Produtos
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString(),
                    Cor = reader["Cor"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    QtdAtual = Convert.ToInt32(reader["QtdAtual"]),
                    QtdMax = Convert.ToInt32(reader["QtdMax"]),
                    QtdMin = Convert.ToInt32(reader["QtdMin"]),
                    Valor = Convert.ToDecimal(reader["Valor"]),
                    CodigoBarras = reader["CodigoBarras"].ToString(),
                    Foto = reader["Foto"] != DBNull.Value ? (byte[])reader["Foto"] : null
                };
            }
    }
 }


