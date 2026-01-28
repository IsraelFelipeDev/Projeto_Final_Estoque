namespace Projeto_FinalOficial
{
    partial class UC_FazerPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_FazerPedido));
            this.panelSombreado4 = new PanelSombreado();
            this.btnCalcularInteligencia = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSalvar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelSombreado3 = new PanelSombreado();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.panelSombreado2 = new PanelSombreado();
            this.pnlTopo = new PanelSombreado();
            this.lblResumo = new System.Windows.Forms.Label();
            this.panelSombreado1 = new PanelSombreado();
            this.panelSombreado5 = new PanelSombreado();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_BuscarProd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BuscarProd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgvResultadosBusca = new System.Windows.Forms.DataGridView();
            this.panelSombreado4.SuspendLayout();
            this.panelSombreado3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.panelSombreado2.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            this.panelSombreado1.SuspendLayout();
            this.panelSombreado5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadosBusca)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSombreado4
            // 
            this.panelSombreado4.BackColor = System.Drawing.Color.White;
            this.panelSombreado4.Controls.Add(this.btnCalcularInteligencia);
            this.panelSombreado4.Controls.Add(this.btnSalvar);
            this.panelSombreado4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado4.Location = new System.Drawing.Point(0, 967);
            this.panelSombreado4.Name = "panelSombreado4";
            this.panelSombreado4.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado4.Size = new System.Drawing.Size(1268, 349);
            this.panelSombreado4.TabIndex = 3;
            // 
            // btnCalcularInteligencia
            // 
            this.btnCalcularInteligencia.Location = new System.Drawing.Point(92, 21);
            this.btnCalcularInteligencia.Margin = new System.Windows.Forms.Padding(6);
            this.btnCalcularInteligencia.Name = "btnCalcularInteligencia";
            this.btnCalcularInteligencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCalcularInteligencia.Size = new System.Drawing.Size(430, 38);
            this.btnCalcularInteligencia.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCalcularInteligencia.StateCommon.Border.Rounding = 5;
            this.btnCalcularInteligencia.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnCalcularInteligencia.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularInteligencia.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCalcularInteligencia.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCalcularInteligencia.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Character;
            this.btnCalcularInteligencia.StateNormal.Back.Color1 = System.Drawing.Color.DodgerBlue;
            this.btnCalcularInteligencia.StateNormal.Back.Color2 = System.Drawing.Color.DeepSkyBlue;
            this.btnCalcularInteligencia.StateNormal.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularInteligencia.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularInteligencia.StateNormal.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCalcularInteligencia.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Character;
            this.btnCalcularInteligencia.TabIndex = 31;
            this.btnCalcularInteligencia.UseMnemonic = false;
            this.btnCalcularInteligencia.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcularInteligencia.Values.Image")));
            this.btnCalcularInteligencia.Values.Text = "Recalcular Melhor Opção";
            this.btnCalcularInteligencia.Click += new System.EventHandler(this.btnCalcularInteligencia_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(786, 21);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSalvar.Size = new System.Drawing.Size(380, 38);
            this.btnSalvar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSalvar.StateCommon.Border.Rounding = 5;
            this.btnSalvar.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btnSalvar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnSalvar.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSalvar.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Character;
            this.btnSalvar.StateNormal.Back.Color1 = System.Drawing.Color.DarkGreen;
            this.btnSalvar.StateNormal.Back.Color2 = System.Drawing.Color.SeaGreen;
            this.btnSalvar.StateNormal.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalvar.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSalvar.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.StateNormal.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnSalvar.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Character;
            this.btnSalvar.TabIndex = 30;
            this.btnSalvar.UseMnemonic = false;
            this.btnSalvar.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Values.Image")));
            this.btnSalvar.Values.Text = "Gerar Pedido Reposição";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click_1);
            // 
            // panelSombreado3
            // 
            this.panelSombreado3.BackColor = System.Drawing.Color.White;
            this.panelSombreado3.Controls.Add(this.dgvItens);
            this.panelSombreado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado3.Location = new System.Drawing.Point(0, 388);
            this.panelSombreado3.Name = "panelSombreado3";
            this.panelSombreado3.Padding = new System.Windows.Forms.Padding(8);
            this.panelSombreado3.Size = new System.Drawing.Size(1268, 579);
            this.panelSombreado3.TabIndex = 2;
            // 
            // dgvItens
            // 
            this.dgvItens.BackgroundColor = System.Drawing.Color.White;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItens.Location = new System.Drawing.Point(8, 8);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.RowHeadersWidth = 51;
            this.dgvItens.RowTemplate.Height = 24;
            this.dgvItens.Size = new System.Drawing.Size(1252, 563);
            this.dgvItens.TabIndex = 31;
            // 
            // panelSombreado2
            // 
            this.panelSombreado2.BackColor = System.Drawing.Color.White;
            this.panelSombreado2.Controls.Add(this.pnlTopo);
            this.panelSombreado2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado2.Location = new System.Drawing.Point(0, 259);
            this.panelSombreado2.Name = "panelSombreado2";
            this.panelSombreado2.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado2.Size = new System.Drawing.Size(1268, 129);
            this.panelSombreado2.TabIndex = 1;
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.LightGreen;
            this.pnlTopo.Controls.Add(this.lblResumo);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopo.Location = new System.Drawing.Point(2, 2);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopo.Size = new System.Drawing.Size(1254, 115);
            this.pnlTopo.TabIndex = 0;
            this.pnlTopo.Visible = false;
            // 
            // lblResumo
            // 
            this.lblResumo.AutoSize = true;
            this.lblResumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumo.Location = new System.Drawing.Point(10, 10);
            this.lblResumo.Name = "lblResumo";
            this.lblResumo.Size = new System.Drawing.Size(215, 22);
            this.lblResumo.TabIndex = 0;
            this.lblResumo.Text = "Aguardando Calculo ...";
            this.lblResumo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSombreado1
            // 
            this.panelSombreado1.BackColor = System.Drawing.Color.White;
            this.panelSombreado1.Controls.Add(this.panelSombreado5);
            this.panelSombreado1.Controls.Add(this.btn_BuscarProd);
            this.panelSombreado1.Controls.Add(this.label2);
            this.panelSombreado1.Controls.Add(this.txt_BuscarProd);
            this.panelSombreado1.Controls.Add(this.dgvResultadosBusca);
            this.panelSombreado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado1.Location = new System.Drawing.Point(0, 0);
            this.panelSombreado1.Margin = new System.Windows.Forms.Padding(10);
            this.panelSombreado1.Name = "panelSombreado1";
            this.panelSombreado1.Padding = new System.Windows.Forms.Padding(4);
            this.panelSombreado1.Size = new System.Drawing.Size(1268, 259);
            this.panelSombreado1.TabIndex = 0;
            // 
            // panelSombreado5
            // 
            this.panelSombreado5.BackColor = System.Drawing.Color.White;
            this.panelSombreado5.Controls.Add(this.label1);
            this.panelSombreado5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado5.Location = new System.Drawing.Point(4, 4);
            this.panelSombreado5.Margin = new System.Windows.Forms.Padding(10);
            this.panelSombreado5.Name = "panelSombreado5";
            this.panelSombreado5.Padding = new System.Windows.Forms.Padding(6);
            this.panelSombreado5.Size = new System.Drawing.Size(1260, 47);
            this.panelSombreado5.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 31);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Fixo";
            this.label1.Text = "Pedidos de Mercadorias";
            // 
            // btn_BuscarProd
            // 
            this.btn_BuscarProd.Location = new System.Drawing.Point(427, 79);
            this.btn_BuscarProd.Margin = new System.Windows.Forms.Padding(6);
            this.btn_BuscarProd.Name = "btn_BuscarProd";
            this.btn_BuscarProd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_BuscarProd.Size = new System.Drawing.Size(129, 38);
            this.btn_BuscarProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_BuscarProd.StateCommon.Border.Rounding = 5;
            this.btn_BuscarProd.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.btn_BuscarProd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarProd.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btn_BuscarProd.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btn_BuscarProd.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Character;
            this.btn_BuscarProd.StateNormal.Back.Color1 = System.Drawing.Color.DodgerBlue;
            this.btn_BuscarProd.StateNormal.Back.Color2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_BuscarProd.StateNormal.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarProd.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarProd.StateNormal.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btn_BuscarProd.StateNormal.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Character;
            this.btn_BuscarProd.TabIndex = 29;
            this.btn_BuscarProd.UseMnemonic = false;
            this.btn_BuscarProd.Values.Image = ((System.Drawing.Image)(resources.GetObject("btn_BuscarProd.Values.Image")));
            this.btn_BuscarProd.Values.Text = "Buscar      ";
            this.btn_BuscarProd.Click += new System.EventHandler(this.btn_BuscarProd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descriação do Produto";
            // 
            // txt_BuscarProd
            // 
            this.txt_BuscarProd.Location = new System.Drawing.Point(20, 85);
            this.txt_BuscarProd.Name = "txt_BuscarProd";
            this.txt_BuscarProd.Size = new System.Drawing.Size(398, 32);
            this.txt_BuscarProd.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.txt_BuscarProd.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.txt_BuscarProd.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txt_BuscarProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_BuscarProd.StateCommon.Border.Rounding = 5;
            this.txt_BuscarProd.StateCommon.Border.Width = 2;
            this.txt_BuscarProd.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5, -1, -1, 5);
            this.txt_BuscarProd.TabIndex = 3;
            // 
            // dgvResultadosBusca
            // 
            this.dgvResultadosBusca.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResultadosBusca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultadosBusca.Location = new System.Drawing.Point(20, 126);
            this.dgvResultadosBusca.Name = "dgvResultadosBusca";
            this.dgvResultadosBusca.RowHeadersWidth = 51;
            this.dgvResultadosBusca.RowTemplate.Height = 24;
            this.dgvResultadosBusca.Size = new System.Drawing.Size(765, 100);
            this.dgvResultadosBusca.TabIndex = 0;
            // 
            // UC_FazerPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSombreado4);
            this.Controls.Add(this.panelSombreado3);
            this.Controls.Add(this.panelSombreado2);
            this.Controls.Add(this.panelSombreado1);
            this.Name = "UC_FazerPedido";
            this.Size = new System.Drawing.Size(1268, 1032);
            this.Load += new System.EventHandler(this.UC_FazerPedido_Load_1);
            this.panelSombreado4.ResumeLayout(false);
            this.panelSombreado3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.panelSombreado2.ResumeLayout(false);
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            this.panelSombreado1.ResumeLayout(false);
            this.panelSombreado1.PerformLayout();
            this.panelSombreado5.ResumeLayout(false);
            this.panelSombreado5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadosBusca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelSombreado panelSombreado1;
        private PanelSombreado panelSombreado2;
        private PanelSombreado panelSombreado3;
        private PanelSombreado panelSombreado4;
        private System.Windows.Forms.DataGridView dgvResultadosBusca;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_BuscarProd;
        private PanelSombreado panelSombreado5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_BuscarProd;
        private System.Windows.Forms.Label label1;
        private PanelSombreado pnlTopo;
        private System.Windows.Forms.Label lblResumo;
        private System.Windows.Forms.DataGridView dgvItens;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalcularInteligencia;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSalvar;
    }
}
