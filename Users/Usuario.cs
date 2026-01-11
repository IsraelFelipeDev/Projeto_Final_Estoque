using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    public abstract class Usuario : Service
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        
        

        public string CargoFuncionario { get; set; }


        protected abstract string NomeTabela { get; }
        protected abstract string ChavePrimaria { get; }
        protected abstract Dictionary<string, object> ObterParametros();
        protected abstract Usuario ObterObjeto(MySqlDataReader reader);

        public virtual bool InserirDados()
        {
            var parametros = ObterParametros();

            string Colunas = string.Join(" , ", parametros.Keys);
            string Valores = string.Join(" , ", parametros.Keys.Select(K => "@" + K));

            string query = $"INSERT INTO {NomeTabela} ({Colunas}) VALUES ({Valores}) ";

            return ExecutarComando(query, parametros);
        }

        public virtual bool AlterarDados()
        {
            var parametros = ObterParametros();
            string SetValores = string.Join(" , ", parametros.Keys.Select(KeyParametro => $"{KeyParametro} = @{KeyParametro}"));
            string query = $"UPDATE {NomeTabela} SET {SetValores} WEHRE {ChavePrimaria} = @{ChavePrimaria} ";

            return ExecutarComando(query, parametros);
        }
        public virtual bool DeletarDados()
        {
            string query = $"DELETE FROM {NomeTabela} WHERE {ChavePrimaria} = @Id ";
            var parametro = new Dictionary<string, Object>
            {
                {"@Id", this.Id }
            };

            return ExecutarComando(query, parametro);
        }
        public virtual Usuario BuscarPorId()
        {
            string query = $"SELECT * FROM {NomeTabela} WHERE {ChavePrimaria} = @ID ";
            var parametro = new Dictionary<string, object>
            {
                {"@Id",this.Id }
            };
            List<Usuario> listar = ExecutarConsulta(query, ObterObjeto, parametro);
            return listar.FirstOrDefault();
        }
        public virtual List<Usuario> BuscarTodos()
        {
            String query = $"SELECT * FROM {NomeTabela}; ";
            List<Usuario> lista = ExecutarConsulta(query, ObterObjeto, null);
            return lista;
        }

        public virtual Usuario BuscarLogin(string Email, string Senha)
        {
            string query = $"SELECT * FROM {NomeTabela} WHERE Email = @Email AND Senha = @Senha ";
            var parametros = new Dictionary<string, object>
                {
                    {"@Email",Email },
                    {"@Senha",Senha }

                };
            List<Usuario> lista = ExecutarConsulta(query, ObterObjeto, parametros);
            return lista.FirstOrDefault();
        }

    }
}
    

