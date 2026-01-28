namespace Projeto_FinalOficial
{
    partial class UC_Relatorio
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Relatorio));
            this.panelSombreado1 = new PanelSombreado();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSombreado2 = new PanelSombreado();
            this.rd_PiorVendedor = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.chartVendas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnMenuEstoque = new FontAwesome.Sharp.IconButton();
            this.btnMenuVendas = new FontAwesome.Sharp.IconButton();
            this.pnlVendas = new PanelSombreado();
            this.pnlEstoque = new PanelSombreado();
            this.rbHistorico = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbSaldo = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btn_BuscarProd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_BuscarProd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgv_RelEstoque = new System.Windows.Forms.DataGridView();
            this.rd_MelhorVendedor = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnFiltrarVendas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltroVendedor = new System.Windows.Forms.Label();
            this.txt_BuscarVendedor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.panelSombreado3 = new PanelSombreado();
            this.panelSombreado1.SuspendLayout();
            this.panelSombreado2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendas)).BeginInit();
            this.pnlVendas.SuspendLayout();
            this.pnlEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RelEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.panelSombreado3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSombreado1
            // 
            this.panelSombreado1.BackColor = System.Drawing.Color.White;
            this.panelSombreado1.Controls.Add(this.label1);
            this.panelSombreado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado1.Location = new System.Drawing.Point(0, 0);
            this.panelSombreado1.Name = "panelSombreado1";
            this.panelSombreado1.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado1.Size = new System.Drawing.Size(1482, 77);
            this.panelSombreado1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relatorios";
            // 
            // panelSombreado2
            // 
            this.panelSombreado2.BackColor = System.Drawing.Color.White;
            this.panelSombreado2.Controls.Add(this.chartVendas);
            this.panelSombreado2.Controls.Add(this.btnMenuEstoque);
            this.panelSombreado2.Controls.Add(this.btnMenuVendas);
            this.panelSombreado2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSombreado2.Location = new System.Drawing.Point(0, 77);
            this.panelSombreado2.Name = "panelSombreado2";
            this.panelSombreado2.Padding = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.panelSombreado2.Size = new System.Drawing.Size(203, 765);
            this.panelSombreado2.TabIndex = 0;
            // 
            // rd_PiorVendedor
            // 
            this.rd_PiorVendedor.Location = new System.Drawing.Point(657, 21);
            this.rd_PiorVendedor.Name = "rd_PiorVendedor";
            this.rd_PiorVendedor.Size = new System.Drawing.Size(105, 24);
            this.rd_PiorVendedor.TabIndex = 13;
            this.rd_PiorVendedor.Values.Text = "Melhor Des.";
            this.rd_PiorVendedor.CheckedChanged += new System.EventHandler(this.rd_PiorVendedor_CheckedChanged);
            // 
            // chartVendas
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVendas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVendas.Legends.Add(legend2);
            this.chartVendas.Location = new System.Drawing.Point(79, 217);
            this.chartVendas.Name = "chartVendas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVendas.Series.Add(series2);
            this.chartVendas.Size = new System.Drawing.Size(10, 31);
            this.chartVendas.TabIndex = 0;
            this.chartVendas.Text = "chart1";
            // 
            // btnMenuEstoque
            // 
            this.btnMenuEstoque.BackColor = System.Drawing.Color.Silver;
            this.btnMenuEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuEstoque.FlatAppearance.BorderSize = 0;
            this.btnMenuEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuEstoque.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMenuEstoque.IconColor = System.Drawing.Color.Black;
            this.btnMenuEstoque.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenuEstoque.Location = new System.Drawing.Point(2, 48);
            this.btnMenuEstoque.Name = "btnMenuEstoque";
            this.btnMenuEstoque.Size = new System.Drawing.Size(198, 46);
            this.btnMenuEstoque.TabIndex = 2;
            this.btnMenuEstoque.Text = "Estoque";
            this.btnMenuEstoque.UseVisualStyleBackColor = false;
            this.btnMenuEstoque.Click += new System.EventHandler(this.btnMenuEstoque_Click);
            // 
            // btnMenuVendas
            // 
            this.btnMenuVendas.BackColor = System.Drawing.Color.Silver;
            this.btnMenuVendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuVendas.FlatAppearance.BorderSize = 0;
            this.btnMenuVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuVendas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMenuVendas.IconColor = System.Drawing.Color.Black;
            this.btnMenuVendas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenuVendas.Location = new System.Drawing.Point(2, 2);
            this.btnMenuVendas.Name = "btnMenuVendas";
            this.btnMenuVendas.Size = new System.Drawing.Size(198, 46);
            this.btnMenuVendas.TabIndex = 0;
            this.btnMenuVendas.Text = "Vendas";
            this.btnMenuVendas.UseVisualStyleBackColor = false;
            this.btnMenuVendas.Click += new System.EventHandler(this.btnMenuVendas_Click);
            // 
            // pnlVendas
            // 
            this.pnlVendas.BackColor = System.Drawing.Color.White;
            this.pnlVendas.Controls.Add(this.rd_PiorVendedor);
            this.pnlVendas.Controls.Add(this.pnlEstoque);
            this.pnlVendas.Controls.Add(this.rd_MelhorVendedor);
            this.pnlVendas.Controls.Add(this.btnFiltrarVendas);
            this.pnlVendas.Controls.Add(this.label5);
            this.pnlVendas.Controls.Add(this.label4);
            this.pnlVendas.Controls.Add(this.txtFiltroVendedor);
            this.pnlVendas.Controls.Add(this.txt_BuscarVendedor);
            this.pnlVendas.Controls.Add(this.dtpInicio);
            this.pnlVendas.Controls.Add(this.dtpFim);
            this.pnlVendas.Controls.Add(this.dgvVendas);
            this.pnlVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVendas.Location = new System.Drawing.Point(2, 2);
            this.pnlVendas.Name = "pnlVendas";
            this.pnlVendas.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.pnlVendas.Size = new System.Drawing.Size(1265, 751);
            this.pnlVendas.TabIndex = 1;
            // 
            // pnlEstoque
            // 
            this.pnlEstoque.BackColor = System.Drawing.Color.White;
            this.pnlEstoque.Controls.Add(this.rbHistorico);
            this.pnlEstoque.Controls.Add(this.rbSaldo);
            this.pnlEstoque.Controls.Add(this.btn_BuscarProd);
            this.pnlEstoque.Controls.Add(this.label6);
            this.pnlEstoque.Controls.Add(this.txt_BuscarProd);
            this.pnlEstoque.Controls.Add(this.dgv_RelEstoque);
            this.pnlEstoque.Location = new System.Drawing.Point(32, 397);
            this.pnlEstoque.Name = "pnlEstoque";
            this.pnlEstoque.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.pnlEstoque.Size = new System.Drawing.Size(1221, 342);
            this.pnlEstoque.TabIndex = 10;
            // 
            // rbHistorico
            // 
            this.rbHistorico.Location = new System.Drawing.Point(678, 20);
            this.rbHistorico.Name = "rbHistorico";
            this.rbHistorico.Size = new System.Drawing.Size(112, 24);
            this.rbHistorico.TabIndex = 11;
            this.rbHistorico.Values.Text = "Por Historico";
            this.rbHistorico.CheckedChanged += new System.EventHandler(this.rbHistorico_CheckedChanged);
            // 
            // rbSaldo
            // 
            this.rbSaldo.Location = new System.Drawing.Point(570, 19);
            this.rbSaldo.Name = "rbSaldo";
            this.rbSaldo.Size = new System.Drawing.Size(89, 24);
            this.rbSaldo.TabIndex = 10;
            this.rbSaldo.Values.Text = "Por Saldo";
            this.rbSaldo.CheckedChanged += new System.EventHandler(this.rbSaldo_CheckedChanged);
            // 
            // btn_BuscarProd
            // 
            this.btn_BuscarProd.Location = new System.Drawing.Point(864, 11);
            this.btn_BuscarProd.Name = "btn_BuscarProd";
            this.btn_BuscarProd.Size = new System.Drawing.Size(136, 40);
            this.btn_BuscarProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_BuscarProd.StateCommon.Border.Rounding = 10;
            this.btn_BuscarProd.TabIndex = 9;
            this.btn_BuscarProd.Values.Image = ((System.Drawing.Image)(resources.GetObject("btn_BuscarProd.Values.Image")));
            this.btn_BuscarProd.Values.Text = "Buscar Filtro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Buscar por Produto";
            // 
            // txt_BuscarProd
            // 
            this.txt_BuscarProd.Location = new System.Drawing.Point(194, 11);
            this.txt_BuscarProd.Name = "txt_BuscarProd";
            this.txt_BuscarProd.Size = new System.Drawing.Size(303, 31);
            this.txt_BuscarProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_BuscarProd.StateCommon.Border.Rounding = 5;
            this.txt_BuscarProd.TabIndex = 5;
            // 
            // dgv_RelEstoque
            // 
            this.dgv_RelEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RelEstoque.Location = new System.Drawing.Point(50, 90);
            this.dgv_RelEstoque.Name = "dgv_RelEstoque";
            this.dgv_RelEstoque.RowHeadersWidth = 51;
            this.dgv_RelEstoque.RowTemplate.Height = 24;
            this.dgv_RelEstoque.Size = new System.Drawing.Size(1031, 527);
            this.dgv_RelEstoque.TabIndex = 0;
            // 
            // rd_MelhorVendedor
            // 
            this.rd_MelhorVendedor.Location = new System.Drawing.Point(549, 21);
            this.rd_MelhorVendedor.Name = "rd_MelhorVendedor";
            this.rd_MelhorVendedor.Size = new System.Drawing.Size(83, 24);
            this.rd_MelhorVendedor.TabIndex = 12;
            this.rd_MelhorVendedor.Values.Text = "Pior Des.";
            
            // 
            // btnFiltrarVendas
            // 
            this.btnFiltrarVendas.Location = new System.Drawing.Point(916, 63);
            this.btnFiltrarVendas.Name = "btnFiltrarVendas";
            this.btnFiltrarVendas.Size = new System.Drawing.Size(136, 40);
            this.btnFiltrarVendas.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFiltrarVendas.StateCommon.Border.Rounding = 10;
            this.btnFiltrarVendas.TabIndex = 9;
            this.btnFiltrarVendas.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrarVendas.Values.Image")));
            this.btnFiltrarVendas.Values.Text = "Buscar Filtro";
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(531, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data  de Fim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data  de Inicio";
            // 
            // txtFiltroVendedor
            // 
            this.txtFiltroVendedor.AutoSize = true;
            this.txtFiltroVendedor.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltroVendedor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroVendedor.Location = new System.Drawing.Point(15, 21);
            this.txtFiltroVendedor.Name = "txtFiltroVendedor";
            this.txtFiltroVendedor.Size = new System.Drawing.Size(170, 23);
            this.txtFiltroVendedor.TabIndex = 6;
            this.txtFiltroVendedor.Text = "Buscar por Vendedor";
            // 
            // txt_BuscarVendedor
            // 
            this.txt_BuscarVendedor.Location = new System.Drawing.Point(194, 11);
            this.txt_BuscarVendedor.Name = "txt_BuscarVendedor";
            this.txt_BuscarVendedor.Size = new System.Drawing.Size(303, 31);
            this.txt_BuscarVendedor.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_BuscarVendedor.StateCommon.Border.Rounding = 5;
            this.txt_BuscarVendedor.TabIndex = 5;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(178, 81);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(308, 22);
            this.dtpInicio.TabIndex = 2;
            // 
            // dtpFim
            // 
            this.dtpFim.Location = new System.Drawing.Point(669, 81);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(200, 22);
            this.dtpFim.TabIndex = 1;
            // 
            // dgvVendas
            // 
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(50, 134);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.RowHeadersWidth = 51;
            this.dgvVendas.RowTemplate.Height = 24;
            this.dgvVendas.Size = new System.Drawing.Size(1031, 483);
            this.dgvVendas.TabIndex = 0;
            // 
            // panelSombreado3
            // 
            this.panelSombreado3.BackColor = System.Drawing.Color.White;
            this.panelSombreado3.Controls.Add(this.pnlVendas);
            this.panelSombreado3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSombreado3.Location = new System.Drawing.Point(203, 77);
            this.panelSombreado3.Name = "panelSombreado3";
            this.panelSombreado3.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado3.Size = new System.Drawing.Size(1279, 765);
            this.panelSombreado3.TabIndex = 11;
            // 
            // UC_Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSombreado3);
            this.Controls.Add(this.panelSombreado2);
            this.Controls.Add(this.panelSombreado1);
            this.Name = "UC_Relatorio";
            this.Size = new System.Drawing.Size(1482, 842);
            this.Load += new System.EventHandler(this.UC_Relatorio_Load);
            this.panelSombreado1.ResumeLayout(false);
            this.panelSombreado1.PerformLayout();
            this.panelSombreado2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVendas)).EndInit();
            this.pnlVendas.ResumeLayout(false);
            this.pnlVendas.PerformLayout();
            this.pnlEstoque.ResumeLayout(false);
            this.pnlEstoque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RelEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.panelSombreado3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelSombreado panelSombreado1;
        private PanelSombreado panelSombreado2;
        private FontAwesome.Sharp.IconButton btnMenuEstoque;
        private FontAwesome.Sharp.IconButton btnMenuVendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendas;
        private PanelSombreado pnlVendas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFiltrarVendas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtFiltroVendedor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_BuscarVendedor;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DataGridView dgvVendas;
        private PanelSombreado pnlEstoque;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbHistorico;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbSaldo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_BuscarProd;
        private System.Windows.Forms.Label label6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_BuscarProd;
        private System.Windows.Forms.DataGridView dgv_RelEstoque;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rd_PiorVendedor;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rd_MelhorVendedor;
        private PanelSombreado panelSombreado3;
    }
}
