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

        // Propriedade para Cliente (aceita nulo)
        public int? IdCliente { get; set; }

        // Objeto completo (útil para impressao)
        public Cliente Cliente { get; set; }

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
            // 1. Define a forma de pagamento formatada
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
                // Inicia a transação: tudo deve funcionar ou nada é salvo
                MySqlTransaction transacao = conexao.BeginTransaction();

                try
                {
                    // =========================================================================
                    // ETAPA 1: INSERIR A VENDA (CABEÇALHO)
                    // Nomes das colunas ajustados conforme seu script SQL (Vendas)
                    // =========================================================================
                    string sqlVenda = @"INSERT INTO Vendas 
                                        (id_usuario, Id_Cliente, ID_FluxoCaixa, data_venda, valor_total, forma_pagamento) 
                                        VALUES 
                                        (@id_user, @id_cli, @id_fluxo, @data, @total, @pagamento); 
                                        SELECT LAST_INSERT_ID();";

                    long idVendaGerado = 0;

                    using (MySqlCommand cmd = new MySqlCommand(sqlVenda, conexao, transacao))
                    {
                        cmd.Parameters.AddWithValue("@id_user", this.IdUsuario);

                        // Trata Cliente Nulo (Consumidor Final)
                        if (this.IdCliente.HasValue)
                            cmd.Parameters.AddWithValue("@id_cli", this.IdCliente.Value);
                        else
                            cmd.Parameters.AddWithValue("@id_cli", DBNull.Value);

                        cmd.Parameters.AddWithValue("@id_fluxo", this.IdFluxoCaixa);
                        cmd.Parameters.AddWithValue("@data", this.DataVenda);
                        cmd.Parameters.AddWithValue("@total", this.ValorTotal);
                        cmd.Parameters.AddWithValue("@pagamento", this.FormaPagamento);

                        // Executa e pega o ID gerado
                        idVendaGerado = Convert.ToInt64(cmd.ExecuteScalar());
                        this.Id = (int)idVendaGerado;
                    }

                    // =========================================================================
                    // ETAPA 2: INSERIR ITENS E BAIXAR ESTOQUE
                    // =========================================================================
                    foreach (ItemVenda item in Itens)
                    {
                        // CORREÇÃO CRÍTICA 1: Tabela 'Itens_Venda' e coluna 'id_variacao'
                        // Antes estava 'id_produto', o que gerava o erro.
                        string sqlItem = @"INSERT INTO Itens_Venda 
                                           (id_venda, id_variacao, quantidade, valor_unitario, subtotal) 
                                           VALUES 
                                           (@id_venda, @id_variacao, @qtd, @valor, @sub)";

                        using (MySqlCommand cmdItem = new MySqlCommand(sqlItem, conexao, transacao))
                        {
                            cmdItem.Parameters.AddWithValue("@id_venda", idVendaGerado);
                            // O ID que vem do carrinho já é o da Variação
                            cmdItem.Parameters.AddWithValue("@id_variacao", item.IdProduto);
                            cmdItem.Parameters.AddWithValue("@qtd", item.Quantidade);
                            cmdItem.Parameters.AddWithValue("@valor", item.ValorUnitario);

                            // Calcula subtotal caso não venha preenchido
                            decimal subtotal = item.Quantidade * item.ValorUnitario;
                            cmdItem.Parameters.AddWithValue("@sub", subtotal);

                            cmdItem.ExecuteNonQuery();
                        }

                        // CORREÇÃO CRÍTICA 2: Baixar estoque na tabela 'Produtos_Variacoes'
                        // Antes estava 'Produtos', mas a quantidade fica na tabela de variações.
                        string sqlEstoque = "UPDATE Produtos_Variacoes SET QtdAtual = QtdAtual - @qtd WHERE Id = @idVar";

                        using (MySqlCommand cmdEstoque = new MySqlCommand(sqlEstoque, conexao, transacao))
                        {
                            cmdEstoque.Parameters.AddWithValue("@qtd", item.Quantidade);
                            cmdEstoque.Parameters.AddWithValue("@idVar", item.IdProduto);
                            cmdEstoque.ExecuteNonQuery();
                        }
                    }

                    // Se chegou até aqui sem erro, confirma tudo no banco
                    transacao.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Se deu erro, desfaz tudo
                    transacao.Rollback();
                    throw new Exception("Erro ao realizar venda no banco de dados: " + ex.Message);
                }
            }
        }
    }
}