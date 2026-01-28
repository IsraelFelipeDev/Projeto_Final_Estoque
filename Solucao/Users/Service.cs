using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows; // Necessário para MessageBox

namespace Projeto_FinalOficial
{
    public class Service
    {
        // Certifique-se que sua classe Conexao e a propriedade ConexãoServidor existem e estão corretas
        private readonly string _conexão = Conexao.ConexãoServidor;

        // 1. Executa INSERT, UPDATE, DELETE simples (retorna true/false)
        public bool ExecutarComando(string query, Dictionary<string, Object> parametros)
        {
            using (MySqlConnection conexao = new MySqlConnection(_conexão))
            {
                try
                {
                    conexao.Open();
                    using (MySqlCommand cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = query;

                        if (parametros != null)
                        {
                            foreach (var param in parametros)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        int linhas = cmd.ExecuteNonQuery();
                        return linhas > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao executar comando: " + ex.Message);
                    return false;
                }
            }
        }

        // 2. Executa SELECT e retorna Lista de Objetos (Genérico)
        public List<T> ExecutarConsulta<T>(string query, Func<MySqlDataReader, T> mapear, Dictionary<string, object> parametros = null)
        {
            var lista = new List<T>();
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
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(mapear(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados: " + ex.Message);
            }
            return lista;
        }

        // 3. Executa SELECT e retorna DataTable (Para Grids e Combos)
        protected DataTable ExecutarConsultaDataTable(string sql, Dictionary<string, object> parametros = null)
        {
            using (MySqlConnection conexao = new MySqlConnection(_conexão))
            {
                using (MySqlCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText = sql;

                    if (parametros != null)
                    {
                        foreach (var item in parametros)
                        {
                            // Garante que o parâmetro tenha @
                            string nomeParametro = item.Key.StartsWith("@") ? item.Key : "@" + item.Key;
                            comando.Parameters.AddWithValue(nomeParametro, item.Value ?? DBNull.Value);
                        }
                    }

                    try
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro ao gerar DataTable: {ex.Message}");
                    }
                }
            }
        }

        // 4. Executa INSERT e retorna o ID GERADO (Correção aplicada aqui)
        protected int ExecutarComandoRetornandoId(string sql, Dictionary<string, object> parametros)
        {
            using (MySqlConnection conexao = new MySqlConnection(_conexão))
            {
                using (MySqlCommand comando = conexao.CreateCommand())
                {
                    // === A CORREÇÃO PRINCIPAL ESTAVA AQUI ===
                    comando.CommandText = sql;
                    // ========================================

                    if (parametros != null)
                    {
                        foreach (var item in parametros)
                        {
                            string nomeParametro = item.Key.StartsWith("@") ? item.Key : "@" + item.Key;
                            comando.Parameters.AddWithValue(nomeParametro, item.Value ?? DBNull.Value);
                        }
                    }

                    try
                    {
                        conexao.Open();

                        // Executa o comando. Como o SQL tem "; SELECT LAST_INSERT_ID();" no final,
                        // o ExecuteScalar retorna esse ID.
                        object resultado = comando.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            return Convert.ToInt32(resultado);
                        }

                        return 0;
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception($"Erro de banco SQL: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro geral: {ex.Message}");
                    }
                }
            }
        }

        // 5. Executa comando que retorna um único valor (Count, Soma, etc)
        protected object ExecutarComandoEscalar(string sql, Dictionary<string, object> parametros = null)
        {
            using (MySqlConnection conexao = new MySqlConnection(_conexão))
            {
                using (MySqlCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText = sql;

                    if (parametros != null)
                    {
                        foreach (var item in parametros)
                        {
                            comando.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                        }
                    }

                    try
                    {
                        conexao.Open();
                        return comando.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro no banco de dados: " + ex.Message);
                    }
                }
            }
        }
    }
}