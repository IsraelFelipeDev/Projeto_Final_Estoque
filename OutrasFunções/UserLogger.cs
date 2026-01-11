using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Projeto_FinalOficial.Sessao;

namespace Projeto_FinalOficial
{

    public class UserLogger : Service
    {

        public class LogItem
        {
            public int Id { get; set; }
            public string NomeUsuario { get; set; }
            public string Acao { get; set; }
            public string Formulario { get; set; }
            public DateTime DataHora { get; set; }
        }

        // O método "Raiz" que faz o insert (mantém igual)
        private void GravarNoBanco(string acao, string nomeFormulario)
        {
            string query = "INSERT INTO log_sistema (nome_usuario, acao, formulario, data_hora) VALUES (@nome, @acao, @form, @data)";

            // Tratamento para evitar erro se nome for nulo
            string nomeUsuario = !string.IsNullOrEmpty(Sessão.Nome) ? Sessão.Nome : "Desconhecido";

            var parametros = new Dictionary<string, object>
            {
                { "@nome", nomeUsuario },
                { "@acao", acao },
                { "@form", nomeFormulario },
                { "@data", DateTime.Now }
            };

            try
            {
                this.ExecutarComando(query, parametros);
            }
            catch { /* Silencioso */ }
        }

        // --- MÉTODOS CORRIGIDOS (ACEITAM CONTROL AO INVÉS DE FORM) ---

        // Método auxiliar para descobrir o nome da tela (Form pai)
        private string ObterNomeTela(Control contexto)
        {
            if (contexto == null) return "Desconhecido";

            // Se o contexto JÁ É um Form, retorna o nome dele
            if (contexto is Form f) return f.Name;

            // Se for um UserControl ou Botão, procura o Form Pai dele
            Form formPai = contexto.FindForm();
            return formPai != null ? formPai.Name : contexto.Name;
        }

        // 1. Log de Clique (Genérico)
        public void LogClick(object sender, Control contexto)
        {
            string textoBotao = "Elemento desconhecido";

            if (sender is Control controle)
            {
                // Tenta pegar o texto, se não tiver, pega o nome do código
                textoBotao = !string.IsNullOrEmpty(controle.Text) ? controle.Text : controle.Name;
            }

            string nomeTela = ObterNomeTela(contexto);
            GravarNoBanco($"Clicou em '{textoBotao}'", nomeTela);
        }

        // 2. Log de Abertura (Load)
        public void LogOpen(Control contexto)
        {
            // Tenta pegar o título da janela (Text), se falhar pega o Name
            string titulo = contexto is Form frm ? frm.Text : contexto.Name;
            string nomeTela = ObterNomeTela(contexto);

            GravarNoBanco($"Abriu a tela '{titulo}'", nomeTela);
        }

        // 3. Log de Fechamento
        public void LogClose(Control contexto)
        {
            string titulo = contexto is Form frm ? frm.Text : contexto.Name;
            string nomeTela = ObterNomeTela(contexto);

            GravarNoBanco($"Fechou a tela '{titulo}'", nomeTela);
        }

        public List<LogItem> BuscarHistorico()
        {
            string sql = "SELECT * FROM log_sistema ORDER BY data_hora DESC LIMIT 500";
            return this.ExecutarConsulta(sql, MapearLog);
        }

        private LogItem MapearLog(MySqlDataReader reader)
        {
            return new LogItem
            {
                Id = Convert.ToInt32(reader["id"]),
                NomeUsuario = reader["nome_usuario"].ToString(),
                Acao = reader["acao"].ToString(),
                Formulario = reader["formulario"].ToString(),
                DataHora = reader["data_hora"] != DBNull.Value ? Convert.ToDateTime(reader["data_hora"]) : DateTime.MinValue
            };
        }
    }
}


