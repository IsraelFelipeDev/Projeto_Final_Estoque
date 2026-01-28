namespace Projeto_FinalOficial
{
    partial class UC_EstoqueGeral
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
            this.dgv_Estoque = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSombreado3 = new PanelSombreado();
            this.btn_AlterarItem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_FazerPedido = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbl_Ideal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_Acima = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Negativos = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_TotalRegistros = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelSombreado1 = new PanelSombreado();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_BuscaCódigo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DescriçãoProd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panelSombreado2 = new PanelSombreado();
            this.chk_Acima = new ReaLTaiizor.Controls.AirCheckBox();
            this.chk_Ideal = new ReaLTaiizor.Controls.AirCheckBox();
            this.chk_Critico = new ReaLTaiizor.Controls.AirCheckBox();
            this.panelSombreado4 = new PanelSombreado();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Estoque)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelSombreado3.SuspendLayout();
            this.panelSombreado1.SuspendLayout();
            this.panelSombreado2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Estoque
            // 
            this.dgv_Estoque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Estoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Estoque.Location = new System.Drawing.Point(33, 355);
            this.dgv_Estoque.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Estoque.Name = "dgv_Estoque";
            this.dgv_Estoque.RowHeadersWidth = 51;
            this.dgv_Estoque.Size = new System.Drawing.Size(1342, 477);
            this.dgv_Estoque.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1424, 73);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(423, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estoque";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "--";
            // 
            // panelSombreado3
            // 
            this.panelSombreado3.BackColor = System.Drawing.Color.White;
            this.panelSombreado3.Controls.Add(this.btn_AlterarItem);
            this.panelSombreado3.Controls.Add(this.btn_FazerPedido);
            this.panelSombreado3.Controls.Add(this.lbl_Ideal);
            this.panelSombreado3.Controls.Add(this.label12);
            this.panelSombreado3.Controls.Add(this.lbl_Acima);
            this.panelSombreado3.Controls.Add(this.label10);
            this.panelSombreado3.Controls.Add(this.lbl_Negativos);
            this.panelSombreado3.Controls.Add(this.label11);
            this.panelSombreado3.Controls.Add(this.lbl_TotalRegistros);
            this.panelSombreado3.Controls.Add(this.label9);
            this.panelSombreado3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSombreado3.Location = new System.Drawing.Point(0, 920);
            this.panelSombreado3.Margin = new System.Windows.Forms.Padding(6);
            this.panelSombreado3.Name = "panelSombreado3";
            this.panelSombreado3.Padding = new System.Windows.Forms.Padding(5, 10, 12, 5);
            this.panelSombreado3.Size = new System.Drawing.Size(1424, 167);
            this.panelSombreado3.TabIndex = 3;
            // 
            // btn_AlterarItem
            // 
            this.btn_AlterarItem.Location = new System.Drawing.Point(1231, 69);
            this.btn_AlterarItem.Name = "btn_AlterarItem";
            this.btn_AlterarItem.Size = new System.Drawing.Size(144, 46);
            this.btn_AlterarItem.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AlterarItem.StateCommon.Border.Rounding = 5;
            this.btn_AlterarItem.TabIndex = 9;
            this.btn_AlterarItem.Values.Text = "Alterar Item";
            this.btn_AlterarItem.Click += new System.EventHandler(this.btn_AlterarItem_Click);
            // 
            // btn_FazerPedido
            // 
            this.btn_FazerPedido.Location = new System.Drawing.Point(1034, 69);
            this.btn_FazerPedido.Name = "btn_FazerPedido";
            this.btn_FazerPedido.Size = new System.Drawing.Size(144, 46);
            this.btn_FazerPedido.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_FazerPedido.StateCommon.Border.Rounding = 5;
            this.btn_FazerPedido.TabIndex = 8;
            this.btn_FazerPedido.Values.Text = "Fazer Pedido";
            this.btn_FazerPedido.Click += new System.EventHandler(this.btn_FazerPedido_Click);
            // 
            // lbl_Ideal
            // 
            this.lbl_Ideal.AutoSize = true;
            this.lbl_Ideal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Ideal.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ideal.ForeColor = System.Drawing.Color.YellowGreen;
            this.lbl_Ideal.Location = new System.Drawing.Point(668, 98);
            this.lbl_Ideal.Name = "lbl_Ideal";
            this.lbl_Ideal.Size = new System.Drawing.Size(12, 17);
            this.lbl_Ideal.TabIndex = 7;
            this.lbl_Ideal.Text = ".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.YellowGreen;
            this.label12.Location = new System.Drawing.Point(534, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "Quantidade Ideal:";
            // 
            // lbl_Acima
            // 
            this.lbl_Acima.AutoSize = true;
            this.lbl_Acima.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Acima.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Acima.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Acima.Location = new System.Drawing.Point(499, 98);
            this.lbl_Acima.Name = "lbl_Acima";
            this.lbl_Acima.Size = new System.Drawing.Size(12, 17);
            this.lbl_Acima.TabIndex = 5;
            this.lbl_Acima.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(367, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Quantidade Acima:";
            // 
            // lbl_Negativos
            // 
            this.lbl_Negativos.AutoSize = true;
            this.lbl_Negativos.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Negativos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.lbl_Negativos.Location = new System.Drawing.Point(330, 100);
            this.lbl_Negativos.Name = "lbl_Negativos";
            this.lbl_Negativos.Size = new System.Drawing.Size(10, 16);
            this.lbl_Negativos.TabIndex = 3;
            this.lbl_Negativos.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.label11.Location = new System.Drawing.Point(193, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Quantidade Abaixo:";
            // 
            // lbl_TotalRegistros
            // 
            this.lbl_TotalRegistros.AutoSize = true;
            this.lbl_TotalRegistros.Location = new System.Drawing.Point(163, 99);
            this.lbl_TotalRegistros.Name = "lbl_TotalRegistros";
            this.lbl_TotalRegistros.Size = new System.Drawing.Size(10, 16);
            this.lbl_TotalRegistros.TabIndex = 1;
            this.lbl_TotalRegistros.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Quantidade Registros:";
            // 
            // panelSombreado1
            // 
            this.panelSombreado1.BackColor = System.Drawing.Color.White;
            this.panelSombreado1.Controls.Add(this.label8);
            this.panelSombreado1.Controls.Add(this.txt_BuscaCódigo);
            this.panelSombreado1.Controls.Add(this.label7);
            this.panelSombreado1.Controls.Add(this.label6);
            this.panelSombreado1.Controls.Add(this.label3);
            this.panelSombreado1.Controls.Add(this.label2);
            this.panelSombreado1.Controls.Add(this.txt_DescriçãoProd);
            this.panelSombreado1.Controls.Add(this.panelSombreado2);
            this.panelSombreado1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado1.Location = new System.Drawing.Point(0, 73);
            this.panelSombreado1.Margin = new System.Windows.Forms.Padding(10);
            this.panelSombreado1.Name = "panelSombreado1";
            this.panelSombreado1.Padding = new System.Windows.Forms.Padding(10);
            this.panelSombreado1.Size = new System.Drawing.Size(1424, 196);
            this.panelSombreado1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(655, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 23);
            this.label8.TabIndex = 9;
            this.label8.Text = "Código ENAN";
            // 
            // txt_BuscaCódigo
            // 
            this.txt_BuscaCódigo.Location = new System.Drawing.Point(659, 64);
            this.txt_BuscaCódigo.Name = "txt_BuscaCódigo";
            this.txt_BuscaCódigo.Size = new System.Drawing.Size(253, 32);
            this.txt_BuscaCódigo.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.txt_BuscaCódigo.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.txt_BuscaCódigo.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txt_BuscaCódigo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_BuscaCódigo.StateCommon.Border.Rounding = 5;
            this.txt_BuscaCódigo.StateCommon.Border.Width = 2;
            this.txt_BuscaCódigo.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5, -1, -1, 5);
            this.txt_BuscaCódigo.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(9, -2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "-------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(153, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1186, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, -4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Filtros ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descriação do Produto";
            // 
            // txt_DescriçãoProd
            // 
            this.txt_DescriçãoProd.Location = new System.Drawing.Point(66, 64);
            this.txt_DescriçãoProd.Name = "txt_DescriçãoProd";
            this.txt_DescriçãoProd.Size = new System.Drawing.Size(398, 32);
            this.txt_DescriçãoProd.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.txt_DescriçãoProd.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.txt_DescriçãoProd.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txt_DescriçãoProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_DescriçãoProd.StateCommon.Border.Rounding = 5;
            this.txt_DescriçãoProd.StateCommon.Border.Width = 2;
            this.txt_DescriçãoProd.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5, -1, -1, 5);
            this.txt_DescriçãoProd.TabIndex = 1;
            // 
            // panelSombreado2
            // 
            this.panelSombreado2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSombreado2.BackColor = System.Drawing.Color.White;
            this.panelSombreado2.Controls.Add(this.chk_Acima);
            this.panelSombreado2.Controls.Add(this.chk_Ideal);
            this.panelSombreado2.Controls.Add(this.chk_Critico);
            this.panelSombreado2.Location = new System.Drawing.Point(22, 102);
            this.panelSombreado2.Name = "panelSombreado2";
            this.panelSombreado2.Padding = new System.Windows.Forms.Padding(12, 12, 7, 3);
            this.panelSombreado2.Size = new System.Drawing.Size(1376, 71);
            this.panelSombreado2.TabIndex = 0;
            // 
            // chk_Acima
            // 
            this.chk_Acima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Acima.BackColor = System.Drawing.Color.White;
            this.chk_Acima.Checked = false;
            this.chk_Acima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_Acima.Customization = "AP///wD///8A////AP///wD///8A////AP///wD///8=";
            this.chk_Acima.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chk_Acima.Image = null;
            this.chk_Acima.Location = new System.Drawing.Point(969, 37);
            this.chk_Acima.Name = "chk_Acima";
            this.chk_Acima.NoRounding = false;
            this.chk_Acima.Size = new System.Drawing.Size(169, 17);
            this.chk_Acima.TabIndex = 2;
            this.chk_Acima.Text = "Quantidade Acima";
            this.chk_Acima.Transparent = false;
            // 
            // chk_Ideal
            // 
            this.chk_Ideal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chk_Ideal.BackColor = System.Drawing.Color.White;
            this.chk_Ideal.Checked = false;
            this.chk_Ideal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_Ideal.Customization = "gP+A/4D/gP8A/wD/L/+t/wD/f/8v/63/wP/A/4D/gP8=";
            this.chk_Ideal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chk_Ideal.Image = null;
            this.chk_Ideal.Location = new System.Drawing.Point(530, 37);
            this.chk_Ideal.Name = "chk_Ideal";
            this.chk_Ideal.NoRounding = false;
            this.chk_Ideal.Size = new System.Drawing.Size(169, 17);
            this.chk_Ideal.TabIndex = 1;
            this.chk_Ideal.Text = "Quantidade Ideal";
            this.chk_Ideal.Transparent = false;
            // 
            // chk_Critico
            // 
            this.chk_Critico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_Critico.BackColor = System.Drawing.Color.White;
            this.chk_Critico.Checked = false;
            this.chk_Critico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_Critico.Customization = "AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8=";
            this.chk_Critico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chk_Critico.Image = null;
            this.chk_Critico.Location = new System.Drawing.Point(105, 37);
            this.chk_Critico.Name = "chk_Critico";
            this.chk_Critico.NoRounding = false;
            this.chk_Critico.Size = new System.Drawing.Size(169, 17);
            this.chk_Critico.TabIndex = 0;
            this.chk_Critico.Text = "Quantidade Abaixo";
            this.chk_Critico.Transparent = false;
            // 
            // panelSombreado4
            // 
            this.panelSombreado4.BackColor = System.Drawing.Color.White;
            this.panelSombreado4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSombreado4.Location = new System.Drawing.Point(0, 0);
            this.panelSombreado4.Name = "panelSombreado4";
            this.panelSombreado4.Padding = new System.Windows.Forms.Padding(2, 2, 12, 12);
            this.panelSombreado4.Size = new System.Drawing.Size(1424, 1087);
            this.panelSombreado4.TabIndex = 4;
            // 
            // UC_EstoqueGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSombreado3);
            this.Controls.Add(this.panelSombreado1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Estoque);
            this.Controls.Add(this.panelSombreado4);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UC_EstoqueGeral";
            this.Size = new System.Drawing.Size(1424, 1087);
            this.Load += new System.EventHandler(this.UC_EstoqueGeral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Estoque)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSombreado3.ResumeLayout(false);
            this.panelSombreado3.PerformLayout();
            this.panelSombreado1.ResumeLayout(false);
            this.panelSombreado1.PerformLayout();
            this.panelSombreado2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Estoque;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private PanelSombreado panelSombreado1;
        private PanelSombreado panelSombreado2;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_DescriçãoProd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_BuscaCódigo;
        private ReaLTaiizor.Controls.AirCheckBox chk_Critico;
        private ReaLTaiizor.Controls.AirCheckBox chk_Acima;
        private ReaLTaiizor.Controls.AirCheckBox chk_Ideal;
        private PanelSombreado panelSombreado3;
        private PanelSombreado panelSombreado4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_TotalRegistros;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_Ideal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_Acima;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_Negativos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_AlterarItem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_FazerPedido;
    }
}
