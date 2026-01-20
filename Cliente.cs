using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Projeto_FinalOficial.Modelos // Ajuste o namespace se necessário
{
    public class Cliente : Usuario
    {
        // Define o nome da tabela no banco
        protected override string NomeTabela => "Clientes";

        // Define o nome da chave primária
        protected override string ChavePrimaria => "Id";

        // 1. Mapeia as propriedades do C# para as Colunas do Banco (INSERT/UPDATE)
        protected override Dictionary<string, object> ObterParametros()
        {
            var parametros = new Dictionary<string, object>
            {
                { "Nome", this.Nome },
                { "CPF", this.CPF },
                { "Telefone", this.Telefone },
                
                // Endereço
                { "CEP", this.CEP },
                { "Cidade", this.Cidade },
                { "Estado", this.Estado },
                { "Rua", this.Rua },
                { "Bairro", this.Bairro },
                { "Numero", this.Numero }
            };

           

            return parametros;
        }

        // 2. Mapeia o Retorno do Banco (SELECT) para o Objeto C#
        protected override Usuario ObterObjeto(MySqlDataReader reader)
        {
            Cliente cliente = new Cliente();

            // É importante verificar se o campo não é nulo no banco antes de ler
            cliente.Id = Convert.ToInt32(reader["Id"]);
            cliente.Nome = reader["Nome"].ToString();
            cliente.CPF = reader["CPF"].ToString();

            // Verifica nulos para campos opcionais (evita erro se estiver vazio no banco)
            cliente.Telefone = reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : "";

            cliente.CEP = reader["CEP"] != DBNull.Value ? reader["CEP"].ToString() : "";
            cliente.Cidade = reader["Cidade"] != DBNull.Value ? reader["Cidade"].ToString() : "";
            cliente.Estado = reader["Estado"] != DBNull.Value ? reader["Estado"].ToString() : "";
            cliente.Rua = reader["Rua"] != DBNull.Value ? reader["Rua"].ToString() : "";
            cliente.Bairro = reader["Bairro"] != DBNull.Value ? reader["Bairro"].ToString() : "";
            cliente.Numero = reader["Numero"] != DBNull.Value ? reader["Numero"].ToString() : "";

            return cliente;
        }
        
    }
}