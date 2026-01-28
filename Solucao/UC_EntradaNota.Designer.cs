namespace Projeto_FinalOficial
{
    partial class UC_EntradaNota
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
            this.pnl_ListaPedidos = new PanelSombreado();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEntrar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.pnl_Conferencia = new PanelSombreado();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Confirmar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txt_Obs = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.panelSombreado1 = new PanelSombreado();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_ListaPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.pnl_Conferencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.panelSombreado1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_ListaPedidos
            // 
            this.pnl_ListaPedidos.BackColor = System.Drawing.Color.White;
            this.pnl_ListaPedidos.Controls.Add(this.label3);
            this.pnl_ListaPedidos.Controls.Add(this.btn_Cancelar);
            this.pnl_ListaPedidos.Controls.Add(this.btnEntrar);
            this.pnl_ListaPedidos.Controls.Add(this.dgvPedidos);
            this.pnl_ListaPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_ListaPedidos.Location = new System.Drawing.Point(0, 58);
            this.pnl_ListaPedidos.Margin = new System.Windows.Forms.Padding(6);
            this.pnl_ListaPedidos.Name = "pnl_ListaPedidos";
            this.pnl_ListaPedidos.Padding = new System.Windows.Forms.Padding(10);
            this.pnl_ListaPedidos.Size = new System.Drawing.Size(1319, 579);
            this.pnl_ListaPedidos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lista de Pedidos";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancelar.Location = new System.Drawing.Point(34, 517);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(161, 42);
            this.btn_Cancelar.TabIndex = 2;
            this.btn_Cancelar.Values.Text = "Cancelar";
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrar.Location = new System.Drawing.Point(1112, 517);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(178, 42);
            this.btnEntrar.TabIndex = 1;
            this.btnEntrar.Values.Text = "Entrar com Nota";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(18, 57);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.RowTemplate.Height = 24;
            this.dgvPedidos.Size = new System.Drawing.Size(1272, 425);
            this.dgvPedidos.TabIndex = 0;
            this.dgvPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellContentClick_1);
            // 
            // pnl_Conferencia
            // 
            this.pnl_Conferencia.BackColor = System.Drawing.Color.White;
            this.pnl_Conferencia.Controls.Add(this.label2);
            this.pnl_Conferencia.Controls.Add(this.btn_Confirmar);
            this.pnl_Conferencia.Controls.Add(this.txt_Obs);
            this.pnl_Conferencia.Controls.Add(this.dgvItens);
            this.pnl_Conferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Conferencia.Location = new System.Drawing.Point(0, 58);
            this.pnl_Conferencia.Margin = new System.Windows.Forms.Padding(10);
            this.pnl_Conferencia.Name = "pnl_Conferencia";
            this.pnl_Conferencia.Padding = new System.Windows.Forms.Padding(6);
            this.pnl_Conferencia.Size = new System.Drawing.Size(1319, 579);
            this.pnl_Conferencia.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Observação Recebimento";
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.Location = new System.Drawing.Point(125, 517);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(605, 42);
            this.btn_Confirmar.TabIndex = 2;
            this.btn_Confirmar.Values.Text = "Confirmar Entrada no Estoque";
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // txt_Obs
            // 
            this.txt_Obs.Location = new System.Drawing.Point(48, 371);
            this.txt_Obs.Multiline = true;
            this.txt_Obs.Name = "txt_Obs";
            this.txt_Obs.Size = new System.Drawing.Size(746, 89);
            this.txt_Obs.TabIndex = 2;
            // 
            // dgvItens
            // 
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Location = new System.Drawing.Point(35, 23);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.RowHeadersWidth = 51;
            this.dgvItens.Size = new System.Drawing.Size(823, 310);
            this.dgvItens.TabIndex = 1;
            // 
            // panelSombreado1
            // 
            this.panelSombreado1.BackColor = System.Drawing.Color.White;
            this.panelSombreado1.Controls.Add(this.label1);
            this.panelSombreado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado1.Location = new System.Drawing.Point(0, 0);
            this.panelSombreado1.Margin = new System.Windows.Forms.Padding(12);
            this.panelSombreado1.Name = "panelSombreado1";
            this.panelSombreado1.Padding = new System.Windows.Forms.Padding(7);
            this.panelSombreado1.Size = new System.Drawing.Size(1319, 58);
            this.panelSombreado1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 38);
            this.label1.TabIndex = 1;
            this.label1.Tag = "FIxo";
            this.label1.Text = "Entrada de Nota";
            // 
            // UC_EntradaNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_ListaPedidos);
            this.Controls.Add(this.pnl_Conferencia);
            this.Controls.Add(this.panelSombreado1);
            this.Name = "UC_EntradaNota";
            this.Size = new System.Drawing.Size(1319, 637);
            this.Load += new System.EventHandler(this.UC_EntradaNota_Load);
            this.pnl_ListaPedidos.ResumeLayout(false);
            this.pnl_ListaPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.pnl_Conferencia.ResumeLayout(false);
            this.pnl_Conferencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.panelSombreado1.ResumeLayout(false);
            this.panelSombreado1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelSombreado panelSombreado1;
        private System.Windows.Forms.Label label1;
        private PanelSombreado pnl_Conferencia;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Confirmar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Obs;
        private System.Windows.Forms.DataGridView dgvItens;
        private PanelSombreado pnl_ListaPedidos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Cancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEntrar;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
