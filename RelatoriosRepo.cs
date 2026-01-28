using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto_FinalOficial
{
    public class RelatorioRepository : Service
    {
        public DataTable ObterDadosEstoque(bool ehSaldo, string filtroProd)
        {
            // Verifica se a View existe no banco. Caso contrário, o Grid ficará vazio.
            string view = ehSaldo ? "vw_EstoqueSaldo" : "vw_EstoqueHistorico";

            // Usamos COALESCE ou garantimos que o filtro não seja nulo
            string sql = $"SELECT * FROM {view} WHERE Produto LIKE @prod";

            var parametros = new Dictionary<string, object> {
                { "@prod", "%" + (filtroProd ?? "") + "%" }
            };

            return ExecutarConsultaDataTable(sql, parametros);
        }

        public DataTable ObterRankingVendedores(bool melhorParaPior, DateTime inicio, DateTime fim, string filtroNome)
        {
            string ordem = melhorParaPior ? "DESC" : "ASC";
            string sql = @"SELECT Vendedor, COUNT(VendaId) as TotalVendas, SUM(ValorVenda) as Total 
                           FROM vw_RankingVendedores 
                           WHERE DataVenda BETWEEN @inicio AND @fim";

            var parametros = new Dictionary<string, object> {
                { "@inicio", inicio.ToString("yyyy-MM-dd 00:00:00") },
                { "@fim", fim.ToString("yyyy-MM-dd 23:59:59") }
            };

            if (!string.IsNullOrEmpty(filtroNome))
            {
                sql += " AND Vendedor LIKE @nome";
                parametros.Add("@nome", "%" + filtroNome + "%");
            }

            sql += $" GROUP BY Vendedor ORDER BY Total {ordem}";
            return ExecutarConsultaDataTable(sql, parametros);
        }
    }
}