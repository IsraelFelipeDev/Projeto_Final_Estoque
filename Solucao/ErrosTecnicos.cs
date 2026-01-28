using System;
using System.IO;
using System.Text;
using System.Windows.Forms; // NECESSÁRIO para o MessageBox

namespace Projeto_FinalOficial.Modelos // Ou apenas Projeto_FinalOficial
{
    /// <summary>
    /// Classe responsável por manipular erros técnicos e gravá-los em log.
    /// </summary>
    public class ErrosTecnicos
    {
        // =================================================================
        // PARTE 1: O MÉTODO MÁGICO QUE VOCÊ CHAMA NAS TELAS
        // =================================================================

        /// <summary>
        /// Método estático para ser chamado direto das telas (Try/Catch).
        /// Ele avisa o usuário e grava o log silenciosamente.
        /// </summary>
        public static void Tratar(Exception ex, string mensagemAmigavel)
        {
            // 1. Mostra o erro amigável para o usuário
            MessageBox.Show($"{mensagemAmigavel}\n\nO erro foi registrado no sistema.",
                            "Ops! Algo deu errado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            // 2. Grava o detalhe técnico no arquivo (usando sua lógica abaixo)
            try
            {
                ErrosTecnicos gravador = new ErrosTecnicos();
                gravador.LogErro(ex, mensagemAmigavel);
            }
            catch
            {
                // Se falhar ao gravar o log, não fazemos nada para não assustar mais o usuário
            }
        }

        // =================================================================
        // PARTE 2: A SUA LÓGICA DE GRAVAÇÃO (MANTIDA IGUAL)
        // =================================================================

        private const string NOME_PASTA_LOGS = "RepositorioLogsSistema";
        private readonly string _caminhoPastaCompleto;
        private static readonly object _lockGravacao = new object();

        public ErrosTecnicos()
        {
            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            _caminhoPastaCompleto = Path.Combine(diretorioBase, NOME_PASTA_LOGS);
            GarantirDiretorio();
        }

        private void GarantirDiretorio()
        {
            try
            {
                if (!Directory.Exists(_caminhoPastaCompleto))
                {
                    Directory.CreateDirectory(_caminhoPastaCompleto);
                }
            }
            catch { }
        }

        public void LogErro(Exception ex, string contexto)
        {
            if (!Directory.Exists(_caminhoPastaCompleto)) return;

            try
            {
                string nomeArquivo = $"Log_{DateTime.Now:yyyy-MM-dd}.txt";
                string caminhoArquivoFinal = Path.Combine(_caminhoPastaCompleto, nomeArquivo);

                StringBuilder relatorio = new StringBuilder();
                relatorio.AppendLine("======================================================================");
                relatorio.AppendLine($"[REGISTRO DE ERRO - {DateTime.Now:HH:mm:ss}]");
                relatorio.AppendLine($"CONTEXTO/TELA: {contexto}");
                relatorio.AppendLine("----------------------------------------------------------------------");
                relatorio.AppendLine("MENSAGEM:");
                relatorio.AppendLine(ex.Message);
                relatorio.AppendLine("STACK TRACE:");
                relatorio.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    relatorio.AppendLine();
                    relatorio.AppendLine(">>> INNER EXCEPTION (Detalhes Internos) <<<");
                    relatorio.AppendLine(ex.InnerException.Message);
                    relatorio.AppendLine(ex.InnerException.StackTrace);
                }

                relatorio.AppendLine("======================================================================");
                relatorio.AppendLine(Environment.NewLine);

                lock (_lockGravacao)
                {
                    File.AppendAllText(caminhoArquivoFinal, relatorio.ToString(), Encoding.UTF8);
                }
            }
            catch { }
        }
    }
}