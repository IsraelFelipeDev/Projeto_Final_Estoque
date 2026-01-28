using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public class EstoquistaUser : Usuario
    {
        protected override string ChavePrimaria => "Id";
        protected override string NomeTabela => "usuarios";

        protected override Usuario ObterObjeto(MySqlDataReader reader)
        {
            return new EstoquistaUser
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

    }
}

