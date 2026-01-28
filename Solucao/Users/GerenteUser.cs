using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public class GerenteUser : Usuario
    {
        protected override string ChavePrimaria => "Id";
        protected override string NomeTabela => "Usuarios";

        protected override Dictionary<string, object> ObterParametros()
        {
            return new Dictionary<string, Object>
            {
                {"Id",this.Id },
                {"Senha",this.Senha },
                {"Nome", this.Nome },
                {"Email",this.Email },
                {"CPF",this.CPF },
                {"Telefone",this.Telefone },
                {"DataNascimento",this.DataNascimento },
                {"Cidade",this.Cidade },
                {"Estado",this.Estado },
                {"Rua",this.Rua },
                {"Bairro",this.Bairro },
                {"Numero",this.Numero },
                {"Cargo",this.CargoFuncionario }
            };
        }
        protected override Usuario ObterObjeto(MySqlDataReader reader)
        {
            return new GerenteUser
            {

                Id = Convert.ToInt32(reader["Id"]),
                Senha = reader["Senha"].ToString(),
                Nome = reader["Nome"].ToString(),
                Email = reader["Email"].ToString(),
                CPF = reader["CPF"].ToString(),
                Telefone = reader["Telefone"].ToString(),
                DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                Cidade = reader["Cidade"].ToString(),
                Rua = reader["Rua"].ToString(),
                Bairro = reader["Bairro"].ToString(),
                Estado = reader["Estado"].ToString(),
                Numero = reader["Numero"].ToString(),
                CargoFuncionario = reader["Cargo"].ToString()
            };
        }
    }
}

