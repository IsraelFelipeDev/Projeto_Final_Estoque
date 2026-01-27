namespace Projeto_FinalOficial
{
    partial class UC_Vendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Vendas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CodigoProd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txt_ValorUnitario = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pick_FotoProd = new ReaLTaiizor.Controls.HopePictureBox();
            this.txt_NomeProd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.moonLabel1 = new ReaLTaiizor.Controls.MoonLabel();
            this.moonLabel2 = new ReaLTaiizor.Controls.MoonLabel();
            this.num_Quantidade = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.dgv_Carrinho = new System.Windows.Forms.DataGridView();
            this.btn_AdicionarItem = new FontAwesome.Sharp.IconButton();
            this.btn_LimparCampos = new FontAwesome.Sharp.IconButton();
            this.Btn_AlterarItem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_FinalizarVenda = new FontAwesome.Sharp.IconButton();
            this.moonLabel3 = new ReaLTaiizor.Controls.MoonLabel();
            this.moonLabel4 = new ReaLTaiizor.Controls.MoonLabel();
            this.moonLabel5 = new ReaLTaiizor.Controls.MoonLabel();
            this.txt_CorProd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btn_ExcluirItemCarrinho = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.moonLabel6 = new ReaLTaiizor.Controls.MoonLabel();
            this.txt_ValorFinal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txt_BuscaCliente = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btn_CadastraCLiente = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_BuscarCliente = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.moonLabel7 = new ReaLTaiizor.Controls.MoonLabel();
            this.panelSombreado1 = new PanelSombreado();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pick_FotoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Carrinho)).BeginInit();
            this.panelSombreado1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 59);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "Fixo";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(548, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 532);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(559, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 494);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(582, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Fixo";
            this.label1.Text = " Caixa Livre";
            // 
            // txt_CodigoProd
            // 
            this.txt_CodigoProd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_CodigoProd.Location = new System.Drawing.Point(21, 217);
            this.txt_CodigoProd.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CodigoProd.Name = "txt_CodigoProd";
            this.txt_CodigoProd.Size = new System.Drawing.Size(323, 31);
            this.txt_CodigoProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_CodigoProd.StateCommon.Border.Rounding = 5;
            this.txt_CodigoProd.TabIndex = 1;
            this.txt_CodigoProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CodigoProd_KeyDown);
            // 
            // txt_ValorUnitario
            // 
            this.txt_ValorUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_ValorUnitario.Location = new System.Drawing.Point(21, 451);
            this.txt_ValorUnitario.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ValorUnitario.Name = "txt_ValorUnitario";
            this.txt_ValorUnitario.ReadOnly = true;
            this.txt_ValorUnitario.Size = new System.Drawing.Size(125, 31);
            this.txt_ValorUnitario.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_ValorUnitario.StateCommon.Border.Rounding = 5;
            this.txt_ValorUnitario.TabIndex = 2;
            // 
            // pick_FotoProd
            // 
            this.pick_FotoProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pick_FotoProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.pick_FotoProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pick_FotoProd.Location = new System.Drawing.Point(32, 497);
            this.pick_FotoProd.Margin = new System.Windows.Forms.Padding(4);
            this.pick_FotoProd.Name = "pick_FotoProd";
            this.pick_FotoProd.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            this.pick_FotoProd.Size = new System.Drawing.Size(217, 214);
            this.pick_FotoProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pick_FotoProd.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.pick_FotoProd.TabIndex = 3;
            this.pick_FotoProd.TabStop = false;
            this.pick_FotoProd.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // txt_NomeProd
            // 
            this.txt_NomeProd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_NomeProd.Location = new System.Drawing.Point(21, 288);
            this.txt_NomeProd.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NomeProd.Name = "txt_NomeProd";
            this.txt_NomeProd.ReadOnly = true;
            this.txt_NomeProd.Size = new System.Drawing.Size(323, 31);
            this.txt_NomeProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_NomeProd.StateCommon.Border.Rounding = 5;
            this.txt_NomeProd.TabIndex = 5;
            // 
            // moonLabel1
            // 
            this.moonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moonLabel1.AutoSize = true;
            this.moonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel1.Location = new System.Drawing.Point(27, 431);
            this.moonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel1.Name = "moonLabel1";
            this.moonLabel1.Size = new System.Drawing.Size(88, 16);
            this.moonLabel1.TabIndex = 6;
            this.moonLabel1.Text = "Valor Unitario";
            // 
            // moonLabel2
            // 
            this.moonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moonLabel2.AutoSize = true;
            this.moonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel2.Location = new System.Drawing.Point(193, 431);
            this.moonLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel2.Name = "moonLabel2";
            this.moonLabel2.Size = new System.Drawing.Size(77, 16);
            this.moonLabel2.TabIndex = 7;
            this.moonLabel2.Text = "Quantidade";
            // 
            // num_Quantidade
            // 
            this.num_Quantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.num_Quantidade.Location = new System.Drawing.Point(195, 451);
            this.num_Quantidade.Margin = new System.Windows.Forms.Padding(4);
            this.num_Quantidade.Name = "num_Quantidade";
            this.num_Quantidade.Size = new System.Drawing.Size(88, 32);
            this.num_Quantidade.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.num_Quantidade.StateCommon.Border.Rounding = 10;
            this.num_Quantidade.TabIndex = 14;
            // 
            // dgv_Carrinho
            // 
            this.dgv_Carrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Carrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Carrinho.Location = new System.Drawing.Point(50, 52);
            this.dgv_Carrinho.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Carrinho.Name = "dgv_Carrinho";
            this.dgv_Carrinho.RowHeadersWidth = 51;
            this.dgv_Carrinho.Size = new System.Drawing.Size(732, 400);
            this.dgv_Carrinho.TabIndex = 15;
            // 
            // btn_AdicionarItem
            // 
            this.btn_AdicionarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_AdicionarItem.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.btn_AdicionarItem.IconColor = System.Drawing.Color.Black;
            this.btn_AdicionarItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_AdicionarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AdicionarItem.Location = new System.Drawing.Point(13, 729);
            this.btn_AdicionarItem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AdicionarItem.Name = "btn_AdicionarItem";
            this.btn_AdicionarItem.Size = new System.Drawing.Size(187, 62);
            this.btn_AdicionarItem.TabIndex = 16;
            this.btn_AdicionarItem.Text = "ADICIONAR";
            this.btn_AdicionarItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AdicionarItem.UseVisualStyleBackColor = true;
            this.btn_AdicionarItem.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btn_LimparCampos
            // 
            this.btn_LimparCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_LimparCampos.IconChar = FontAwesome.Sharp.IconChar.TrashRestore;
            this.btn_LimparCampos.IconColor = System.Drawing.Color.Black;
            this.btn_LimparCampos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_LimparCampos.IconSize = 43;
            this.btn_LimparCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LimparCampos.Location = new System.Drawing.Point(249, 729);
            this.btn_LimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btn_LimparCampos.Name = "btn_LimparCampos";
            this.btn_LimparCampos.Size = new System.Drawing.Size(187, 62);
            this.btn_LimparCampos.TabIndex = 17;
            this.btn_LimparCampos.Text = "LIMPAR";
            this.btn_LimparCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LimparCampos.UseVisualStyleBackColor = true;
            this.btn_LimparCampos.Click += new System.EventHandler(this.btn_LimparCampos_Click);
            // 
            // Btn_AlterarItem
            // 
            this.Btn_AlterarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_AlterarItem.Location = new System.Drawing.Point(470, 472);
            this.Btn_AlterarItem.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_AlterarItem.Name = "Btn_AlterarItem";
            this.Btn_AlterarItem.Size = new System.Drawing.Size(136, 39);
            this.Btn_AlterarItem.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Btn_AlterarItem.StateCommon.Border.Rounding = 10;
            this.Btn_AlterarItem.TabIndex = 19;
            this.Btn_AlterarItem.Values.Text = "Alterar Item";
            this.Btn_AlterarItem.Click += new System.EventHandler(this.Btn_AlterarItem_Click);
            // 
            // btn_FinalizarVenda
            // 
            this.btn_FinalizarVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FinalizarVenda.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.btn_FinalizarVenda.IconColor = System.Drawing.Color.Black;
            this.btn_FinalizarVenda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_FinalizarVenda.IconSize = 43;
            this.btn_FinalizarVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FinalizarVenda.Location = new System.Drawing.Point(595, 669);
            this.btn_FinalizarVenda.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FinalizarVenda.Name = "btn_FinalizarVenda";
            this.btn_FinalizarVenda.Size = new System.Drawing.Size(187, 62);
            this.btn_FinalizarVenda.TabIndex = 20;
            this.btn_FinalizarVenda.Text = "Finalizar ";
            this.btn_FinalizarVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FinalizarVenda.UseVisualStyleBackColor = true;
            this.btn_FinalizarVenda.Click += new System.EventHandler(this.btn_FinalizarVenda_Click);
            // 
            // moonLabel3
            // 
            this.moonLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moonLabel3.AutoSize = true;
            this.moonLabel3.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel3.Location = new System.Drawing.Point(18, 268);
            this.moonLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel3.Name = "moonLabel3";
            this.moonLabel3.Size = new System.Drawing.Size(113, 16);
            this.moonLabel3.TabIndex = 21;
            this.moonLabel3.Text = "Nome do Produto";
            // 
            // moonLabel4
            // 
            this.moonLabel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moonLabel4.AutoSize = true;
            this.moonLabel4.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel4.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel4.Location = new System.Drawing.Point(19, 187);
            this.moonLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel4.Name = "moonLabel4";
            this.moonLabel4.Size = new System.Drawing.Size(113, 16);
            this.moonLabel4.TabIndex = 22;
            this.moonLabel4.Text = "Codigo de Barras";
            // 
            // moonLabel5
            // 
            this.moonLabel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moonLabel5.AutoSize = true;
            this.moonLabel5.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel5.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel5.Location = new System.Drawing.Point(19, 346);
            this.moonLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel5.Name = "moonLabel5";
            this.moonLabel5.Size = new System.Drawing.Size(97, 16);
            this.moonLabel5.TabIndex = 23;
            this.moonLabel5.Text = "Cor do Produto";
            // 
            // txt_CorProd
            // 
            this.txt_CorProd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_CorProd.Location = new System.Drawing.Point(22, 366);
            this.txt_CorProd.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CorProd.Name = "txt_CorProd";
            this.txt_CorProd.ReadOnly = true;
            this.txt_CorProd.Size = new System.Drawing.Size(131, 31);
            this.txt_CorProd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_CorProd.StateCommon.Border.Rounding = 5;
            this.txt_CorProd.TabIndex = 24;
            // 
            // btn_ExcluirItemCarrinho
            // 
            this.btn_ExcluirItemCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExcluirItemCarrinho.Location = new System.Drawing.Point(637, 472);
            this.btn_ExcluirItemCarrinho.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ExcluirItemCarrinho.Name = "btn_ExcluirItemCarrinho";
            this.btn_ExcluirItemCarrinho.Size = new System.Drawing.Size(120, 39);
            this.btn_ExcluirItemCarrinho.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_ExcluirItemCarrinho.StateCommon.Border.Rounding = 10;
            this.btn_ExcluirItemCarrinho.TabIndex = 25;
            this.btn_ExcluirItemCarrinho.Values.Text = "Excluir Item";
            this.btn_ExcluirItemCarrinho.Click += new System.EventHandler(this.btn_ExcluirItemCarrinho_Click);
            // 
            // moonLabel6
            // 
            this.moonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moonLabel6.AutoSize = true;
            this.moonLabel6.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moonLabel6.ForeColor = System.Drawing.Color.Black;
            this.moonLabel6.Location = new System.Drawing.Point(662, 577);
            this.moonLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel6.Name = "moonLabel6";
            this.moonLabel6.Size = new System.Drawing.Size(111, 28);
            this.moonLabel6.TabIndex = 27;
            this.moonLabel6.Text = "Valor Final";
            // 
            // txt_ValorFinal
            // 
            this.txt_ValorFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ValorFinal.Location = new System.Drawing.Point(595, 621);
            this.txt_ValorFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ValorFinal.Name = "txt_ValorFinal";
            this.txt_ValorFinal.ReadOnly = true;
            this.txt_ValorFinal.Size = new System.Drawing.Size(187, 31);
            this.txt_ValorFinal.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_ValorFinal.StateCommon.Border.Rounding = 5;
            this.txt_ValorFinal.TabIndex = 26;
            this.txt_ValorFinal.TextChanged += new System.EventHandler(this.txt_ValorFinal_TextChanged);
            // 
            // txt_BuscaCliente
            // 
            this.txt_BuscaCliente.Location = new System.Drawing.Point(13, 83);
            this.txt_BuscaCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BuscaCliente.Name = "txt_BuscaCliente";
            this.txt_BuscaCliente.Size = new System.Drawing.Size(372, 31);
            this.txt_BuscaCliente.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_BuscaCliente.StateCommon.Border.Rounding = 5;
            this.txt_BuscaCliente.TabIndex = 28;
            // 
            // btn_CadastraCLiente
            // 
            this.btn_CadastraCLiente.Location = new System.Drawing.Point(161, 122);
            this.btn_CadastraCLiente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CadastraCLiente.Name = "btn_CadastraCLiente";
            this.btn_CadastraCLiente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_CadastraCLiente.Size = new System.Drawing.Size(120, 39);
            this.btn_CadastraCLiente.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_CadastraCLiente.StateCommon.Border.Rounding = 10;
            this.btn_CadastraCLiente.TabIndex = 29;
            this.btn_CadastraCLiente.Values.Image = ((System.Drawing.Image)(resources.GetObject("btn_CadastraCLiente.Values.Image")));
            this.btn_CadastraCLiente.Values.Text = "Adicionar";
            this.btn_CadastraCLiente.Click += new System.EventHandler(this.btn_CadastraCLiente_Click);
            // 
            // btn_BuscarCliente
            // 
            this.btn_BuscarCliente.Location = new System.Drawing.Point(13, 122);
            this.btn_BuscarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BuscarCliente.Name = "btn_BuscarCliente";
            this.btn_BuscarCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_BuscarCliente.Size = new System.Drawing.Size(120, 39);
            this.btn_BuscarCliente.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_BuscarCliente.StateCommon.Border.Rounding = 10;
            this.btn_BuscarCliente.TabIndex = 30;
            this.btn_BuscarCliente.Values.Image = ((System.Drawing.Image)(resources.GetObject("btn_BuscarCliente.Values.Image")));
            this.btn_BuscarCliente.Values.Text = "Buscar";
            this.btn_BuscarCliente.Click += new System.EventHandler(this.btn_BuscarCliente_Click);
            // 
            // moonLabel7
            // 
            this.moonLabel7.AutoSize = true;
            this.moonLabel7.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel7.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel7.Location = new System.Drawing.Point(10, 63);
            this.moonLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel7.Name = "moonLabel7";
            this.moonLabel7.Size = new System.Drawing.Size(48, 16);
            this.moonLabel7.TabIndex = 31;
            this.moonLabel7.Text = "Cliente";
            // 
            // panelSombreado1
            // 
            this.panelSombreado1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSombreado1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSombreado1.Controls.Add(this.dgv_Carrinho);
            this.panelSombreado1.Controls.Add(this.btn_ExcluirItemCarrinho);
            this.panelSombreado1.Controls.Add(this.Btn_AlterarItem);
            this.panelSombreado1.Controls.Add(this.btn_FinalizarVenda);
            this.panelSombreado1.Controls.Add(this.moonLabel6);
            this.panelSombreado1.Controls.Add(this.txt_ValorFinal);
            this.panelSombreado1.Location = new System.Drawing.Point(498, 59);
            this.panelSombreado1.Margin = new System.Windows.Forms.Padding(7);
            this.panelSombreado1.Name = "panelSombreado1";
            this.panelSombreado1.Padding = new System.Windows.Forms.Padding(10);
            this.panelSombreado1.Size = new System.Drawing.Size(812, 745);
            this.panelSombreado1.TabIndex = 32;
            // 
            // UC_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panelSombreado1);
            this.Controls.Add(this.moonLabel7);
            this.Controls.Add(this.btn_BuscarCliente);
            this.Controls.Add(this.btn_CadastraCLiente);
            this.Controls.Add(this.txt_BuscaCliente);
            this.Controls.Add(this.txt_CorProd);
            this.Controls.Add(this.moonLabel5);
            this.Controls.Add(this.moonLabel4);
            this.Controls.Add(this.moonLabel3);
            this.Controls.Add(this.btn_LimparCampos);
            this.Controls.Add(this.btn_AdicionarItem);
            this.Controls.Add(this.num_Quantidade);
            this.Controls.Add(this.moonLabel2);
            this.Controls.Add(this.moonLabel1);
            this.Controls.Add(this.txt_NomeProd);
            this.Controls.Add(this.pick_FotoProd);
            this.Controls.Add(this.txt_ValorUnitario);
            this.Controls.Add(this.txt_CodigoProd);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Vendas";
            this.Size = new System.Drawing.Size(1310, 804);
            this.Load += new System.EventHandler(this.UC_Vendas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pick_FotoProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Carrinho)).EndInit();
            this.panelSombreado1.ResumeLayout(false);
            this.panelSombreado1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_CodigoProd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_ValorUnitario;
        private ReaLTaiizor.Controls.HopePictureBox pick_FotoProd;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_NomeProd;
        private ReaLTaiizor.Controls.MoonLabel moonLabel1;
        private ReaLTaiizor.Controls.MoonLabel moonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_Quantidade;
        private System.Windows.Forms.DataGridView dgv_Carrinho;
        private FontAwesome.Sharp.IconButton btn_AdicionarItem;
        private FontAwesome.Sharp.IconButton btn_LimparCampos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_AlterarItem;
        private FontAwesome.Sharp.IconButton btn_FinalizarVenda;
        private ReaLTaiizor.Controls.MoonLabel moonLabel3;
        private ReaLTaiizor.Controls.MoonLabel moonLabel4;
        private ReaLTaiizor.Controls.MoonLabel moonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_CorProd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ExcluirItemCarrinho;
        private ReaLTaiizor.Controls.MoonLabel moonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_ValorFinal;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_BuscaCliente;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_CadastraCLiente;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_BuscarCliente;
        private ReaLTaiizor.Controls.MoonLabel moonLabel7;
        private PanelSombreado panelSombreado1;
    }
}
