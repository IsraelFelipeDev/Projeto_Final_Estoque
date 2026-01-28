using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Projeto_FinalOficial
{
    // ===================================================================================
    // Classe PAI: Define o modelo do produto e suas regras de negócio/persistência.
    // Segue o padrão Active Record, herdando as funcionalidades de banco da classe 'Service'.
    // ===================================================================================
    public class Produtos : Service
    {
        #region 1. Propriedades (Modelo de Dados)

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // NOTA: Em um sistema ideal, estes campos seriam IDs (Foreign Keys) para outras tabelas,
        // mas mantivemos como string conforme sua estrutura atual para simplificar o MVP.
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Estilo { get; set; }
        public string Colecao { get; set; }
        public string Composicao { get; set; }
        public string Modelagem { get; set; }
        public string Cor { get; set; }

        // Campos Financeiros
        // O C# inicializa decimal como 0.00m por padrão, mas é bom ser explícito.
        public decimal ValorCompra { get; set; } = 0.00m;
        public decimal ValorVendaBase { get; set; } = 0.00m;

        public byte[] FotoCapa { get; set; }
        // DataCadastro geralmente é gerenciada pelo banco (DEFAULT CURRENT_TIMESTAMP), 
        // mas a mantemos aqui para leitura.
        public DateTime DataCadastro { get; set; }

        // Constante para o nome da tabela, facilitando manutenção.
        private const string TABELA = "Produtos";

        #endregion

        #region 2. Métodos de Persistência (CRUD Padrão)

        /// <summary>
        /// Insere um novo produto no banco e retorna o ID gerado.
        /// É fundamental retornar o ID para poder vincular as variações (filhos) logo em seguida.
        /// </summary>
        public int SalvarRetornandoId()
        {
            // 1. Validação prévia (Regra de Negócio)
            ValidarCadastro();

            // 2. Prepara os dados
            var dados = ObterDicionarioParaBanco();

            // Remove campos que o banco gera automaticamente no INSERT
            dados.Remove(nameof(Id));           // Auto-increment
            dados.Remove(nameof(DataCadastro)); // Gerado pelo banco (DEFAULT CURRENT_TIMESTAMP)

            // 3. Gera e executa o SQL
            string sql = GerarSqlInsertRetornandoId(TABELA, dados);
            return ExecutarComandoRetornandoId(sql, AdicionarArrobaNosParametros(dados));
        }

        public bool Atualizar()
        {
            // 1. Validação prévia
            ValidarCadastro();

            var dadosCompletos = ObterDicionarioParaBanco();

            // Remove campos que NUNCA devem ser alterados em um update
            dadosCompletos.Remove(nameof(DataCadastro));

            // LÓGICA IMPORTANTE DO UPDATE:
            // 1. Criamos um dicionário 'dadosParaSet' SEM o ID. Ele será usado para montar a parte "SET Nome=@Nome, Valor=@Valor" do SQL.
            //    Se deixássemos o ID aqui, o SQL tentaria fazer "SET Id=@Id", o que é errado.
            var dadosParaSet = dadosCompletos
                                .Where(k => k.Key != nameof(Id))
                                .ToDictionary(k => k.Key, k => k.Value);

            // 2. Geramos o SQL usando apenas os campos que devem ser atualizados, mas informamos que a chave é "Id".
            string sql = GerarSqlUpdate(TABELA, dadosParaSet, nameof(Id));

            // 3. Na hora de executar, passamos 'dadosCompletos'. Por quê?
            //    Porque 'dadosCompletos' ainda contém o par { "Id", valorDoId }.
            //    Embora não usado no SET, ele é obrigatório para o "WHERE Id = @Id" funcionar.
            return ExecutarComando(sql, AdicionarArrobaNosParametros(dadosCompletos));
        }

        public bool Excluir(int id)
        {
            string sql = $"DELETE FROM {TABELA} WHERE Id = @Id";
            var param = new Dictionary<string, object> { { "@Id", id } };
            return ExecutarComando(sql, param);
        }

        public Produtos BuscarPorId(int id)
        {
            string sql = $"SELECT * FROM {TABELA} WHERE Id = @Id";
            var param = new Dictionary<string, object> { { "@Id", id } };
            // Retorna o primeiro encontrado ou null
            return ExecutarConsulta(sql, MapearLeitor, param).FirstOrDefault();
        }


        // Método otimizado para preencher ComboBoxes em outras telas (traz apenas o necessário)
        public DataTable ListarParaSelecao()
        {
            string sql = $"SELECT Id, Nome FROM {TABELA} ORDER BY Nome ASC";
            return ExecutarConsultaDataTable(sql);
        }

        // Regra de negócio simples para impedir cadastro de dados inválidos
        private void ValidarCadastro()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
                throw new ArgumentException("O Nome do produto é obrigatório.");

            if (this.ValorVendaBase < 0)
                throw new ArgumentException("O Valor de Venda não pode ser negativo.");

            // Adicione outras validações de negócio aqui se necessário
        }

        #endregion

        #region 3. Geradores de SQL Dinâmico

        // Gera: INSERT INTO Tabela (Col1, Col2) VALUES (@Col1, @Col2); SELECT LAST_INSERT_ID();
        private string GerarSqlInsertRetornandoId(string tabela, Dictionary<string, object> dados)
        {
            var colunas = string.Join(", ", dados.Keys);
            var parametros = string.Join(", ", dados.Keys.Select(k => "@" + k));
            return $"INSERT INTO {tabela} ({colunas}) VALUES ({parametros}); SELECT LAST_INSERT_ID();";
        }

        // Gera: UPDATE Tabela SET Col1=@Col1, Col2=@Col2 WHERE CampoChave=@CampoChave
        private string GerarSqlUpdate(string tabela, Dictionary<string, object> dadosParaSet, string campoChave)
        {
            var sets = dadosParaSet.Keys.Select(k => $"{k}=@{k}");
            string setString = string.Join(", ", sets);
            return $"UPDATE {tabela} SET {setString} WHERE {campoChave}=@{campoChave}";
        }

        #endregion

        #region 4. Mapeamento (Objeto <-> Banco)

        // Define quais propriedades desta classe vão para o banco no INSERT/UPDATE.
        // Usa 'nameof()' para garantir segurança se você renomear propriedades depois.
        private Dictionary<string, object> ObterDicionarioParaBanco()
        {
            return new Dictionary<string, object>
            {
                { nameof(Id), this.Id },
                { nameof(Nome), this.Nome },
                // Tratamento essencial: Se a string for null no C#, envia DBNull.Value para o banco.
                { nameof(Descricao), this.Descricao ?? (object)DBNull.Value },
                { nameof(Categoria), this.Categoria ?? (object)DBNull.Value },
                { nameof(SubCategoria), this.SubCategoria ?? (object)DBNull.Value },
                { nameof(Estilo), this.Estilo ?? (object)DBNull.Value },
                { nameof(Colecao), this.Colecao ?? (object)DBNull.Value },
                { nameof(Composicao), this.Composicao ?? (object)DBNull.Value },
                { nameof(Modelagem), this.Modelagem ?? (object)DBNull.Value },
                { nameof(Cor), this.Cor ?? (object)DBNull.Value },

                // Campos de valor (decimais nunca são null, então vão direto)
                { nameof(ValorCompra), this.ValorCompra },
                { nameof(ValorVendaBase), this.ValorVendaBase },

                // Foto e Data
                { nameof(FotoCapa), this.FotoCapa ?? (object)DBNull.Value },
                { nameof(DataCadastro), this.DataCadastro }
            };
        }

        // Define como converter uma linha do banco (MySqlDataReader) de volta para este objeto.
        private Produtos MapearLeitor(MySqlDataReader reader)
        {
            return new Produtos
            {
                // Convert.ToInt32 é seguro para IDs numéricos
                Id = Convert.ToInt32(reader[nameof(Id)]),
                // .ToString() funciona bem para campos obrigatórios
                Nome = reader[nameof(Nome)].ToString(),

                // Leitura segura para campos que podem ser NULL no banco.
                // Verifica se é DBNull.Value; se não for, converte para string, senão define como null.
                Descricao = reader[nameof(Descricao)] != DBNull.Value ? reader[nameof(Descricao)].ToString() : null,
                Categoria = reader[nameof(Categoria)] != DBNull.Value ? reader[nameof(Categoria)].ToString() : null,
                SubCategoria = reader[nameof(SubCategoria)] != DBNull.Value ? reader[nameof(SubCategoria)].ToString() : null,
                Estilo = reader[nameof(Estilo)] != DBNull.Value ? reader[nameof(Estilo)].ToString() : null,
                Colecao = reader[nameof(Colecao)] != DBNull.Value ? reader[nameof(Colecao)].ToString() : null,
                Composicao = reader[nameof(Composicao)] != DBNull.Value ? reader[nameof(Composicao)].ToString() : null,
                Modelagem = reader[nameof(Modelagem)] != DBNull.Value ? reader[nameof(Modelagem)].ToString() : null,
                Cor = reader[nameof(Cor)] != DBNull.Value ? reader[nameof(Cor)].ToString() : null,

                // Conversão segura para decimais
                ValorCompra = Convert.ToDecimal(reader[nameof(ValorCompra)]),
                ValorVendaBase = Convert.ToDecimal(reader[nameof(ValorVendaBase)]),

                // Leitura segura para BLOB (imagem)
                FotoCapa = reader[nameof(FotoCapa)] != DBNull.Value ? (byte[])reader[nameof(FotoCapa)] : null,

                // Conversão segura para Data
                DataCadastro = Convert.ToDateTime(reader[nameof(DataCadastro)])
            };
        }

        // Função auxiliar para adicionar o '@' nos parâmetros para o MySqlClient
        private Dictionary<string, object> AdicionarArrobaNosParametros(Dictionary<string, object> dados)
        {
            var novoDic = new Dictionary<string, object>();
            foreach (var item in dados)
            {
                novoDic.Add("@" + item.Key, item.Value);
            }
            return novoDic;
        }
        public DataTable ListarTodos()
        {
            string sql = @"SELECT 
                            Id, 
                            Nome, 
                            Categoria, 
                            Estilo, 
                            ValorVendaBase, 
                            DataCadastro 
                           FROM Produtos 
                           ORDER BY Nome ASC";

            return ExecutarConsultaDataTable(sql);
        }

        // Adicione na classe Produtos

        public DataTable ListarNomesParaBusca()
        {
            // Trazemos apenas ID e Nome para não pesar a memória
            string sql = "SELECT Id, Nome FROM Produtos ORDER BY Nome ASC";
            return ExecutarConsultaDataTable(sql);
        }
        public DataTable ListarEstoqueGeral()
        {
            // O SQL fica extremamente limpo pois a complexidade está encapsulada na View do MySQL
            string sql = "SELECT * FROM vw_EstoqueGeral ORDER BY Descricao ASC";

            // Retorna o DataTable pronto para ser ligado ao DataGridView
            return ExecutarConsultaDataTable(sql);
        }
        // Colar dentro da classe Produtos.cs

        public void AtualizarQuantidadesEstoque(int idVariacao, int novoMin, int novoMax, int novoAtual)
        {
            // O nome da tabela agora está exato: Produtos_Variacoes
            string sql = @"UPDATE Produtos_Variacoes 
                   SET QtdMin = @min, 
                       QtdMax = @max, 
                       QtdAtual = @atual 
                   WHERE Id = @id";

            var parametros = new Dictionary<string, object>
    {
        { "@id", idVariacao },
        { "@min", novoMin },
        { "@max", novoMax },
        { "@atual", novoAtual }
    };

            ExecutarComando(sql, parametros);
        }
    }




    #endregion
}
