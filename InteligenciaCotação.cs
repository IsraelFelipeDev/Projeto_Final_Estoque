using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Projeto_FinalOficial
{
    // ==========================================
    // 1. MODELOS DE DADOS (DTOs)
    // ==========================================

    // CORREÇÃO: Removido ": Service". DTOs não devem herdar de Service (banco de dados).
    public class ItemNecessidade
    {
        public int IdVariacao { get; set; }
        public int QtdNecessaria { get; set; }
    }
    public class FornecedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string EnderecoCompleto { get; set; }
        public decimal TaxaFretePadrao { get; set; }
        public int PrazoEntregaPadrao { get; set; }
    }
    public class ItemTelaPedido
    {
        public int IdVariacao { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; } // Quantidade a Comprar

        // Novas propriedades para exibição
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; }
    }

    public class ItemPedidoFinal
    {
        public int IdVariacao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string NomeProduto { get; set; }
    }

    public class CenarioCotacao
    {
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }

        public int QtdItensAtendidos { get; set; }
        public int QtdTotalDaLista { get; set; }

        public decimal TotalEmProdutos { get; set; }
        public decimal ValorFrete { get; set; }

        public decimal CustoTotalGeral
        {
            get { return TotalEmProdutos + ValorFrete; }
        }

        public int PrazoEntrega { get; set; }
        public List<string> ItensFaltantes { get; set; } = new List<string>();
    }

    // ==========================================
    // 2. ACESSO AO BANCO ESPECÍFICO (DAL)
    // ==========================================

    public class CotacaoDAL : Service
    {
        public DataTable ListarFornecedoresParaCombo()
        {
            // Busca ID e Nome (dando prioridade ao Nome Fantasia, se não tiver, usa Razão Social)
            string sql = @"
                SELECT 
                    Id, 
                    COALESCE(NULLIF(NomeFantasia, ''), RazaoSocial) AS NomeExibicao
                FROM Fornecedores
                ORDER BY NomeExibicao";

            return ExecutarConsultaDataTable(sql, null);
        }
        // =============================================================================
        // MÉTODO 1: BUSCAR OFERTAS (Corrigido para trazer Frete e Prazo)
        // =============================================================================
        public DataTable BuscarOfertasParaLista(List<int> idsVariacao)
        {
            if (idsVariacao == null || idsVariacao.Count == 0) return new DataTable();

            string listaIds = string.Join(",", idsVariacao);

            string sql = $@"
            SELECT 
                pv.Id AS IdVariacao,
                f.Id AS IdFornecedor,
                COALESCE(f.NomeFantasia, f.RazaoSocial) AS NomeFornecedor,
            
             -- AQUI: Pega o preço exato que foi cadastrado no vínculo Fornecedor x Produto
                COALESCE(pfc.PrecoCustoTabela, 0) AS PrecoCustoTabela, 
            
                fc.TaxaFretePadrao, 
                fc.PrazoEntregaDias
                 FROM Produtos_Variacoes pv
                -- O vínculo é feito pelo Produto Pai (ProdutoId)
                INNER JOIN Produtos_Fornecedores_Catalogo pfc ON pv.ProdutoId = pfc.ProdutoPaiId
                INNER JOIN Fornecedores f ON pfc.FornecedorId = f.Id
                LEFT JOIN Fornecedores_Condicoes fc ON f.Id = fc.FornecedorId
                 WHERE pv.Id IN ({listaIds})";

            return ExecutarConsultaDataTable(sql, null);
        }

        // =============================================================================
        // MÉTODO 2: SALVAR PEDIDOS (Transação Manual Necessária)
        // =============================================================================
        public void SalvarPedidosNoBanco(Dictionary<int, List<ItemPedidoFinal>> pedidosAgrupados)
        {
            // Aqui usamos Conexao.ConexãoServidor diretamente pois precisamos controlar a transação
            using (MySqlConnection conexao = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conexao.Open();
                MySqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    foreach (var grupo in pedidosAgrupados)
                    {
                        int idFornecedor = grupo.Key;
                        List<ItemPedidoFinal> itens = grupo.Value;

                        decimal totalPedido = itens.Sum(x => x.Quantidade * x.PrecoUnitario);

                        // 1. Inserir Cabeçalho e pegar ID
                        string sqlHeader = @"INSERT INTO PedidosCompra (FornecedorId, DataPedido, Status, ValorTotal) 
                                             VALUES (@FornId, NOW(), 'Pendente', @Total);
                                             SELECT LAST_INSERT_ID();";

                        MySqlCommand cmdHeader = new MySqlCommand(sqlHeader, conexao, transacao);
                        cmdHeader.Parameters.AddWithValue("@FornId", idFornecedor);
                        cmdHeader.Parameters.AddWithValue("@Total", totalPedido);

                        int idPedidoGerado = Convert.ToInt32(cmdHeader.ExecuteScalar());

                        // 2. Inserir Itens vinculados ao ID gerado
                        foreach (var item in itens)
                        {
                            string sqlItem = @"INSERT INTO ItensPedidoCompra (PedidoId, VariacaoId, Quantidade, CustoUnitario) 
                                               VALUES (@PedId, @VarId, @Qtd, @Custo)";

                            MySqlCommand cmdItem = new MySqlCommand(sqlItem, conexao, transacao);
                            cmdItem.Parameters.AddWithValue("@PedId", idPedidoGerado);
                            cmdItem.Parameters.AddWithValue("@VarId", item.IdVariacao);
                            cmdItem.Parameters.AddWithValue("@Qtd", item.Quantidade);
                            cmdItem.Parameters.AddWithValue("@Custo", item.PrecoUnitario);
                            cmdItem.ExecuteNonQuery();
                        }
                    }
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw new Exception("Erro ao salvar pedidos: " + ex.Message);
                }
            }
        }
        public FornecedorDTO ObterFornecedorPorId(int id)
        {
            // Ajustado para usar Conexao.ConexãoServidor para manter o padrão
            using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conn.Open();
                string sql = "SELECT * FROM Fornecedores WHERE Id = @id";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new FornecedorDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["NomeFantasia"].ToString(),
                                Cnpj = reader["CNPJ"].ToString(),
                                // Concatena endereço se as colunas existirem, senão ajusta conforme seu banco
                                EnderecoCompleto = $"{reader["Rua"]}, {reader["Numero"]} - {reader["Cidade"]}/{reader["Estado"]}",
                                TaxaFretePadrao = 0,
                                PrazoEntregaPadrao = 7
                            };
                        }
                    }
                }
            }
            return new FornecedorDTO { Nome = "Fornecedor Desconhecido" };
        }
        public int SalvarPedidoUnico(int idFornecedor, List<ItemPedidoFinal> itens, decimal frete, int prazo)
        {
            int idGerado = 0;

            // ATENÇÃO: Substitua "Conexao.StringConexao" pela forma como você pega a conexão no seu projeto
            // Se você usa uma classe estática, pode ser ConnectionFactory.Address ou algo assim.
            using (var conn = new MySqlConnection(Conexao.ConexãoServidor))
            {
                conn.Open();
                var trans = conn.BeginTransaction(); // Inicia a transação (Tudo ou Nada)

                try
                {
                    // 1. Insert no Cabeçalho e recupera o ID gerado
                    string sqlCabecalho = @"
                INSERT INTO PedidosCompra (FornecedorId, DataPedido, Status, ValorTotal, ValorFrete, PrazoEntregaDias) 
                VALUES (@idForn, NOW(), 'Pendente', @total, @frete, @prazo);
                SELECT LAST_INSERT_ID();";

                    // Calcula o total apenas dos produtos
                    decimal totalProdutos = itens.Sum(x => x.Quantidade * x.PrecoUnitario);

                    using (var cmd = new MySqlCommand(sqlCabecalho, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@idForn", idFornecedor);
                        cmd.Parameters.AddWithValue("@total", totalProdutos);
                        cmd.Parameters.AddWithValue("@frete", frete);
                        cmd.Parameters.AddWithValue("@prazo", prazo);

                        // Executa e pega o ID do pedido que acabou de ser criado
                        idGerado = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Insert nos Itens do Pedido
                    string sqlItem = @"INSERT INTO ItensPedidoCompra (PedidoId, VariacaoId, Quantidade, CustoUnitario) 
                               VALUES (@pedId, @varId, @qtd, @custo)";

                    foreach (var item in itens)
                    {
                        using (var cmdItem = new MySqlCommand(sqlItem, conn, trans))
                        {
                            cmdItem.Parameters.AddWithValue("@pedId", idGerado);
                            cmdItem.Parameters.AddWithValue("@varId", item.IdVariacao);
                            cmdItem.Parameters.AddWithValue("@qtd", item.Quantidade);
                            cmdItem.Parameters.AddWithValue("@custo", item.PrecoUnitario);
                            cmdItem.ExecuteNonQuery();
                        }
                    }

                    trans.Commit(); // Confirma a gravação no banco
                }
                catch
                {
                    trans.Rollback(); // Se der erro, desfaz tudo para não deixar dados pela metade
                    return 0; // Retorna 0 indicando falha
                }
            }

            return idGerado; // Retorna o ID do pedido (Ex: 502)
        }

        // =============================================================================
        // MÉTODO 3: BUSCAR PRODUTOS (Para o AutoComplete/Grid de pesquisa)
        // =============================================================================
        public DataTable BuscarProdutosParaAdicionar(string termoBusca)
        {
            string sql = @"SELECT IdVariacao, NomeProduto, EstoqueAtual, EstoqueMinimo, EstoqueMaximo 
                           FROM vw_ProdutosDetalhados 
                           WHERE NomeProduto LIKE @Nome 
                           LIMIT 50";

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", "%" + termoBusca + "%" }
            };

            return ExecutarConsultaDataTable(sql, parametros);
        }
    }


    // ==========================================
    // 3. REGRA DE NEGÓCIO
    // ==========================================


    public class ServicoCotacaoInteligente
    {
        private CotacaoDAL _dal = new CotacaoDAL();

       
        
        public List<CenarioCotacao> GerarMelhoresCenarios(List<ItemNecessidade> necessidades)
        {
            var cenariosCalculados = new List<CenarioCotacao>();
            var idsParaBuscar = necessidades.Select(x => x.IdVariacao).ToList();
            DataTable dtOfertas = _dal.BuscarOfertasParaLista(idsParaBuscar);

            if (dtOfertas.Rows.Count == 0) return cenariosCalculados;

            Random rndVariacao = new Random();

            var idsFornecedores = dtOfertas.AsEnumerable()
                                           .Select(row => row.Field<int>("IdFornecedor"))
                                           .Distinct().ToList();

            foreach (var idForn in idsFornecedores)
            {
                var ofertasDoFornecedor = dtOfertas.AsEnumerable()
                                                   .Where(r => r.Field<int>("IdFornecedor") == idForn).ToList();

                var dadosBase = ofertasDoFornecedor.First();
                var cenario = new CenarioCotacao
                {
                    IdFornecedor = idForn,
                    NomeFornecedor = dadosBase.Field<string>("NomeFornecedor"),
                    ValorFrete = dadosBase["TaxaFretePadrao"] == DBNull.Value ? 0m : Convert.ToDecimal(dadosBase["TaxaFretePadrao"]),
                    PrazoEntrega = dadosBase["PrazoEntregaDias"] == DBNull.Value ? 0 : Convert.ToInt32(dadosBase["PrazoEntregaDias"]),
                    QtdTotalDaLista = necessidades.Count
                };

                decimal somaProdutos = 0;
                int itensAtendidos = 0;

                foreach (var itemNec in necessidades)
                {
                    var oferta = ofertasDoFornecedor.FirstOrDefault(r => r.Field<int>("IdVariacao") == itemNec.IdVariacao);
                    if (oferta != null)
                    {
                        // VARIAÇÃO DE MERCADO (±15%) SOBRE O VALOR FIXO DO BANCO
                        decimal precoBanco = Convert.ToDecimal(oferta["PrecoCustoTabela"]);
                        double fator = 0.85 + (rndVariacao.NextDouble() * (1.15 - 0.85));
                        decimal precoComVariação = Math.Round(precoBanco * (decimal)fator, 2);

                        somaProdutos += (precoComVariação * itemNec.QtdNecessaria);
                        itensAtendidos++;
                    }
                    else
                    {
                        cenario.ItensFaltantes.Add($"VarID: {itemNec.IdVariacao}");
                    }
                }

                cenario.TotalEmProdutos = somaProdutos;
                cenario.QtdItensAtendidos = itensAtendidos;

                if (itensAtendidos > 0)
                    cenariosCalculados.Add(cenario);
            }

            return cenariosCalculados.OrderByDescending(c => c.QtdItensAtendidos)
                                     .ThenBy(c => c.CustoTotalGeral)
                                     .ToList();
        }
    }
}
