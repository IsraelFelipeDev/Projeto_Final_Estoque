namespace Projeto_FinalOficial
{
    partial class UC_Monitoramento
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_BuscaData = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txt_BuscaNome = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgv_Log = new System.Windows.Forms.DataGridView();
            this.btn_Buscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelSombreado1 = new PanelSombreado();
            this.panelSombreado2 = new PanelSombreado();
            this.panelSombreado3 = new PanelSombreado();
            this.panelSombreado4 = new PanelSombreado();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).BeginInit();
            this.panelSombreado1.SuspendLayout();
            this.panelSombreado2.SuspendLayout();
            this.panelSombreado3.SuspendLayout();
            this.panelSombreado4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 31);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Fixo";
            this.label1.Text = "Monitoramento do Fluxo Operacional";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar por Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(446, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Buscar por periodo";
            // 
            // dtp_BuscaData
            // 
            this.dtp_BuscaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_BuscaData.Location = new System.Drawing.Point(625, 94);
            this.dtp_BuscaData.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_BuscaData.Name = "dtp_BuscaData";
            this.dtp_BuscaData.Size = new System.Drawing.Size(174, 29);
            this.dtp_BuscaData.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtp_BuscaData.StateCommon.Border.Rounding = 5;
            this.dtp_BuscaData.TabIndex = 3;
            // 
            // txt_BuscaNome
            // 
            this.txt_BuscaNome.Location = new System.Drawing.Point(182, 98);
            this.txt_BuscaNome.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BuscaNome.Name = "txt_BuscaNome";
            this.txt_BuscaNome.Size = new System.Drawing.Size(225, 31);
            this.txt_BuscaNome.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_BuscaNome.StateCommon.Border.Rounding = 5;
            this.txt_BuscaNome.TabIndex = 2;
            // 
            // dgv_Log
            // 
            this.dgv_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Log.Location = new System.Drawing.Point(21, 156);
            this.dgv_Log.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Log.Name = "dgv_Log";
            this.dgv_Log.RowHeadersWidth = 51;
            this.dgv_Log.Size = new System.Drawing.Size(910, 401);
            this.dgv_Log.TabIndex = 4;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.AutoSize = true;
            this.btn_Buscar.Location = new System.Drawing.Point(820, 91);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(129, 32);
            this.btn_Buscar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Buscar.StateCommon.Border.Rounding = 5;
            this.btn_Buscar.TabIndex = 5;
            this.btn_Buscar.Values.Text = "Buscar";
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // panelSombreado1
            // 
            this.panelSombreado1.BackColor = System.Drawing.Color.White;
            this.panelSombreado1.Controls.Add(this.label1);
            this.panelSombreado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado1.Location = new System.Drawing.Point(0, 0);
            this.panelSombreado1.Name = "panelSombreado1";
            this.panelSombreado1.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado1.Size = new System.Drawing.Size(979, 66);
            this.panelSombreado1.TabIndex = 6;
            // 
            // panelSombreado2
            // 
            this.panelSombreado2.BackColor = System.Drawing.Color.White;
            this.panelSombreado2.Controls.Add(this.panelSombreado3);
            this.panelSombreado2.Controls.Add(this.panelSombreado4);
            this.panelSombreado2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSombreado2.Location = new System.Drawing.Point(0, 0);
            this.panelSombreado2.Name = "panelSombreado2";
            this.panelSombreado2.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado2.Size = new System.Drawing.Size(979, 621);
            this.panelSombreado2.TabIndex = 7;
            // 
            // panelSombreado3
            // 
            this.panelSombreado3.BackColor = System.Drawing.Color.White;
            this.panelSombreado3.Controls.Add(this.label2);
            this.panelSombreado3.Controls.Add(this.btn_Buscar);
            this.panelSombreado3.Controls.Add(this.txt_BuscaNome);
            this.panelSombreado3.Controls.Add(this.dtp_BuscaData);
            this.panelSombreado3.Controls.Add(this.label3);
            this.panelSombreado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado3.Location = new System.Drawing.Point(2, 2);
            this.panelSombreado3.Margin = new System.Windows.Forms.Padding(0);
            this.panelSombreado3.Name = "panelSombreado3";
            this.panelSombreado3.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado3.Size = new System.Drawing.Size(965, 144);
            this.panelSombreado3.TabIndex = 8;
            // 
            // panelSombreado4
            // 
            this.panelSombreado4.BackColor = System.Drawing.Color.White;
            this.panelSombreado4.Controls.Add(this.dgv_Log);
            this.panelSombreado4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSombreado4.Location = new System.Drawing.Point(2, 2);
            this.panelSombreado4.Name = "panelSombreado4";
            this.panelSombreado4.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado4.Size = new System.Drawing.Size(965, 607);
            this.panelSombreado4.TabIndex = 9;
            // 
            // UC_Monitoramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSombreado1);
            this.Controls.Add(this.panelSombreado2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Monitoramento";
            this.Size = new System.Drawing.Size(979, 621);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).EndInit();
            this.panelSombreado1.ResumeLayout(false);
            this.panelSombreado1.PerformLayout();
            this.panelSombreado2.ResumeLayout(false);
            this.panelSombreado3.ResumeLayout(false);
            this.panelSombreado3.PerformLayout();
            this.panelSombreado4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtp_BuscaData;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_BuscaNome;
        private System.Windows.Forms.DataGridView dgv_Log;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Buscar;
        private PanelSombreado panelSombreado1;
        private PanelSombreado panelSombreado2;
        private PanelSombreado panelSombreado3;
        private PanelSombreado panelSombreado4;
    }
}
