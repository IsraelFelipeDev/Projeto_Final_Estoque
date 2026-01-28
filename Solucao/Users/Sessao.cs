using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_FinalOficial
{
    // 1. A classe é 'static'. Não precisa instanciar (new Sessao()).
    // Agora você acessa direto: Sessao.NomeUsuario
    public static class Sessao
    {
        public static int ID { get; set; } // Mudei de Id para UserID para ser mais específico
        public static string Nome { get; set; } // Mudei de Nome para NomeUsuario para evitar confusão
        public static string Cargo { get; set; }

        // Se for 0, significa que NÃO tem caixa aberto nesta sessão.
        // Se for > 0, é o ID do caixa aberto no banco.
        public static int IDCaixaAtual { get; set; } = 0;

        // Método para limpar os dados quando o usuário clica em "Sair" ou "Logout"
        public static void Logout()
        {
            ID = 0;
            Nome = string.Empty;
            Cargo = string.Empty;

            // CRÍTICO: Zerar o ID do caixa na memória.
            // (Nota: Isso não fecha o caixa no banco, apenas desconecta o usuário atual dele)
            IDCaixaAtual = 0;
        }

        // Helper opcional para verificar rápido se tem alguém logado
        public static bool EstaLogado()
        {
            return ID > 0;
        }
    }
}