using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    // Exemplo de como deve ser a classe que você vai passar para o método
    public class PedidoCompraImpressao
    {
        public int IdPedido { get; set; }
        public DateTime DataEmissao { get; set; }
        public decimal ValorFrete { get; set; }
        public int PrazoEntregaDias { get; set; }

        // Dados do Fornecedor (Remetente)
        public string FornecedorNome { get; set; }
        public string FornecedorCNPJ { get; set; }
        public string FornecedorEndereco { get; set; }

        // Dados da Loja (Destinatário)
        public string LojaNome { get; set; }
        public string LojaCNPJ { get; set; }
        public string LojaEndereco { get; set; }
        

        public List<ItemPedidoImpressao> Itens { get; set; } = new List<ItemPedidoImpressao>();

        public decimal TotalProdutos => Itens.Sum(x => x.Total);
        public decimal TotalGeral => TotalProdutos + ValorFrete;
    }

    public class ItemPedidoImpressao
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; } // UN, CX, KG
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        

        public decimal Total => Quantidade * ValorUnitario;
    }
}
