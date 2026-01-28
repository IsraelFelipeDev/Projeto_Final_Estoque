using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    // =============================================================
    // 1. ESTILO
    // =============================================================
    public class Estilo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Estilo> ListarTodos()
        {
            var lista = new List<Estilo>();
            try
            {
                // AQUI: Usando sua classe Conexao existente
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT Id, Nome FROM Estilos ORDER BY Nome", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Estilo { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar Estilos: " + ex.Message); }
            return lista;
        }
    }

    // =============================================================
    // 2. COMPOSIÇÃO
    // =============================================================
    public class Composicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        // Adicionamos a propriedade CategoriaId para fazer o filtro
        public int? CategoriaId { get; set; }

        // =================================================================
        // ESTE É O MÉTODO QUE ESTÁ FALTANDO E GERANDO O ERRO
        // =================================================================
        public List<Composicao> BuscarPorCategoria(int categoriaId)
        {
            var lista = new List<Composicao>();
            try
            {
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    // Traz itens da categoria específica OU itens globais (CategoriaId NULL)
                    string sql = "SELECT Id, Nome FROM Composicoes WHERE CategoriaId = @catId OR CategoriaId IS NULL ORDER BY Nome";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@catId", categoriaId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Composicao { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao filtrar Composições: " + ex.Message); }
            return lista;
        }
        public List<Composicao> ListarTodas()
        {
            var lista = new List<Composicao>();
            try
            {
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT Id, Nome FROM Composicoes ORDER BY Nome", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Composicao { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar Composições: " + ex.Message); }
            return lista;
        }
    }

    // =============================================================
    // 3. MODELAGEM
    // =============================================================
    public class Modelagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? CategoriaId { get; set; }

        // =================================================================
        // ESTE É O MÉTODO QUE ESTÁ FALTANDO E GERANDO O ERRO
        // =================================================================
        public List<Modelagem> BuscarPorCategoria(int categoriaId)
        {
            var lista = new List<Modelagem>();
            try
            {
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    string sql = "SELECT Id, Nome FROM Modelagens WHERE CategoriaId = @catId OR CategoriaId IS NULL ORDER BY Nome";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@catId", categoriaId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Modelagem { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao filtrar Modelagens: " + ex.Message); }
            return lista;
        }
        public List<Modelagem> ListarTodas()
        {
            var lista = new List<Modelagem>();
            try
            {
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT Id, Nome FROM Modelagens ORDER BY Nome", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Modelagem { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar Modelagens: " + ex.Message); }
            return lista;
        }
    }

    // =============================================================
    // 4. CATEGORIA
    // =============================================================
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Categoria> ListarTodas()
        {
            var lista = new List<Categoria>();
            try
            {
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT Id, Nome FROM Categorias ORDER BY Nome", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Categoria { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar Categorias: " + ex.Message); }
            return lista;
        }
    }

    // =============================================================
    // 5. SUBCATEGORIA
    // =============================================================
    public class SubCategoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaPaiId { get; set; }

        public List<SubCategoria> BuscarPorCategoriaPai(int categoriaId)
        {
            var lista = new List<SubCategoria>();
            try
            {
                // AQUI: Corrigido para usar Conexao.ConexãoServidor
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();
                    string sql = "SELECT Id, Nome FROM SubCategorias WHERE CategoriaPaiId = @CatId ORDER BY Nome";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CatId", categoriaId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new SubCategoria { Id = reader.GetInt32("Id"), Nome = reader.GetString("Nome") });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar SubCategorias: " + ex.Message); }
            return lista;
        }
        public DataTable BuscarTamanhosPorSubCategoria(int idSubCategoria)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
                {
                    conn.Open();

                    // Este SQL vai na SubCategoria -> Descobre a Grade -> Pega os Tamanhos
                    string sql = @"
                        SELECT gt.Tamanho, gt.Id 
                        FROM Grades_Tamanhos gt
                        INNER JOIN SubCategorias sc ON sc.GradePadraoId = gt.GradeId
                        WHERE sc.Id = @id
                        ORDER BY gt.OrdemExibicao ASC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idSubCategoria);
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Logar o erro silenciosamente ou mostrar (depende da sua estratégia de Log)
                MessageBox.Show("Erro ao buscar grade de tamanhos: " + ex.Message);
            }
            return dt;
        }
    }
}
    
