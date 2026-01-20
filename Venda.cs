using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_FinalOficial.Modelos
{
    public class Venda
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdFluxoCaixa { get; set; }

        // --- NOVIDADE 1: Adicionando as propriedades do Cliente ---
        // O '?' significa que aceita NULL (para Consumidor Final)
        public int? IdCliente { get; set; }

        // Objeto completo (útil para a impressão)
        public Cliente Cliente { get; set; }
        // ----------------------------------------------------------

        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
        public List<PagamentoVenda> Pagamentos { get; set; } = new List<PagamentoVenda>();
        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

        public Venda()
        {
            DataVenda = DateTime.Now;
        }

        public class PagamentoVenda
        {
            public string TipoPagamento { get; set; }
            public decimal Valor { get; set; }
        }

        public bool RealizarVendaCompleta()
        {
            // Lógica para definir a string da forma de pagamento
            if (Pagamentos != null && Pagamentos.Count > 0)
            {
                var tiposDistintos = Pagamentos.Select(p => p.TipoPagamento).Distinct();
                this.FormaPagamento = string.Join(" + ", tiposDistintos);
            }
            else
            {
                if (string.IsNullOrEmpty(this.FormaPagamento)) this.FormaPagamento = "Dinheiro";
            }

            string strConexao = Conexao.ConexãoServidor;

            using (MySqlConnection conexao = new MySqlConnection(strConexao))
            {
                conexao.Open();
                MySqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    // --- NOVIDADE 2: Atualizando o SQL para incluir id_cliente ---
                    string sqlVenda = @"INSERT INTO vendas 
                                        (id_usuario, id_cliente, id_fluxocaixa, data_venda, valor_total, forma_pagamento) 
                                        VALUES 
                                        (@id_user, @id_cli, @id_fluxo, @data, @total, @pagamento); 
                                        SELECT LAST_INSERT_ID();";

                    long idVendaGerado = 0;

                    using (MySqlCommand cmd = new MySqlCommand(sqlVenda, conexao, transacao))
                    {
                        cmd.Parameters.AddWithValue("@id_user", this.IdUsuario);

                        // --- LÓGICA PARA ID NULO ---
                        // Se IdCliente tiver valor, passa o valor. Se for null, passa DBNull.Value pro banco.
                        if (this.IdCliente.HasValue)
                            cmd.Parameters.AddWithValue("@id_cli", this.IdCliente.Value);
                        else
                            cmd.Parameters.AddWithValue("@id_cli", DBNull.Value);
                        // ---------------------------

                        cmd.Parameters.AddWithValue("@id_fluxo", this.IdFluxoCaixa);
                        cmd.Parameters.AddWithValue("@data", this.DataVenda);
                        cmd.Parameters.AddWithValue("@total", this.ValorTotal);
                        cmd.Parameters.AddWithValue("@pagamento", this.FormaPagamento);

                        idVendaGerado = Convert.ToInt64(cmd.ExecuteScalar());
                        this.Id = (int)idVendaGerado;
                    }

                    // GRAVA OS ITENS (Sem alterações aqui)
                    foreach (ItemVenda item in Itens)
                    {
                        string sqlItem = @"INSERT INTO Itens_Venda 
                                           (id_venda, id_produto, quantidade, valor_unitario, subtotal) 
                                           VALUES 
                                           (@id_venda, @id_prod, @qtd, @valor, @sub)";

                        using (MySqlCommand cmdItem = new MySqlCommand(sqlItem, conexao, transacao))
                        {
                            cmdItem.Parameters.AddWithValue("@id_venda", idVendaGerado);
                            cmdItem.Parameters.AddWithValue("@id_prod", item.IdProduto);
                            cmdItem.Parameters.AddWithValue("@qtd", item.Quantidade);
                            cmdItem.Parameters.AddWithValue("@valor", item.ValorUnitario);
                            cmdItem.Parameters.AddWithValue("@sub", item.Subtotal);
                            cmdItem.ExecuteNonQuery();
                        }

                        // BAIXA ESTOQUE (Verifique se os nomes das colunas estão corretos no seu banco)
                        string sqlEstoque = "UPDATE Produtos SET QtdAtual = QtdAtual - @qtd WHERE Id = @idProd";
                        using (MySqlCommand cmdEstoque = new MySqlCommand(sqlEstoque, conexao, transacao))
                        {
                            cmdEstoque.Parameters.AddWithValue("@qtd", item.Quantidade);
                            cmdEstoque.Parameters.AddWithValue("@idProd", item.IdProduto);
                            cmdEstoque.ExecuteNonQuery();
                        }
                    }

                    transacao.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw new Exception("Erro ao realizar venda: " + ex.Message);
                }
            }
        }
    }
}