using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class UC_Monitoramento : UserControl
    {
        // Instancia o Logger
        private readonly UserLogger _logger = new UserLogger();

        public UC_Monitoramento()
        {
            InitializeComponent();
        }

       

        // Evento LOAD do Formulário
        private void UC_Monitoramento_Load(object sender, EventArgs e)
        {
            CarregarDados();
            ConfigurarGrid();
        }

        // Botão Atualizar (se tiver)
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                // CORREÇÃO AQUI: 
                // Mude de List<UserLogger> para List<UserLogger.LogItem>
                // OU simplesmente use 'var' que é mais prático:

                var listaLogs = _logger.BuscarHistorico();

                // Se quiser escrever por extenso, seria assim:
                // List<UserLogger.LogItem> listaLogs = _logger.BuscarHistorico();

                // Joga no DataGridView
                dgv_Log.DataSource = listaLogs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar logs: " + ex.Message);
            }
        }

        private void ConfigurarGrid()
        {
            // Deixa a grade bonita e renomeia as colunas
            if (dgv_Log.Columns.Count > 0)
            {
                dgv_Log.Columns["Id"].Width = 50;

                dgv_Log.Columns["NomeUsuario"].HeaderText = "Usuário";
                dgv_Log.Columns["NomeUsuario"].Width = 150;

                dgv_Log.Columns["Acao"].HeaderText = "Ação Realizada";
                dgv_Log.Columns["Acao"].Width = 250;

                dgv_Log.Columns["Formulario"].HeaderText = "Tela";
                dgv_Log.Columns["Formulario"].Width = 150;

                dgv_Log.Columns["DataHora"].HeaderText = "Data/Hora";
                dgv_Log.Columns["DataHora"].Width = 150;
                dgv_Log.Columns["DataHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Formatação BR
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}