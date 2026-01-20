using System;

namespace Projeto_FinalOficial.Modelos // Certifique-se que o namespace está correto
{
    public class ItemVenda
    {
        // --- Propriedades que vão para o Banco de Dados (Tabela itens_venda) ---
        public int Id { get; set; }           // ID único do item (Auto Increment)
        public int IdVenda { get; set; }      // ID da Venda (FK)
        public int IdProduto { get; set; }    // ID do Produto (FK)
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        // --- Propriedade Calculada (Lógica de Negócio) ---
        // Retorna a multiplicação automática.
        // Resolve o erro "Propriedade somente leitura" pois não tentamos escrever nela, apenas ler.
        public decimal Subtotal
        {
            get { return Quantidade * ValorUnitario; }
        }

        // --- Propriedades Auxiliares (Apenas para Visualização na Tela e Cupom) ---
        // Não salvamos isso na tabela 'itens_venda' (pois já tem o IdProduto),
        // mas precisamos guardar aqui para exibir no Grid e imprimir no Cupom.
        public string NomeProduto { get; set; }
        public string Cor { get; set; }
    }
}