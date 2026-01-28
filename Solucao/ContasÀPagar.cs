using System;

namespace Projeto_FinalOficial.Modelos
{
    public class ContaPagar
    {
        // --- Campos do Banco de Dados ---
        public int Id { get; set; }

        public string Descricao { get; set; } // Ex: "Conta de Luz Jan/26"

        // ESSENCIAL PARA O DRE (LUCRO)
        // Valores: "Custo Mercadoria", "Despesa Fixa", "Impostos", etc.
        public string Categoria { get; set; }

        // --- Lógica Híbrida de Fornecedor ---
        public int? FornecedorId { get; set; } // ID se for fornecedor cadastrado (pode ser null)
        public string FavorecidoAvulso { get; set; } // Nome se for conta avulsa (CEMIG, Aluguel)

        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; } // Null = Em aberto
        public string Observacoes { get; set; }

        // --- Propriedades Apenas para Visualização (Não gravam no banco) ---

        // Lógica Inteligente para exibir na Grid
        public string Situacao
        {
            get
            {
                if (DataPagamento != null) return "Paga";
                if (DataVencimento.Date < DateTime.Now.Date) return "Atrasada";
                if (DataVencimento.Date == DateTime.Now.Date) return "Vence Hoje";
                return "A Vencer";
            }
        }

        // Ajuda a exibir o nome certo no Grid sem complicação
        // Nota: O ideal é que a View do SQL já traga esse nome pronto, 
        // mas isso aqui ajuda se você estiver trabalhando com listas em memória.
        public string NomeFavorecidoExibicao
        {
            get { return FornecedorId > 0 ? "Fornecedor Cadastrado (Ver Detalhes)" : FavorecidoAvulso; }
        }
    }
}