namespace Projeto_FinalOficial
{
    partial class Principla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pn_Principal = new System.Windows.Forms.Panel();
            this.pn_SubMenuEstoque = new System.Windows.Forms.Panel();
            this.btn_LançarNota = new FontAwesome.Sharp.IconButton();
            this.btn_FazerPed = new FontAwesome.Sharp.IconButton();
            this.btn_EstoqGeral = new FontAwesome.Sharp.IconButton();
            this.btn_MenuEstoque = new FontAwesome.Sharp.IconButton();
            this.pn_SubMenuVendedor = new System.Windows.Forms.Panel();
            this.btn_Desemp = new FontAwesome.Sharp.IconButton();
            this.btn_Vendedor = new FontAwesome.Sharp.IconButton();
            this.btn_MenuVendas = new FontAwesome.Sharp.IconButton();
            this.pn_SubMenuGerente = new System.Windows.Forms.Panel();
            this.btn_Relatorio = new FontAwesome.Sharp.IconButton();
            this.btn_CadForn = new FontAwesome.Sharp.IconButton();
            this.btn_CadProd = new FontAwesome.Sharp.IconButton();
            this.btn_CadFun = new FontAwesome.Sharp.IconButton();
            this.btn_Monitoramento = new FontAwesome.Sharp.IconButton();
            this.Btn_MenuGerente = new FontAwesome.Sharp.IconButton();
            this.pn_Logo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pn_MenuSup = new System.Windows.Forms.Panel();
            this.btn_Layout = new FontAwesome.Sharp.IconButton();
            this.icon_mod = new FontAwesome.Sharp.IconButton();
            this.btn_Sair = new FontAwesome.Sharp.IconButton();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.suit = new System.Windows.Forms.Label();
            this.Crimson = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.cyberProgressBar1 = new ReaLTaiizor.Controls.CyberProgressBar();
            this.timerSidebar = new System.Windows.Forms.Timer(this.components);
            this.pn_Principal.SuspendLayout();
            this.pn_SubMenuEstoque.SuspendLayout();
            this.pn_SubMenuVendedor.SuspendLayout();
            this.pn_SubMenuGerente.SuspendLayout();
            this.pn_Logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pn_MenuSup.SuspendLayout();
            this.pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_Principal
            // 
            this.pn_Principal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.pn_Principal.Controls.Add(this.pn_SubMenuEstoque);
            this.pn_Principal.Controls.Add(this.btn_MenuEstoque);
            this.pn_Principal.Controls.Add(this.pn_SubMenuVendedor);
            this.pn_Principal.Controls.Add(this.btn_MenuVendas);
            this.pn_Principal.Controls.Add(this.pn_SubMenuGerente);
            this.pn_Principal.Controls.Add(this.Btn_MenuGerente);
            this.pn_Principal.Controls.Add(this.pn_Logo);
            this.pn_Principal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_Principal.Location = new System.Drawing.Point(0, 0);
            this.pn_Principal.Name = "pn_Principal";
            this.pn_Principal.Size = new System.Drawing.Size(159, 540);
            this.pn_Principal.TabIndex = 0;
            this.pn_Principal.Tag = "Fixo";
            this.pn_Principal.MouseEnter += new System.EventHandler(this.pn_Principal_MouseEnter);
            this.pn_Principal.MouseLeave += new System.EventHandler(this.pn_Principal_MouseLeave);
            // 
            // pn_SubMenuEstoque
            // 
            this.pn_SubMenuEstoque.Controls.Add(this.btn_LançarNota);
            this.pn_SubMenuEstoque.Controls.Add(this.btn_FazerPed);
            this.pn_SubMenuEstoque.Controls.Add(this.btn_EstoqGeral);
            this.pn_SubMenuEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SubMenuEstoque.Location = new System.Drawing.Point(0, 319);
            this.pn_SubMenuEstoque.Name = "pn_SubMenuEstoque";
            this.pn_SubMenuEstoque.Size = new System.Drawing.Size(159, 71);
            this.pn_SubMenuEstoque.TabIndex = 7;
            // 
            // btn_LançarNota
            // 
            this.btn_LançarNota.BackColor = System.Drawing.Color.Gray;
            this.btn_LançarNota.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_LançarNota.FlatAppearance.BorderSize = 0;
            this.btn_LançarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LançarNota.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_LançarNota.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            this.btn_LançarNota.IconColor = System.Drawing.Color.Black;
            this.btn_LançarNota.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_LançarNota.IconSize = 28;
            this.btn_LançarNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LançarNota.Location = new System.Drawing.Point(0, 46);
            this.btn_LançarNota.Name = "btn_LançarNota";
            this.btn_LançarNota.Size = new System.Drawing.Size(159, 23);
            this.btn_LançarNota.TabIndex = 6;
            this.btn_LançarNota.Text = "Lançar Notas";
            this.btn_LançarNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LançarNota.UseVisualStyleBackColor = false;
            this.btn_LançarNota.Click += new System.EventHandler(this.btn_LançarNota_Click);
            // 
            // btn_FazerPed
            // 
            this.btn_FazerPed.BackColor = System.Drawing.Color.Gray;
            this.btn_FazerPed.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_FazerPed.FlatAppearance.BorderSize = 0;
            this.btn_FazerPed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FazerPed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_FazerPed.IconChar = FontAwesome.Sharp.IconChar.UserTag;
            this.btn_FazerPed.IconColor = System.Drawing.Color.Black;
            this.btn_FazerPed.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_FazerPed.IconSize = 28;
            this.btn_FazerPed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FazerPed.Location = new System.Drawing.Point(0, 23);
            this.btn_FazerPed.Name = "btn_FazerPed";
            this.btn_FazerPed.Size = new System.Drawing.Size(159, 23);
            this.btn_FazerPed.TabIndex = 5;
            this.btn_FazerPed.Text = "Fazer Pedido";
            this.btn_FazerPed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FazerPed.UseVisualStyleBackColor = false;
            this.btn_FazerPed.Click += new System.EventHandler(this.btn_FazerPed_Click);
            // 
            // btn_EstoqGeral
            // 
            this.btn_EstoqGeral.BackColor = System.Drawing.Color.Gray;
            this.btn_EstoqGeral.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_EstoqGeral.FlatAppearance.BorderSize = 0;
            this.btn_EstoqGeral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EstoqGeral.ForeColor = System.Drawing.Color.Black;
            this.btn_EstoqGeral.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            this.btn_EstoqGeral.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_EstoqGeral.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_EstoqGeral.IconSize = 28;
            this.btn_EstoqGeral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EstoqGeral.Location = new System.Drawing.Point(0, 0);
            this.btn_EstoqGeral.Name = "btn_EstoqGeral";
            this.btn_EstoqGeral.Size = new System.Drawing.Size(159, 23);
            this.btn_EstoqGeral.TabIndex = 4;
            this.btn_EstoqGeral.Text = "Geral";
            this.btn_EstoqGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EstoqGeral.UseVisualStyleBackColor = false;
            this.btn_EstoqGeral.Click += new System.EventHandler(this.btn_EstoqGeral_Click);
            // 
            // btn_MenuEstoque
            // 
            this.btn_MenuEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuEstoque.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btn_MenuEstoque.IconColor = System.Drawing.Color.Black;
            this.btn_MenuEstoque.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuEstoque.IconSize = 32;
            this.btn_MenuEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuEstoque.Location = new System.Drawing.Point(0, 281);
            this.btn_MenuEstoque.Name = "btn_MenuEstoque";
            this.btn_MenuEstoque.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_MenuEstoque.Size = new System.Drawing.Size(159, 38);
            this.btn_MenuEstoque.TabIndex = 6;
            this.btn_MenuEstoque.Text = "Estoque";
            this.btn_MenuEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_MenuEstoque.UseVisualStyleBackColor = true;
            this.btn_MenuEstoque.Click += new System.EventHandler(this.btn_MenuEstoque_Click);
            this.btn_MenuEstoque.MouseEnter += new System.EventHandler(this.pn_Principal_MouseEnter);
            this.btn_MenuEstoque.MouseLeave += new System.EventHandler(this.pn_Principal_MouseLeave);
            // 
            // pn_SubMenuVendedor
            // 
            this.pn_SubMenuVendedor.Controls.Add(this.btn_Desemp);
            this.pn_SubMenuVendedor.Controls.Add(this.btn_Vendedor);
            this.pn_SubMenuVendedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SubMenuVendedor.Location = new System.Drawing.Point(0, 227);
            this.pn_SubMenuVendedor.Name = "pn_SubMenuVendedor";
            this.pn_SubMenuVendedor.Size = new System.Drawing.Size(159, 54);
            this.pn_SubMenuVendedor.TabIndex = 5;
            // 
            // btn_Desemp
            // 
            this.btn_Desemp.BackColor = System.Drawing.Color.Gray;
            this.btn_Desemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Desemp.FlatAppearance.BorderSize = 0;
            this.btn_Desemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Desemp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Desemp.IconChar = FontAwesome.Sharp.IconChar.UserTag;
            this.btn_Desemp.IconColor = System.Drawing.Color.Black;
            this.btn_Desemp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Desemp.IconSize = 28;
            this.btn_Desemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Desemp.Location = new System.Drawing.Point(0, 23);
            this.btn_Desemp.Name = "btn_Desemp";
            this.btn_Desemp.Size = new System.Drawing.Size(159, 31);
            this.btn_Desemp.TabIndex = 5;
            this.btn_Desemp.Text = "Meu Desempenho";
            this.btn_Desemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Desemp.UseVisualStyleBackColor = false;
            this.btn_Desemp.Click += new System.EventHandler(this.btn_Desemp_Click);
            // 
            // btn_Vendedor
            // 
            this.btn_Vendedor.BackColor = System.Drawing.Color.Gray;
            this.btn_Vendedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Vendedor.FlatAppearance.BorderSize = 0;
            this.btn_Vendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Vendedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Vendedor.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            this.btn_Vendedor.IconColor = System.Drawing.Color.Black;
            this.btn_Vendedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Vendedor.IconSize = 28;
            this.btn_Vendedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Vendedor.Location = new System.Drawing.Point(0, 0);
            this.btn_Vendedor.Name = "btn_Vendedor";
            this.btn_Vendedor.Size = new System.Drawing.Size(159, 23);
            this.btn_Vendedor.TabIndex = 4;
            this.btn_Vendedor.Text = "Vendedor";
            this.btn_Vendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Vendedor.UseVisualStyleBackColor = false;
            this.btn_Vendedor.Click += new System.EventHandler(this.btn_Vendedor_Click);
            // 
            // btn_MenuVendas
            // 
            this.btn_MenuVendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuVendas.IconChar = FontAwesome.Sharp.IconChar.BasketShopping;
            this.btn_MenuVendas.IconColor = System.Drawing.Color.Black;
            this.btn_MenuVendas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuVendas.IconSize = 32;
            this.btn_MenuVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuVendas.Location = new System.Drawing.Point(0, 189);
            this.btn_MenuVendas.Name = "btn_MenuVendas";
            this.btn_MenuVendas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_MenuVendas.Size = new System.Drawing.Size(159, 38);
            this.btn_MenuVendas.TabIndex = 4;
            this.btn_MenuVendas.Text = "Vendas";
            this.btn_MenuVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_MenuVendas.UseVisualStyleBackColor = true;
            this.btn_MenuVendas.Click += new System.EventHandler(this.btn_MenuVendas_Click);
            this.btn_MenuVendas.MouseEnter += new System.EventHandler(this.pn_Principal_MouseEnter);
            this.btn_MenuVendas.MouseLeave += new System.EventHandler(this.pn_Principal_MouseLeave);
            // 
            // pn_SubMenuGerente
            // 
            this.pn_SubMenuGerente.Controls.Add(this.btn_Relatorio);
            this.pn_SubMenuGerente.Controls.Add(this.btn_CadForn);
            this.pn_SubMenuGerente.Controls.Add(this.btn_CadProd);
            this.pn_SubMenuGerente.Controls.Add(this.btn_CadFun);
            this.pn_SubMenuGerente.Controls.Add(this.btn_Monitoramento);
            this.pn_SubMenuGerente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SubMenuGerente.Location = new System.Drawing.Point(0, 75);
            this.pn_SubMenuGerente.Name = "pn_SubMenuGerente";
            this.pn_SubMenuGerente.Size = new System.Drawing.Size(159, 114);
            this.pn_SubMenuGerente.TabIndex = 3;
            // 
            // btn_Relatorio
            // 
            this.btn_Relatorio.BackColor = System.Drawing.Color.Gray;
            this.btn_Relatorio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Relatorio.FlatAppearance.BorderSize = 0;
            this.btn_Relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Relatorio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Relatorio.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.btn_Relatorio.IconColor = System.Drawing.Color.Black;
            this.btn_Relatorio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Relatorio.IconSize = 28;
            this.btn_Relatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Relatorio.Location = new System.Drawing.Point(0, 92);
            this.btn_Relatorio.Name = "btn_Relatorio";
            this.btn_Relatorio.Size = new System.Drawing.Size(159, 23);
            this.btn_Relatorio.TabIndex = 8;
            this.btn_Relatorio.Text = "Relatorios";
            this.btn_Relatorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Relatorio.UseVisualStyleBackColor = false;
            // 
            // btn_CadForn
            // 
            this.btn_CadForn.BackColor = System.Drawing.Color.Gray;
            this.btn_CadForn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_CadForn.FlatAppearance.BorderSize = 0;
            this.btn_CadForn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CadForn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_CadForn.IconChar = FontAwesome.Sharp.IconChar.TruckPlane;
            this.btn_CadForn.IconColor = System.Drawing.Color.Black;
            this.btn_CadForn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_CadForn.IconSize = 28;
            this.btn_CadForn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CadForn.Location = new System.Drawing.Point(0, 69);
            this.btn_CadForn.Name = "btn_CadForn";
            this.btn_CadForn.Size = new System.Drawing.Size(159, 23);
            this.btn_CadForn.TabIndex = 7;
            this.btn_CadForn.Text = "Cadastro Fornecedores";
            this.btn_CadForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CadForn.UseVisualStyleBackColor = false;
            this.btn_CadForn.Click += new System.EventHandler(this.btn_CadForn_Click);
            // 
            // btn_CadProd
            // 
            this.btn_CadProd.BackColor = System.Drawing.Color.Gray;
            this.btn_CadProd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_CadProd.FlatAppearance.BorderSize = 0;
            this.btn_CadProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CadProd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_CadProd.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            this.btn_CadProd.IconColor = System.Drawing.Color.Black;
            this.btn_CadProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_CadProd.IconSize = 28;
            this.btn_CadProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CadProd.Location = new System.Drawing.Point(0, 46);
            this.btn_CadProd.Name = "btn_CadProd";
            this.btn_CadProd.Size = new System.Drawing.Size(159, 23);
            this.btn_CadProd.TabIndex = 6;
            this.btn_CadProd.Text = "Cadastro Produtos";
            this.btn_CadProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CadProd.UseVisualStyleBackColor = false;
            this.btn_CadProd.Click += new System.EventHandler(this.btn_CadProd_Click);
            // 
            // btn_CadFun
            // 
            this.btn_CadFun.BackColor = System.Drawing.Color.Gray;
            this.btn_CadFun.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_CadFun.FlatAppearance.BorderSize = 0;
            this.btn_CadFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CadFun.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_CadFun.IconChar = FontAwesome.Sharp.IconChar.UserTag;
            this.btn_CadFun.IconColor = System.Drawing.Color.Black;
            this.btn_CadFun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_CadFun.IconSize = 28;
            this.btn_CadFun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CadFun.Location = new System.Drawing.Point(0, 23);
            this.btn_CadFun.Name = "btn_CadFun";
            this.btn_CadFun.Size = new System.Drawing.Size(159, 23);
            this.btn_CadFun.TabIndex = 5;
            this.btn_CadFun.Text = "Cadastro Funcionarios";
            this.btn_CadFun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CadFun.UseVisualStyleBackColor = false;
            this.btn_CadFun.Click += new System.EventHandler(this.btn_CadFun_Click);
            // 
            // btn_Monitoramento
            // 
            this.btn_Monitoramento.BackColor = System.Drawing.Color.Gray;
            this.btn_Monitoramento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Monitoramento.FlatAppearance.BorderSize = 0;
            this.btn_Monitoramento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Monitoramento.ForeColor = System.Drawing.Color.Black;
            this.btn_Monitoramento.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            this.btn_Monitoramento.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Monitoramento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Monitoramento.IconSize = 28;
            this.btn_Monitoramento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Monitoramento.Location = new System.Drawing.Point(0, 0);
            this.btn_Monitoramento.Name = "btn_Monitoramento";
            this.btn_Monitoramento.Size = new System.Drawing.Size(159, 23);
            this.btn_Monitoramento.TabIndex = 4;
            this.btn_Monitoramento.Text = "Monitoramento";
            this.btn_Monitoramento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Monitoramento.UseVisualStyleBackColor = true;
            this.btn_Monitoramento.Click += new System.EventHandler(this.btn_Monitoramento_Click);
            // 
            // Btn_MenuGerente
            // 
            this.Btn_MenuGerente.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_MenuGerente.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.Btn_MenuGerente.IconColor = System.Drawing.Color.Black;
            this.Btn_MenuGerente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_MenuGerente.IconSize = 32;
            this.Btn_MenuGerente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_MenuGerente.Location = new System.Drawing.Point(0, 37);
            this.Btn_MenuGerente.Name = "Btn_MenuGerente";
            this.Btn_MenuGerente.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Btn_MenuGerente.Size = new System.Drawing.Size(159, 38);
            this.Btn_MenuGerente.TabIndex = 1;
            this.Btn_MenuGerente.Text = "Gerenciamento";
            this.Btn_MenuGerente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_MenuGerente.UseVisualStyleBackColor = true;
            this.Btn_MenuGerente.Click += new System.EventHandler(this.Btn_MenuGerente_Click);
            this.Btn_MenuGerente.MouseEnter += new System.EventHandler(this.pn_Principal_MouseEnter);
            this.Btn_MenuGerente.MouseLeave += new System.EventHandler(this.pn_Principal_MouseLeave);
            // 
            // pn_Logo
            // 
            this.pn_Logo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pn_Logo.Controls.Add(this.label2);
            this.pn_Logo.Controls.Add(this.label1);
            this.pn_Logo.Controls.Add(this.pictureBox1);
            this.pn_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Logo.Location = new System.Drawing.Point(0, 0);
            this.pn_Logo.Name = "pn_Logo";
            this.pn_Logo.Size = new System.Drawing.Size(159, 37);
            this.pn_Logo.TabIndex = 0;
            this.pn_Logo.Tag = "Fixo";
            this.pn_Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_MenuSup_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.label2.Location = new System.Drawing.Point(86, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "S U I T";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_MenuSup_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(64, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Crimson";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_MenuSup_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Projeto_FinalOficial.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_MenuSup_MouseDown);
            // 
            // pn_MenuSup
            // 
            this.pn_MenuSup.BackColor = System.Drawing.SystemColors.Control;
            this.pn_MenuSup.Controls.Add(this.btn_Layout);
            this.pn_MenuSup.Controls.Add(this.icon_mod);
            this.pn_MenuSup.Controls.Add(this.btn_Sair);
            this.pn_MenuSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_MenuSup.Location = new System.Drawing.Point(159, 0);
            this.pn_MenuSup.Name = "pn_MenuSup";
            this.pn_MenuSup.Size = new System.Drawing.Size(647, 37);
            this.pn_MenuSup.TabIndex = 1;
            this.pn_MenuSup.Tag = "Fixo";
            this.pn_MenuSup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pn_MenuSup_MouseDown);
            // 
            // btn_Layout
            // 
            this.btn_Layout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Layout.IconChar = FontAwesome.Sharp.IconChar.Moon;
            this.btn_Layout.IconColor = System.Drawing.Color.Black;
            this.btn_Layout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Layout.IconSize = 30;
            this.btn_Layout.Location = new System.Drawing.Point(556, 0);
            this.btn_Layout.Name = "btn_Layout";
            this.btn_Layout.Size = new System.Drawing.Size(29, 37);
            this.btn_Layout.TabIndex = 5;
            this.btn_Layout.UseVisualStyleBackColor = true;
            this.btn_Layout.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // icon_mod
            // 
            this.icon_mod.Dock = System.Windows.Forms.DockStyle.Right;
            this.icon_mod.FlatAppearance.BorderSize = 0;
            this.icon_mod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icon_mod.IconChar = FontAwesome.Sharp.IconChar.Compress;
            this.icon_mod.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.icon_mod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icon_mod.IconSize = 25;
            this.icon_mod.Location = new System.Drawing.Point(585, 0);
            this.icon_mod.Name = "icon_mod";
            this.icon_mod.Size = new System.Drawing.Size(31, 37);
            this.icon_mod.TabIndex = 4;
            this.icon_mod.UseVisualStyleBackColor = true;
            this.icon_mod.Click += new System.EventHandler(this.icon_mod_Click);
            // 
            // btn_Sair
            // 
            this.btn_Sair.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Sair.FlatAppearance.BorderSize = 0;
            this.btn_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sair.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btn_Sair.IconColor = System.Drawing.Color.Red;
            this.btn_Sair.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Sair.IconSize = 30;
            this.btn_Sair.Location = new System.Drawing.Point(616, 0);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(31, 37);
            this.btn_Sair.TabIndex = 2;
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pnlConteudo.Controls.Add(this.suit);
            this.pnlConteudo.Controls.Add(this.Crimson);
            this.pnlConteudo.Controls.Add(this.Logo);
            this.pnlConteudo.Controls.Add(this.cyberProgressBar1);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.ForeColor = System.Drawing.Color.White;
            this.pnlConteudo.Location = new System.Drawing.Point(159, 37);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(647, 503);
            this.pnlConteudo.TabIndex = 2;
            // 
            // suit
            // 
            this.suit.AutoSize = true;
            this.suit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.suit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suit.Font = new System.Drawing.Font("Sylfaen", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.suit.Location = new System.Drawing.Point(387, 207);
            this.suit.Name = "suit";
            this.suit.Size = new System.Drawing.Size(134, 48);
            this.suit.TabIndex = 9;
            this.suit.Text = "S U I T";
            // 
            // Crimson
            // 
            this.Crimson.AutoSize = true;
            this.Crimson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Crimson.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crimson.ForeColor = System.Drawing.Color.Black;
            this.Crimson.Location = new System.Drawing.Point(283, 163);
            this.Crimson.Name = "Crimson";
            this.Crimson.Size = new System.Drawing.Size(187, 50);
            this.Crimson.TabIndex = 8;
            this.Crimson.Text = "Crimson";
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Logo.Image = global::Projeto_FinalOficial.Properties.Resources.Logo;
            this.Logo.Location = new System.Drawing.Point(54, 107);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(318, 221);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 7;
            this.Logo.TabStop = false;
            // 
            // cyberProgressBar1
            // 
            this.cyberProgressBar1.Alpha = 50;
            this.cyberProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.cyberProgressBar1.Background = true;
            this.cyberProgressBar1.Background_WidthPen = 3F;
            this.cyberProgressBar1.BackgroundPen = true;
            this.cyberProgressBar1.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberProgressBar1.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberProgressBar1.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberProgressBar1.ColorBackground_Pen = System.Drawing.Color.Red;
            this.cyberProgressBar1.ColorBackground_Value_1 = System.Drawing.Color.Red;
            this.cyberProgressBar1.ColorBackground_Value_2 = System.Drawing.Color.Red;
            this.cyberProgressBar1.ColorLighting = System.Drawing.Color.Red;
            this.cyberProgressBar1.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberProgressBar1.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberProgressBar1.ColorProgressBar = System.Drawing.Color.Red;
            this.cyberProgressBar1.ColorValue_Transparency = 200;
            this.cyberProgressBar1.CyberProgressBarStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberProgressBar1.Font = new System.Drawing.Font("Arial", 11F);
            this.cyberProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cyberProgressBar1.Lighting = false;
            this.cyberProgressBar1.LinearGradient_Background = false;
            this.cyberProgressBar1.LinearGradient_Value = false;
            this.cyberProgressBar1.LinearGradientPen = false;
            this.cyberProgressBar1.Location = new System.Drawing.Point(184, 383);
            this.cyberProgressBar1.Maximum = 100;
            this.cyberProgressBar1.Minimum = 0;
            this.cyberProgressBar1.Name = "cyberProgressBar1";
            this.cyberProgressBar1.PenWidth = 10;
            this.cyberProgressBar1.ProgressText = true;
            this.cyberProgressBar1.RGB = false;
            this.cyberProgressBar1.Rounding = true;
            this.cyberProgressBar1.RoundingInt = 70;
            this.cyberProgressBar1.Size = new System.Drawing.Size(303, 23);
            this.cyberProgressBar1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberProgressBar1.StartDrawingValue = 0;
            this.cyberProgressBar1.TabIndex = 0;
            this.cyberProgressBar1.Tag = "Cyber";
            this.cyberProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberProgressBar1.Timer_RGB = 300;
            this.cyberProgressBar1.Value = 0;
            // 
            // timerSidebar
            // 
            this.timerSidebar.Tick += new System.EventHandler(this.timerSidebar_Tick);
            // 
            // Principla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(806, 540);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pn_MenuSup);
            this.Controls.Add(this.pn_Principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Principla";
            this.Text = "cls";
            this.Load += new System.EventHandler(this.Principla_Load_1);
            this.pn_Principal.ResumeLayout(false);
            this.pn_SubMenuEstoque.ResumeLayout(false);
            this.pn_SubMenuVendedor.ResumeLayout(false);
            this.pn_SubMenuGerente.ResumeLayout(false);
            this.pn_Logo.ResumeLayout(false);
            this.pn_Logo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pn_MenuSup.ResumeLayout(false);
            this.pnlConteudo.ResumeLayout(false);
            this.pnlConteudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Principal;
        private System.Windows.Forms.Panel pn_MenuSup;
        private FontAwesome.Sharp.IconButton btn_Sair;
        private FontAwesome.Sharp.IconButton Btn_MenuGerente;
        private System.Windows.Forms.Panel pn_Logo;
        private System.Windows.Forms.Panel pn_SubMenuGerente;
        private FontAwesome.Sharp.IconButton btn_Monitoramento;
        private FontAwesome.Sharp.IconButton btn_Relatorio;
        private FontAwesome.Sharp.IconButton btn_CadForn;
        private FontAwesome.Sharp.IconButton btn_CadProd;
        private FontAwesome.Sharp.IconButton btn_CadFun;
        private System.Windows.Forms.Panel pnlConteudo;
        private FontAwesome.Sharp.IconButton icon_mod;
        private System.Windows.Forms.Panel pn_SubMenuVendedor;
        private FontAwesome.Sharp.IconButton btn_Desemp;
        private FontAwesome.Sharp.IconButton btn_Vendedor;
        private FontAwesome.Sharp.IconButton btn_MenuVendas;
        private System.Windows.Forms.Panel pn_SubMenuEstoque;
        private FontAwesome.Sharp.IconButton btn_LançarNota;
        private FontAwesome.Sharp.IconButton btn_FazerPed;
        private FontAwesome.Sharp.IconButton btn_EstoqGeral;
        private FontAwesome.Sharp.IconButton btn_MenuEstoque;
        private ReaLTaiizor.Controls.CyberProgressBar cyberProgressBar1;
        private FontAwesome.Sharp.IconButton btn_Layout;
        private System.Windows.Forms.Timer timerSidebar;
        private System.Windows.Forms.Label Crimson;
        private System.Windows.Forms.Label suit;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}