using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Projeto_FinalOficial
{
    public class Service
    {
        private readonly string _conexão = Conexao.ConexãoServidor;

        public bool ExecutarComando(string query, Dictionary<string, Object> parametros)
        {
            using (MySqlConnection conexao = new MySqlConnection(_conexão))
            {
                conexao.Open();
                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    cmd.CommandText = query;
                    if (parametros != null)
                    {
                        foreach (var param in parametros)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                        ;
                    }
                    int linhas = cmd.ExecuteNonQuery();
                    return linhas > 0;

                }
            }
        }
        public List<T> ExecutarConsulta<T>(string query, Func<MySqlDataReader, T> mapear, Dictionary<string, object> parametros = null)
        {
            var lista = new List<T>();
            {
                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(_conexão))
                    {
                        conexao.Open();
                        using (MySqlCommand cmd = conexao.CreateCommand())
                        {
                            cmd.CommandText = query;
                            if (parametros != null)
                            {
                                foreach (var param in parametros)
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value);

                                }
                            }
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    T objeto = mapear(reader);
                                    lista.Add(objeto);

                                }
                            }

                        }
                    }

                }
                catch (Exception ex)
                {

                   MessageBox.Show("Erro ao conectar com o banco de dados.", ex.Message);
                }
                return lista;
            }

        }
    }
}
