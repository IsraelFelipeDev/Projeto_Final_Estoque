using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Projeto_FinalOficial
{
    // =============================================================================
    // 1. CLASSE AUXILIAR ÚNICA
    // =============================================================================
    public class ItemComboCategoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }

    // =============================================================================
    // 2. CLASSE DE SERVIÇO (Lógica de Banco de Dados)
    // =============================================================================
    public class CadastroFornecedor : Service
    {
        // --- LEITURA ---

        public DataTable ListarCategorias()
        {
            string sql = "SELECT Id, Nome FROM Categorias ORDER BY Nome ASC";
            return ExecutarConsultaDataTable(sql);
        }

        public DataTable ListarProdutosPorNomesDeCategoria(List<string> nomesCategorias)
        {
            if (nomesCategorias == null || nomesCategorias.Count == 0) return null;

            StringBuilder sb = new StringBuilder();
            // Buscamos as colunas necessárias para o Grid
            sb.Append("SELECT Id, Nome, Categoria, SubCategoria, ValorCompra FROM Produtos WHERE Categoria IN (");

            for (int i = 0; i < nomesCategorias.Count; i++)
            {
                string nomeTratado = nomesCategorias[i].Replace("'", "''");
                sb.Append($"'{nomeTratado}'");
                if (i < nomesCategorias.Count - 1) sb.Append(",");
            }
            sb.Append(") ORDER BY Nome");

            return ExecutarConsultaDataTable(sb.ToString());
        }

        // --- ESCRITA (TRANSAÇÃO COMPLETA) ---

        public bool SalvarFornecedorCompleto(
    string nomeFantasia, string razao, string cnpj, string telefone,
    string cep, string cidade, string estado, string rua, string bairro, string numero,
    List<int> idsCategoriasMarcadas,
    DataTable dtProdutosDoGrid)
        {
            using (MySqlConnection con = new MySqlConnection(Conexao.ConexãoServidor))
            {
                con.Open();
                MySqlTransaction trans = con.BeginTransaction();

                try
                {
                    // [A] Inserir Fornecedor
                    string sqlForn = @"INSERT INTO Fornecedores 
                              (NomeFantasia, RazaoSocial, CNPJ, Telefone, CEP, Cidade, Estado, Rua, Bairro, Numero) 
                              VALUES (@Nome, @Razao, @CNPJ, @Tel, @CEP, @Cid, @UF, @Rua, @Bairro, @Num);
                              SELECT LAST_INSERT_ID();";

                    int idFornecedor;
                    using (var cmd = new MySqlCommand(sqlForn, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nomeFantasia);
                        cmd.Parameters.AddWithValue("@Razao", razao);
                        cmd.Parameters.AddWithValue("@CNPJ", cnpj);
                        cmd.Parameters.AddWithValue("@Tel", telefone);
                        cmd.Parameters.AddWithValue("@CEP", cep);
                        cmd.Parameters.AddWithValue("@Cid", cidade);
                        cmd.Parameters.AddWithValue("@UF", estado);
                        cmd.Parameters.AddWithValue("@Rua", rua);
                        cmd.Parameters.AddWithValue("@Bairro", bairro);
                        cmd.Parameters.AddWithValue("@Num", numero);
                        idFornecedor = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // [B] Inserir Condições Gerais (Frete e Prazo Padrão)
                    if (dtProdutosDoGrid.Rows.Count > 0)
                    {
                        string sqlCond = @"INSERT INTO Fornecedores_Condicoes 
                                  (FornecedorId, PrazoEntregaDias, TaxaFretePadrao) 
                                  VALUES (@fid, @prazo, @frete)";
                        using (var cmd = new MySqlCommand(sqlCond, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@fid", idFornecedor);
                            // Pega o valor da primeira linha, pois na sua UI o frete/prazo é único por fornecedor
                            cmd.Parameters.AddWithValue("@prazo", dtProdutosDoGrid.Rows[0]["Prazo"]);
                            cmd.Parameters.AddWithValue("@frete", dtProdutosDoGrid.Rows[0]["Frete"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // [C] Inserir Vínculo de Categorias (Tabela Fornecedores_Categorias)
                    string sqlCatForn = "INSERT INTO Fornecedores_Categorias (FornecedorId, CategoriaId) VALUES (@fid, @cid)";
                    foreach (int idCat in idsCategoriasMarcadas)
                    {
                        using (var cmd = new MySqlCommand(sqlCatForn, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@fid", idFornecedor);
                            cmd.Parameters.AddWithValue("@cid", idCat);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // [D] Inserir Catálogo de Produtos (Apenas Preço de Custo)
                    string sqlCatalogo = @"INSERT INTO Produtos_Fornecedores_Catalogo 
                                 (ProdutoPaiId, FornecedorId, PrecoCustoTabela) 
                                 VALUES (@pid, @fid, @preco)";

                    foreach (DataRow row in dtProdutosDoGrid.Rows)
                    {
                        using (var cmd = new MySqlCommand(sqlCatalogo, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@pid", row["ProdutoId"]);
                            cmd.Parameters.AddWithValue("@fid", idFornecedor);
                            cmd.Parameters.AddWithValue("@preco", row["PrecoCusto"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw; // Repassa o erro para a UI tratar
                }
            }
        }
    }
}