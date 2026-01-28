using Projeto_FinalOficial.Modelos; // Certifique-se que o namespace está correto
using System;
using System.Collections.Generic;
using System.Drawing; // Necessário para alterar Fontes
using System.Linq;    // Necessário para os filtros (Where)
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_Monitoramento : UserControl
    {
        private readonly UserLogger _logger = new UserLogger();

        public UC_Monitoramento()
        {
            InitializeComponent();
        }

        private void UC_Monitoramento_Load(object sender, EventArgs e)
        {
            // Carrega os dados iniciais e depois configura o visual
            CarregarDados();
            ConfigurarVisualGrid();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // O botão buscar agora aplica os filtros
            CarregarDados(filtrar: true);
        }

        /// <summary>
        /// Carrega os dados do banco e aplica filtros se necessário
        /// </summary>
        /// <param name="filtrar">Define se deve aplicar os filtros de tela</param>
        private void CarregarDados(bool filtrar = false)
        {
            try
            {
                // 1. Busca TODO o histórico original do Logger
                var listaCompleta = _logger.BuscarHistorico();

                // 2. Se não houver dados, para por aqui
                if (listaCompleta == null || listaCompleta.Count == 0)
                {
                    dgv_Log.DataSource = null;
                    return;
                }

                var listaFiltrada = listaCompleta;

                // 3. Aplica a Lógica de Filtro se o botão Buscar foi clicado
                if (filtrar)
                {
                    // Filtro por NOME (se tiver algo escrito)
                    string termoBusca = txt_BuscaNome.Text.Trim().ToLower();
                    if (!string.IsNullOrEmpty(termoBusca))
                    {
                        listaFiltrada = listaFiltrada
                            .Where(x => x.NomeUsuario.ToLower().Contains(termoBusca))
                            .ToList();
                    }

                    // Filtro por DATA (Compara apenas a Data, ignora as horas)
                    // Nota: Assume-se que o DateTimePicker se chama 'dtp_BuscaData'
                    DateTime dataSelecionada = dtp_BuscaData.Value.Date;
                    listaFiltrada = listaFiltrada
                        .Where(x => x.DataHora.Date == dataSelecionada)
                        .ToList();
                }

                // 4. Atualiza o Grid
                dgv_Log.DataSource = null; // Limpa para evitar conflitos de atualização
                dgv_Log.DataSource = listaFiltrada;

                // 5. Reaplica a configuração visual (importante após mudar o DataSource)
                ConfigurarVisualGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar logs: " + ex.Message);
            }
        }

        private void ConfigurarVisualGrid()
        {
            // Verifica se existem colunas para configurar
            if (dgv_Log.Columns.Count == 0) return;

            // =========================================================
            // ESTILIZAÇÃO GERAL
            // =========================================================
            dgv_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Preenche tudo
            dgv_Log.RowTemplate.Height = 40; // Linhas mais altas para facilitar leitura
            dgv_Log.ColumnHeadersHeight = 45; // Cabeçalho mais alto

            // Fontes Maiores
            dgv_Log.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgv_Log.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgv_Log.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // =========================================================
            // CONFIGURAÇÃO DAS COLUNAS
            // =========================================================

            // 1. Coluna ID -> virou "Registro"
            if (dgv_Log.Columns.Contains("Id"))
            {
                dgv_Log.Columns["Id"].HeaderText = "Registro";
                dgv_Log.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Log.Columns["Id"].FillWeight = 10; // Ocupa pouco espaço (10%)
            }

            // 2. Coluna Usuário
            if (dgv_Log.Columns.Contains("NomeUsuario"))
            {
                dgv_Log.Columns["NomeUsuario"].HeaderText = "Usuário";
                dgv_Log.Columns["NomeUsuario"].FillWeight = 20; // Ocupa 20%
            }

            // 3. Coluna Ação (ÊNFASE)
            if (dgv_Log.Columns.Contains("Acao"))
            {
                dgv_Log.Columns["Acao"].HeaderText = "Ação Realizada";
                dgv_Log.Columns["Acao"].FillWeight = 45; // Ocupa a maior parte (45%)
            }

            // 4. Coluna Tela
            if (dgv_Log.Columns.Contains("Formulario"))
            {
                dgv_Log.Columns["Formulario"].HeaderText = "Tela";
                dgv_Log.Columns["Formulario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Log.Columns["Formulario"].FillWeight = 10; // Ocupa 10%
            }

            // 5. Coluna Data/Hora
            if (dgv_Log.Columns.Contains("DataHora"))
            {
                dgv_Log.Columns["DataHora"].HeaderText = "Data/Hora";
                dgv_Log.Columns["DataHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgv_Log.Columns["DataHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Log.Columns["DataHora"].FillWeight = 15; // Ocupa 15%
            }
        }
    }
}