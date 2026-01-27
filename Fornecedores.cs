using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    // Herdamos de Usuario para reaproveitar a estrutura de Service CRUD e os campos de Endereço/ID.
    public class Fornecedores : Usuario
    {
        // --- PROPRIEDADES ESPECÍFICAS DA TABELA FORNECEDORES ---
        // Nota: Id, Telefone e os campos de Endereço (CEP, Rua, etc.) já são herdados da classe pai Usuario.

        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        // DataCadastro geralmente é gerada pelo banco no insert, mas útil para leitura.
        public DateTime DataCadastro { get; set; }

        // --- IMPLEMENTAÇÃO DOS MEMBROS ABSTRATOS DA CLASSE PAI ---

        protected override string NomeTabela => "Fornecedores";
        protected override string ChavePrimaria => "Id";

        // Mapeia as propriedades do objeto C# para as colunas do SQL (para INSERT/UPDATE)
        protected override Dictionary<string, object> ObterParametros()
        {
            var parametros = new Dictionary<string, object>
            {
                { "Id", this.Id },
                // Usamos as propriedades específicas
                { "NomeFantasia", this.NomeFantasia },
                // Tratamento para campos que podem ser nulos no banco
                { "RazaoSocial", this.RazaoSocial ?? (object)DBNull.Value },
                { "CNPJ", this.CNPJ },
                // Usamos as propriedades herdadas da classe pai
                { "Telefone", this.Telefone ?? (object)DBNull.Value },
                { "CEP", this.CEP ?? (object)DBNull.Value },
                { "Cidade", this.Cidade ?? (object)DBNull.Value },
                { "Estado", this.Estado ?? (object)DBNull.Value },
                { "Rua", this.Rua ?? (object)DBNull.Value },
                { "Bairro", this.Bairro ?? (object)DBNull.Value },
                { "Numero", this.Numero ?? (object)DBNull.Value }
                
                // OBS: Não passamos DataCadastro aqui, pois o banco define o padrão (DEFAULT CURRENT_TIMESTAMP) na inserção.
                // OBS: Ignoramos CPF, Senha, DataNascimento e CargoFuncionario pois não existem nesta tabela.
            };
            return parametros;
        }

        // Mapeia o resultado do banco de dados (DataReader) de volta para o objeto C# (para SELECT)
        protected override Usuario ObterObjeto(MySqlDataReader reader)
        {
            // Embora o método retorne 'Usuario', instanciamos um 'Fornecedores'.
            // Isso é polimorfismo e funciona perfeitamente.
            return new Fornecedores
            {
                // Mapeamento de campos herdados
                Id = Convert.ToInt32(reader["Id"]),
                Telefone = reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null,
                CEP = reader["CEP"] != DBNull.Value ? reader["CEP"].ToString() : null,
                Cidade = reader["Cidade"] != DBNull.Value ? reader["Cidade"].ToString() : null,
                Estado = reader["Estado"] != DBNull.Value ? reader["Estado"].ToString() : null,
                Rua = reader["Rua"] != DBNull.Value ? reader["Rua"].ToString() : null,
                Bairro = reader["Bairro"] != DBNull.Value ? reader["Bairro"].ToString() : null,
                Numero = reader["Numero"] != DBNull.Value ? reader["Numero"].ToString() : null,

                // Mapeamento de campos específicos
                NomeFantasia = reader["NomeFantasia"].ToString(),
                RazaoSocial = reader["RazaoSocial"] != DBNull.Value ? reader["RazaoSocial"].ToString() : null,
                CNPJ = reader["CNPJ"].ToString(),
                DataCadastro = Convert.ToDateTime(reader["DataCadastro"]),

                // OPCIONAL: Para compatibilidade em grids que esperam a propriedade "Nome", 
                // podemos preencher a propriedade herdada "Nome" com o Nome Fantasia.
                Nome = reader["NomeFantasia"].ToString()
            };
        }

        // --- SOBRESCRITA DE MÉTODOS DA CLASSE PAI (ADAPTAÇÃO NECESSÁRIA) ---

        // O método BuscarPorNomeOuCPF da classe pai não funcionaria aqui, pois a tabela Fornecedores
        // não tem as colunas "Nome" e "CPF". Sobrescrevemos para buscar pelos campos corretos.
        public override Usuario BuscarPorNomeOuCPF(string termoBusca)
        {
            // Adapta a query para buscar por Nome Fantasia, Razão Social ou CNPJ exato.
            string query = $@"SELECT * FROM {NomeTabela} 
                              WHERE NomeFantasia LIKE CONCAT('%', @termo, '%') 
                                 OR RazaoSocial LIKE CONCAT('%', @termo, '%')
                                 OR CNPJ = @termo";

            var parametros = new Dictionary<string, object>
            {
                {"@termo", termoBusca }
            };

            // Executa usando a infraestrutura da classe pai
            List<Usuario> lista = ExecutarConsulta(query, ObterObjeto, parametros);

            // Retorna o primeiro ou null. O cast (Usuario) é implícito.
            return lista.FirstOrDefault();
        }
    }
}