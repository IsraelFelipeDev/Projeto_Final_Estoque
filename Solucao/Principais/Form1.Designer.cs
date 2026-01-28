namespace Projeto_FinalOficial
{
    partial class Form1
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonBorderEdge1 = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.moonLabel2 = new ReaLTaiizor.Controls.MoonLabel();
            this.txt_Senha = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.moonLabel1 = new ReaLTaiizor.Controls.MoonLabel();
            this.txt_Login = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Crimson = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.eye_Icon = new FontAwesome.Sharp.IconButton();
            this.LOG = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonCustom3;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 686);
            this.kryptonBorderEdge1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(1371, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(41, 394);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(185, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 20;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 6;
            this.kryptonButton1.Values.Text = "Entrar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // moonLabel2
            // 
            this.moonLabel2.AutoSize = true;
            this.moonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moonLabel2.Location = new System.Drawing.Point(4, 269);
            this.moonLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel2.Name = "moonLabel2";
            this.moonLabel2.Size = new System.Drawing.Size(46, 16);
            this.moonLabel2.TabIndex = 4;
            this.moonLabel2.Text = "Senha";
            // 
            // txt_Senha
            // 
            this.txt_Senha.Location = new System.Drawing.Point(8, 290);
            this.txt_Senha.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Senha.Name = "txt_Senha";
            this.txt_Senha.Size = new System.Drawing.Size(203, 31);
            this.txt_Senha.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_Senha.StateCommon.Border.Rounding = 5;
            this.txt_Senha.TabIndex = 5;
            // 
            // moonLabel1
            // 
            this.moonLabel1.AutoSize = true;
            this.moonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moonLabel1.Location = new System.Drawing.Point(4, 199);
            this.moonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moonLabel1.Name = "moonLabel1";
            this.moonLabel1.Size = new System.Drawing.Size(82, 16);
            this.moonLabel1.TabIndex = 1;
            this.moonLabel1.Text = "Login/E-mail";
            // 
            // txt_Login
            // 
            this.txt_Login.Location = new System.Drawing.Point(8, 217);
            this.txt_Login.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Login.Name = "txt_Login";
            this.txt_Login.Size = new System.Drawing.Size(203, 31);
            this.txt_Login.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_Login.StateCommon.Border.Rounding = 5;
            this.txt_Login.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.label1.Location = new System.Drawing.Point(317, 289);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 62);
            this.label1.TabIndex = 11;
            this.label1.Text = "S U I T";
            // 
            // Crimson
            // 
            this.Crimson.AutoSize = true;
            this.Crimson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Crimson.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crimson.ForeColor = System.Drawing.Color.Black;
            this.Crimson.Location = new System.Drawing.Point(291, 228);
            this.Crimson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Crimson.Name = "Crimson";
            this.Crimson.Size = new System.Drawing.Size(234, 64);
            this.Crimson.TabIndex = 10;
            this.Crimson.Text = "Crimson";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 210);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(273, 164);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pictureBox3.Location = new System.Drawing.Point(85, 210);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(455, 164);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.pictureBox4.Location = new System.Drawing.Point(57, 198);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(460, 190);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.panel2.Controls.Add(this.eye_Icon);
            this.panel2.Controls.Add(this.moonLabel2);
            this.panel2.Controls.Add(this.kryptonButton1);
            this.panel2.Controls.Add(this.txt_Senha);
            this.panel2.Controls.Add(this.LOG);
            this.panel2.Controls.Add(this.moonLabel1);
            this.panel2.Controls.Add(this.txt_Login);
            this.panel2.Location = new System.Drawing.Point(1086, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 865);
            this.panel2.TabIndex = 15;
            // 
            // eye_Icon
            // 
            this.eye_Icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.eye_Icon.FlatAppearance.BorderSize = 0;
            this.eye_Icon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eye_Icon.ForeColor = System.Drawing.Color.Transparent;
            this.eye_Icon.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.eye_Icon.IconColor = System.Drawing.Color.Black;
            this.eye_Icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.eye_Icon.IconSize = 28;
            this.eye_Icon.Location = new System.Drawing.Point(218, 290);
            this.eye_Icon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eye_Icon.Name = "eye_Icon";
            this.eye_Icon.Size = new System.Drawing.Size(49, 33);
            this.eye_Icon.TabIndex = 13;
            this.eye_Icon.UseVisualStyleBackColor = false;
            this.eye_Icon.Click += new System.EventHandler(this.eye_Icon_Click);
            // 
            // LOG
            // 
            this.LOG.AutoSize = true;
            this.LOG.Dock = System.Windows.Forms.DockStyle.Left;
            this.LOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOG.Location = new System.Drawing.Point(0, 0);
            this.LOG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LOG.Name = "LOG";
            this.LOG.Size = new System.Drawing.Size(143, 46);
            this.LOG.TabIndex = 7;
            this.LOG.Text = "LOGIN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.pictureBox1.Location = new System.Drawing.Point(1489, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 889);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1371, 687);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Crimson);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.kryptonBorderEdge1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1021, 724);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Login;
        private ReaLTaiizor.Controls.MoonLabel moonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ReaLTaiizor.Controls.MoonLabel moonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Senha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Crimson;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LOG;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton eye_Icon;
    }
}

