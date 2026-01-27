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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principla));
            this.pn_MenuSup = new System.Windows.Forms.Panel();
            this.btn_Layout = new FontAwesome.Sharp.IconButton();
            this.icon_mod = new FontAwesome.Sharp.IconButton();
            this.btn_Sair = new FontAwesome.Sharp.IconButton();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.cyberProgressBar1 = new ReaLTaiizor.Controls.CyberProgressBar();
            this.timerSidebar = new System.Windows.Forms.Timer(this.components);
            this.pn_Principal = new PanelSombreado();
            this.subMenuFinanceiro = new System.Windows.Forms.Panel();
            this.btn_Lucro = new FontAwesome.Sharp.IconButton();
            this.btn_ContasPagar = new FontAwesome.Sharp.IconButton();
            this.btn_SalarioFunc = new FontAwesome.Sharp.IconButton();
            this.btn_SubMenuFinanceiro = new FontAwesome.Sharp.IconButton();
            this.pn_SubMenuEstoque = new System.Windows.Forms.Panel();
            this.btn_LançarNota = new FontAwesome.Sharp.IconButton();
            this.btn_FazerPed = new FontAwesome.Sharp.IconButton();
            this.btn_EstoqGeral = new FontAwesome.Sharp.IconButton();
            this.btn_MenuEstoque = new FontAwesome.Sharp.IconButton();
            this.pn_SubMenuVendedor = new System.Windows.Forms.Panel();
            this.btn_Vendedor = new FontAwesome.Sharp.IconButton();
            this.btn_Desemp = new FontAwesome.Sharp.IconButton();
            this.btn_MenuVendas = new FontAwesome.Sharp.IconButton();
            this.pn_SubMenuGerente = new System.Windows.Forms.Panel();
            this.btn_Relatorio = new FontAwesome.Sharp.IconButton();
            this.btn_CadForn = new FontAwesome.Sharp.IconButton();
            this.btn_CadProd = new FontAwesome.Sharp.IconButton();
            this.btn_CadFun = new FontAwesome.Sharp.IconButton();
            this.btn_Monitoramento = new FontAwesome.Sharp.IconButton();
            this.Btn_MenuGerente = new FontAwesome.Sharp.IconButton();
            this.pn_Logo = new System.Windows.Forms.Panel();
            this.pn_MenuSup.SuspendLayout();
            this.pnlConteudo.SuspendLayout();
            this.pn_Principal.SuspendLayout();
            this.subMenuFinanceiro.SuspendLayout();
            this.pn_SubMenuEstoque.SuspendLayout();
            this.pn_SubMenuVendedor.SuspendLayout();
            this.pn_SubMenuGerente.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_MenuSup
            // 
            this.pn_MenuSup.BackColor = System.Drawing.SystemColors.Control;
            this.pn_MenuSup.Controls.Add(this.btn_Layout);
            this.pn_MenuSup.Controls.Add(this.icon_mod);
            this.pn_MenuSup.Controls.Add(this.btn_Sair);
            this.pn_MenuSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_MenuSup.Location = new System.Drawing.Point(224, 0);
            this.pn_MenuSup.Margin = new System.Windows.Forms.Padding(4);
            this.pn_MenuSup.Name = "pn_MenuSup";
            this.pn_MenuSup.Size = new System.Drawing.Size(820, 46);
            this.pn_MenuSup.TabIndex = 1;
            this.pn_MenuSup.Tag = "Fixo";
            // 
            // btn_Layout
            // 
            this.btn_Layout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Layout.IconChar = FontAwesome.Sharp.IconChar.Moon;
            this.btn_Layout.IconColor = System.Drawing.Color.Black;
            this.btn_Layout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Layout.IconSize = 30;
            this.btn_Layout.Location = new System.Drawing.Point(699, 0);
            this.btn_Layout.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Layout.Name = "btn_Layout";
            this.btn_Layout.Size = new System.Drawing.Size(39, 46);
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
            this.icon_mod.Location = new System.Drawing.Point(738, 0);
            this.icon_mod.Margin = new System.Windows.Forms.Padding(4);
            this.icon_mod.Name = "icon_mod";
            this.icon_mod.Size = new System.Drawing.Size(41, 46);
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
            this.btn_Sair.Location = new System.Drawing.Point(779, 0);
            this.btn_Sair.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(41, 46);
            this.btn_Sair.TabIndex = 2;
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlConteudo.BackgroundImage")));
            this.pnlConteudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlConteudo.Controls.Add(this.cyberProgressBar1);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(224, 46);
            this.pnlConteudo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(820, 742);
            this.pnlConteudo.TabIndex = 2;
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
            this.cyberProgressBar1.Location = new System.Drawing.Point(294, 309);
            this.cyberProgressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.cyberProgressBar1.Maximum = 100;
            this.cyberProgressBar1.Minimum = 0;
            this.cyberProgressBar1.Name = "cyberProgressBar1";
            this.cyberProgressBar1.PenWidth = 10;
            this.cyberProgressBar1.ProgressText = true;
            this.cyberProgressBar1.RGB = false;
            this.cyberProgressBar1.Rounding = true;
            this.cyberProgressBar1.RoundingInt = 70;
            this.cyberProgressBar1.Size = new System.Drawing.Size(404, 28);
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
            // pn_Principal
            // 
            this.pn_Principal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.pn_Principal.Controls.Add(this.subMenuFinanceiro);
            this.pn_Principal.Controls.Add(this.btn_SubMenuFinanceiro);
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
            this.pn_Principal.Padding = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.pn_Principal.Size = new System.Drawing.Size(224, 788);
            this.pn_Principal.TabIndex = 0;
            // 
            // subMenuFinanceiro
            // 
            this.subMenuFinanceiro.Controls.Add(this.btn_Lucro);
            this.subMenuFinanceiro.Controls.Add(this.btn_ContasPagar);
            this.subMenuFinanceiro.Controls.Add(this.btn_SalarioFunc);
            this.subMenuFinanceiro.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuFinanceiro.Location = new System.Drawing.Point(5, 654);
            this.subMenuFinanceiro.Margin = new System.Windows.Forms.Padding(4);
            this.subMenuFinanceiro.Name = "subMenuFinanceiro";
            this.subMenuFinanceiro.Size = new System.Drawing.Size(214, 87);
            this.subMenuFinanceiro.TabIndex = 18;
            // 
            // btn_Lucro
            // 
            this.btn_Lucro.BackColor = System.Drawing.Color.Gray;
            this.btn_Lucro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Lucro.FlatAppearance.BorderSize = 0;
            this.btn_Lucro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Lucro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Lucro.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            this.btn_Lucro.IconColor = System.Drawing.Color.Black;
            this.btn_Lucro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Lucro.IconSize = 28;
            this.btn_Lucro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Lucro.Location = new System.Drawing.Point(0, 56);
            this.btn_Lucro.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Lucro.Name = "btn_Lucro";
            this.btn_Lucro.Size = new System.Drawing.Size(214, 31);
            this.btn_Lucro.TabIndex = 6;
            this.btn_Lucro.Text = "Lucro";
            this.btn_Lucro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Lucro.UseVisualStyleBackColor = false;
            this.btn_Lucro.Click += new System.EventHandler(this.btn_Lucro_Click);
            // 
            // btn_ContasPagar
            // 
            this.btn_ContasPagar.BackColor = System.Drawing.Color.Gray;
            this.btn_ContasPagar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ContasPagar.FlatAppearance.BorderSize = 0;
            this.btn_ContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ContasPagar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ContasPagar.IconChar = FontAwesome.Sharp.IconChar.UserTag;
            this.btn_ContasPagar.IconColor = System.Drawing.Color.Black;
            this.btn_ContasPagar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_ContasPagar.IconSize = 28;
            this.btn_ContasPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ContasPagar.Location = new System.Drawing.Point(0, 28);
            this.btn_ContasPagar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ContasPagar.Name = "btn_ContasPagar";
            this.btn_ContasPagar.Size = new System.Drawing.Size(214, 28);
            this.btn_ContasPagar.TabIndex = 5;
            this.btn_ContasPagar.Text = "Contas ";
            this.btn_ContasPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ContasPagar.UseVisualStyleBackColor = false;
            this.btn_ContasPagar.Click += new System.EventHandler(this.btn_ContasPagar_Click);
            // 
            // btn_SalarioFunc
            // 
            this.btn_SalarioFunc.BackColor = System.Drawing.Color.Gray;
            this.btn_SalarioFunc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SalarioFunc.FlatAppearance.BorderSize = 0;
            this.btn_SalarioFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SalarioFunc.ForeColor = System.Drawing.Color.Black;
            this.btn_SalarioFunc.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            this.btn_SalarioFunc.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_SalarioFunc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_SalarioFunc.IconSize = 28;
            this.btn_SalarioFunc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SalarioFunc.Location = new System.Drawing.Point(0, 0);
            this.btn_SalarioFunc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SalarioFunc.Name = "btn_SalarioFunc";
            this.btn_SalarioFunc.Size = new System.Drawing.Size(214, 28);
            this.btn_SalarioFunc.TabIndex = 4;
            this.btn_SalarioFunc.Text = "Salario";
            this.btn_SalarioFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SalarioFunc.UseVisualStyleBackColor = false;
            this.btn_SalarioFunc.Click += new System.EventHandler(this.btn_SalarioFunc_Click);
            // 
            // btn_SubMenuFinanceiro
            // 
            this.btn_SubMenuFinanceiro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SubMenuFinanceiro.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btn_SubMenuFinanceiro.IconColor = System.Drawing.Color.Black;
            this.btn_SubMenuFinanceiro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_SubMenuFinanceiro.IconSize = 32;
            this.btn_SubMenuFinanceiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SubMenuFinanceiro.Location = new System.Drawing.Point(5, 607);
            this.btn_SubMenuFinanceiro.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SubMenuFinanceiro.Name = "btn_SubMenuFinanceiro";
            this.btn_SubMenuFinanceiro.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btn_SubMenuFinanceiro.Size = new System.Drawing.Size(214, 47);
            this.btn_SubMenuFinanceiro.TabIndex = 17;
            this.btn_SubMenuFinanceiro.Text = "Financeiro";
            this.btn_SubMenuFinanceiro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SubMenuFinanceiro.UseVisualStyleBackColor = true;
            this.btn_SubMenuFinanceiro.Click += new System.EventHandler(this.btn_SubMenuFinanceiro_Click_1);
            // 
            // pn_SubMenuEstoque
            // 
            this.pn_SubMenuEstoque.Controls.Add(this.btn_LançarNota);
            this.pn_SubMenuEstoque.Controls.Add(this.btn_FazerPed);
            this.pn_SubMenuEstoque.Controls.Add(this.btn_EstoqGeral);
            this.pn_SubMenuEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SubMenuEstoque.Location = new System.Drawing.Point(5, 520);
            this.pn_SubMenuEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.pn_SubMenuEstoque.Name = "pn_SubMenuEstoque";
            this.pn_SubMenuEstoque.Size = new System.Drawing.Size(214, 87);
            this.pn_SubMenuEstoque.TabIndex = 16;
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
            this.btn_LançarNota.Location = new System.Drawing.Point(0, 56);
            this.btn_LançarNota.Margin = new System.Windows.Forms.Padding(4);
            this.btn_LançarNota.Name = "btn_LançarNota";
            this.btn_LançarNota.Size = new System.Drawing.Size(214, 28);
            this.btn_LançarNota.TabIndex = 6;
            this.btn_LançarNota.Text = "Lançar Notas";
            this.btn_LançarNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LançarNota.UseVisualStyleBackColor = false;
            this.btn_LançarNota.Click += new System.EventHandler(this.btn_LançarNota_Click_1);
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
            this.btn_FazerPed.Location = new System.Drawing.Point(0, 28);
            this.btn_FazerPed.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FazerPed.Name = "btn_FazerPed";
            this.btn_FazerPed.Size = new System.Drawing.Size(214, 28);
            this.btn_FazerPed.TabIndex = 5;
            this.btn_FazerPed.Text = "Fazer Pedido";
            this.btn_FazerPed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FazerPed.UseVisualStyleBackColor = false;
            this.btn_FazerPed.Click += new System.EventHandler(this.btn_FazerPed_Click_1);
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
            this.btn_EstoqGeral.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EstoqGeral.Name = "btn_EstoqGeral";
            this.btn_EstoqGeral.Size = new System.Drawing.Size(214, 28);
            this.btn_EstoqGeral.TabIndex = 4;
            this.btn_EstoqGeral.Text = "Geral";
            this.btn_EstoqGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EstoqGeral.UseVisualStyleBackColor = false;
            this.btn_EstoqGeral.Click += new System.EventHandler(this.btn_EstoqGeral_Click_1);
            // 
            // btn_MenuEstoque
            // 
            this.btn_MenuEstoque.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuEstoque.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btn_MenuEstoque.IconColor = System.Drawing.Color.Black;
            this.btn_MenuEstoque.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuEstoque.IconSize = 32;
            this.btn_MenuEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuEstoque.Location = new System.Drawing.Point(5, 473);
            this.btn_MenuEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MenuEstoque.Name = "btn_MenuEstoque";
            this.btn_MenuEstoque.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btn_MenuEstoque.Size = new System.Drawing.Size(214, 47);
            this.btn_MenuEstoque.TabIndex = 15;
            this.btn_MenuEstoque.Text = "Estoque";
            this.btn_MenuEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_MenuEstoque.UseVisualStyleBackColor = true;
            this.btn_MenuEstoque.Click += new System.EventHandler(this.btn_MenuEstoque_Click_1);
            // 
            // pn_SubMenuVendedor
            // 
            this.pn_SubMenuVendedor.Controls.Add(this.btn_Vendedor);
            this.pn_SubMenuVendedor.Controls.Add(this.btn_Desemp);
            this.pn_SubMenuVendedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SubMenuVendedor.Location = new System.Drawing.Point(5, 407);
            this.pn_SubMenuVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.pn_SubMenuVendedor.Name = "pn_SubMenuVendedor";
            this.pn_SubMenuVendedor.Size = new System.Drawing.Size(214, 66);
            this.pn_SubMenuVendedor.TabIndex = 14;
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
            this.btn_Vendedor.Location = new System.Drawing.Point(0, 38);
            this.btn_Vendedor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Vendedor.Name = "btn_Vendedor";
            this.btn_Vendedor.Size = new System.Drawing.Size(214, 28);
            this.btn_Vendedor.TabIndex = 4;
            this.btn_Vendedor.Text = "Vendedor";
            this.btn_Vendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Vendedor.UseVisualStyleBackColor = false;
            this.btn_Vendedor.Click += new System.EventHandler(this.btn_Vendedor_Click_1);
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
            this.btn_Desemp.Location = new System.Drawing.Point(0, 0);
            this.btn_Desemp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Desemp.Name = "btn_Desemp";
            this.btn_Desemp.Size = new System.Drawing.Size(214, 38);
            this.btn_Desemp.TabIndex = 5;
            this.btn_Desemp.Text = "Meu Desempenho";
            this.btn_Desemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Desemp.UseVisualStyleBackColor = false;
            this.btn_Desemp.Click += new System.EventHandler(this.btn_Desemp_Click_1);
            // 
            // btn_MenuVendas
            // 
            this.btn_MenuVendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MenuVendas.IconChar = FontAwesome.Sharp.IconChar.BasketShopping;
            this.btn_MenuVendas.IconColor = System.Drawing.Color.Black;
            this.btn_MenuVendas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_MenuVendas.IconSize = 32;
            this.btn_MenuVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MenuVendas.Location = new System.Drawing.Point(5, 360);
            this.btn_MenuVendas.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MenuVendas.Name = "btn_MenuVendas";
            this.btn_MenuVendas.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btn_MenuVendas.Size = new System.Drawing.Size(214, 47);
            this.btn_MenuVendas.TabIndex = 13;
            this.btn_MenuVendas.Text = "Vendas";
            this.btn_MenuVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_MenuVendas.UseVisualStyleBackColor = true;
            this.btn_MenuVendas.Click += new System.EventHandler(this.btn_MenuVendas_Click_1);
            // 
            // pn_SubMenuGerente
            // 
            this.pn_SubMenuGerente.Controls.Add(this.btn_Relatorio);
            this.pn_SubMenuGerente.Controls.Add(this.btn_CadForn);
            this.pn_SubMenuGerente.Controls.Add(this.btn_CadProd);
            this.pn_SubMenuGerente.Controls.Add(this.btn_CadFun);
            this.pn_SubMenuGerente.Controls.Add(this.btn_Monitoramento);
            this.pn_SubMenuGerente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_SubMenuGerente.Location = new System.Drawing.Point(5, 220);
            this.pn_SubMenuGerente.Margin = new System.Windows.Forms.Padding(4);
            this.pn_SubMenuGerente.Name = "pn_SubMenuGerente";
            this.pn_SubMenuGerente.Size = new System.Drawing.Size(214, 140);
            this.pn_SubMenuGerente.TabIndex = 12;
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
            this.btn_Relatorio.Location = new System.Drawing.Point(0, 112);
            this.btn_Relatorio.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Relatorio.Name = "btn_Relatorio";
            this.btn_Relatorio.Size = new System.Drawing.Size(214, 28);
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
            this.btn_CadForn.Location = new System.Drawing.Point(0, 84);
            this.btn_CadForn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CadForn.Name = "btn_CadForn";
            this.btn_CadForn.Size = new System.Drawing.Size(214, 28);
            this.btn_CadForn.TabIndex = 7;
            this.btn_CadForn.Text = "Cadastro Fornecedores";
            this.btn_CadForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CadForn.UseVisualStyleBackColor = false;
            this.btn_CadForn.Click += new System.EventHandler(this.btn_CadForn_Click_1);
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
            this.btn_CadProd.Location = new System.Drawing.Point(0, 56);
            this.btn_CadProd.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CadProd.Name = "btn_CadProd";
            this.btn_CadProd.Size = new System.Drawing.Size(214, 28);
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
            this.btn_CadFun.Location = new System.Drawing.Point(0, 28);
            this.btn_CadFun.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CadFun.Name = "btn_CadFun";
            this.btn_CadFun.Size = new System.Drawing.Size(214, 28);
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
            this.btn_Monitoramento.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Monitoramento.Name = "btn_Monitoramento";
            this.btn_Monitoramento.Size = new System.Drawing.Size(214, 28);
            this.btn_Monitoramento.TabIndex = 4;
            this.btn_Monitoramento.Text = "Monitoramento";
            this.btn_Monitoramento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Monitoramento.UseVisualStyleBackColor = false;
            this.btn_Monitoramento.Click += new System.EventHandler(this.btn_Monitoramento_Click_1);
            // 
            // Btn_MenuGerente
            // 
            this.Btn_MenuGerente.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_MenuGerente.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.Btn_MenuGerente.IconColor = System.Drawing.Color.Black;
            this.Btn_MenuGerente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_MenuGerente.IconSize = 32;
            this.Btn_MenuGerente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_MenuGerente.Location = new System.Drawing.Point(5, 173);
            this.Btn_MenuGerente.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_MenuGerente.Name = "Btn_MenuGerente";
            this.Btn_MenuGerente.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.Btn_MenuGerente.Size = new System.Drawing.Size(214, 47);
            this.Btn_MenuGerente.TabIndex = 11;
            this.Btn_MenuGerente.Text = "Gerenciamento";
            this.Btn_MenuGerente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_MenuGerente.UseVisualStyleBackColor = true;
            this.Btn_MenuGerente.Click += new System.EventHandler(this.Btn_MenuGerente_Click_1);
            // 
            // pn_Logo
            // 
            this.pn_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pn_Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_Logo.BackgroundImage")));
            this.pn_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pn_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Logo.Location = new System.Drawing.Point(5, 2);
            this.pn_Logo.Margin = new System.Windows.Forms.Padding(4);
            this.pn_Logo.Name = "pn_Logo";
            this.pn_Logo.Size = new System.Drawing.Size(214, 171);
            this.pn_Logo.TabIndex = 10;
            this.pn_Logo.Tag = "Fixo";
            // 
            // Principla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1044, 788);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pn_MenuSup);
            this.Controls.Add(this.pn_Principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1021, 726);
            this.Name = "Principla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principla_Load_1);
            this.pn_MenuSup.ResumeLayout(false);
            this.pnlConteudo.ResumeLayout(false);
            this.pn_Principal.ResumeLayout(false);
            this.subMenuFinanceiro.ResumeLayout(false);
            this.pn_SubMenuEstoque.ResumeLayout(false);
            this.pn_SubMenuVendedor.ResumeLayout(false);
            this.pn_SubMenuGerente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pn_MenuSup;
        private FontAwesome.Sharp.IconButton btn_Sair;
        private System.Windows.Forms.Panel pnlConteudo;
        private FontAwesome.Sharp.IconButton icon_mod;
        private ReaLTaiizor.Controls.CyberProgressBar cyberProgressBar1;
        private FontAwesome.Sharp.IconButton btn_Layout;
        private System.Windows.Forms.Timer timerSidebar;
        private PanelSombreado pn_Principal;
        private System.Windows.Forms.Panel subMenuFinanceiro;
        private FontAwesome.Sharp.IconButton btn_Lucro;
        private FontAwesome.Sharp.IconButton btn_ContasPagar;
        private FontAwesome.Sharp.IconButton btn_SalarioFunc;
        private FontAwesome.Sharp.IconButton btn_SubMenuFinanceiro;
        private System.Windows.Forms.Panel pn_SubMenuEstoque;
        private FontAwesome.Sharp.IconButton btn_LançarNota;
        private FontAwesome.Sharp.IconButton btn_FazerPed;
        private FontAwesome.Sharp.IconButton btn_EstoqGeral;
        private FontAwesome.Sharp.IconButton btn_MenuEstoque;
        private System.Windows.Forms.Panel pn_SubMenuVendedor;
        private FontAwesome.Sharp.IconButton btn_Desemp;
        private FontAwesome.Sharp.IconButton btn_Vendedor;
        private FontAwesome.Sharp.IconButton btn_MenuVendas;
        private System.Windows.Forms.Panel pn_SubMenuGerente;
        private FontAwesome.Sharp.IconButton btn_Relatorio;
        private FontAwesome.Sharp.IconButton btn_CadForn;
        private FontAwesome.Sharp.IconButton btn_CadProd;
        private FontAwesome.Sharp.IconButton btn_CadFun;
        private FontAwesome.Sharp.IconButton btn_Monitoramento;
        private FontAwesome.Sharp.IconButton Btn_MenuGerente;
        private System.Windows.Forms.Panel pn_Logo;
    }
}