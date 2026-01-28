namespace Projeto_FinalOficial.UserControls
{
    partial class UC_ContasAPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ContasAPagar));
            this.pn_GridConta = new PanelSombreado();
            this.rb_AVencer = new ReaLTaiizor.Controls.RadioButton();
            this.rb_Pagas = new ReaLTaiizor.Controls.RadioButton();
            this.rb_Hoje = new ReaLTaiizor.Controls.RadioButton();
            this.rb_Atrasadas = new ReaLTaiizor.Controls.RadioButton();
            this.rb_Todos = new ReaLTaiizor.Controls.RadioButton();
            this.pn_CadastroContas = new PanelSombreado();
            this.btn_Cancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_LimparDadosCP = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_CadastarConta = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_FornecedorAvulso = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txt_Valor = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtp_DataVencimento = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_FornecedorCad = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.chk_Cadastrados = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chk_Avulsos = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_Categoria = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelSombreado3 = new PanelSombreado();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Observação = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDescricao = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btn_AdicionarRegistro = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvContas = new System.Windows.Forms.DataGridView();
            this.pn_Lateral = new PanelSombreado();
            this.pn_ResumoContas = new PanelSombreado();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalQtd = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblValorPagas = new System.Windows.Forms.Label();
            this.lblQtdPagas = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblValorHoje = new System.Windows.Forms.Label();
            this.lblQtdHoje = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblValorAVencer = new System.Windows.Forms.Label();
            this.lblQtdAVencer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValorAtrasadas = new System.Windows.Forms.Label();
            this.lblQtdAtrasadas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pn_Cabeçalho = new PanelSombreado();
            this.label18 = new System.Windows.Forms.Label();
            this.pn_GridConta.SuspendLayout();
            this.pn_CadastroContas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_FornecedorCad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Categoria)).BeginInit();
            this.panelSombreado3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.pn_Lateral.SuspendLayout();
            this.pn_ResumoContas.SuspendLayout();
            this.pn_Cabeçalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_GridConta
            // 
            this.pn_GridConta.BackColor = System.Drawing.Color.Gainsboro;
            this.pn_GridConta.Controls.Add(this.rb_AVencer);
            this.pn_GridConta.Controls.Add(this.rb_Pagas);
            this.pn_GridConta.Controls.Add(this.rb_Hoje);
            this.pn_GridConta.Controls.Add(this.rb_Atrasadas);
            this.pn_GridConta.Controls.Add(this.rb_Todos);
            this.pn_GridConta.Controls.Add(this.pn_CadastroContas);
            this.pn_GridConta.Controls.Add(this.btn_AdicionarRegistro);
            this.pn_GridConta.Controls.Add(this.dgvContas);
            this.pn_GridConta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_GridConta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pn_GridConta.Location = new System.Drawing.Point(247, 59);
            this.pn_GridConta.Margin = new System.Windows.Forms.Padding(25);
            this.pn_GridConta.Name = "pn_GridConta";
            this.pn_GridConta.Padding = new System.Windows.Forms.Padding(12);
            this.pn_GridConta.Size = new System.Drawing.Size(1006, 839);
            this.pn_GridConta.TabIndex = 2;
            // 
            // rb_AVencer
            // 
            this.rb_AVencer.Checked = false;
            this.rb_AVencer.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.rb_AVencer.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(85)))));
            this.rb_AVencer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_AVencer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.rb_AVencer.Location = new System.Drawing.Point(158, 48);
            this.rb_AVencer.Name = "rb_AVencer";
            this.rb_AVencer.Size = new System.Drawing.Size(120, 17);
            this.rb_AVencer.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rb_AVencer.TabIndex = 12;
            this.rb_AVencer.Text = "À Vencer";
            this.rb_AVencer.CheckedChanged += new ReaLTaiizor.Controls.RadioButton.CheckedChangedEventHandler(this.rb_AVencer_CheckedChanged);
            // 
            // rb_Pagas
            // 
            this.rb_Pagas.Checked = false;
            this.rb_Pagas.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.rb_Pagas.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(85)))));
            this.rb_Pagas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Pagas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.rb_Pagas.Location = new System.Drawing.Point(760, 48);
            this.rb_Pagas.Name = "rb_Pagas";
            this.rb_Pagas.Size = new System.Drawing.Size(120, 17);
            this.rb_Pagas.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rb_Pagas.TabIndex = 11;
            this.rb_Pagas.Text = "Pagas";
            this.rb_Pagas.CheckedChanged += new ReaLTaiizor.Controls.RadioButton.CheckedChangedEventHandler(this.rb_Pagas_CheckedChanged);
            // 
            // rb_Hoje
            // 
            this.rb_Hoje.Checked = false;
            this.rb_Hoje.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.rb_Hoje.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(85)))));
            this.rb_Hoje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Hoje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.rb_Hoje.Location = new System.Drawing.Point(610, 48);
            this.rb_Hoje.Name = "rb_Hoje";
            this.rb_Hoje.Size = new System.Drawing.Size(120, 17);
            this.rb_Hoje.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rb_Hoje.TabIndex = 10;
            this.rb_Hoje.Text = "Vence Hoje";
            this.rb_Hoje.CheckedChanged += new ReaLTaiizor.Controls.RadioButton.CheckedChangedEventHandler(this.rb_Hoje_CheckedChanged);
            // 
            // rb_Atrasadas
            // 
            this.rb_Atrasadas.Checked = false;
            this.rb_Atrasadas.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.rb_Atrasadas.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(85)))));
            this.rb_Atrasadas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Atrasadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.rb_Atrasadas.Location = new System.Drawing.Point(457, 48);
            this.rb_Atrasadas.Name = "rb_Atrasadas";
            this.rb_Atrasadas.Size = new System.Drawing.Size(120, 17);
            this.rb_Atrasadas.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rb_Atrasadas.TabIndex = 9;
            this.rb_Atrasadas.Text = "Atrasadas";
            this.rb_Atrasadas.CheckedChanged += new ReaLTaiizor.Controls.RadioButton.CheckedChangedEventHandler(this.rb_Atrasadas_CheckedChanged);
            // 
            // rb_Todos
            // 
            this.rb_Todos.Checked = false;
            this.rb_Todos.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.rb_Todos.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(85)))));
            this.rb_Todos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Todos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.rb_Todos.Location = new System.Drawing.Point(311, 45);
            this.rb_Todos.Name = "rb_Todos";
            this.rb_Todos.Size = new System.Drawing.Size(120, 17);
            this.rb_Todos.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.rb_Todos.TabIndex = 8;
            this.rb_Todos.Text = "Todos ";
            this.rb_Todos.CheckedChanged += new ReaLTaiizor.Controls.RadioButton.CheckedChangedEventHandler(this.rb_Todos_CheckedChanged);
            // 
            // pn_CadastroContas
            // 
            this.pn_CadastroContas.BackColor = System.Drawing.Color.White;
            this.pn_CadastroContas.Controls.Add(this.btn_Cancelar);
            this.pn_CadastroContas.Controls.Add(this.btn_LimparDadosCP);
            this.pn_CadastroContas.Controls.Add(this.btn_CadastarConta);
            this.pn_CadastroContas.Controls.Add(this.label5);
            this.pn_CadastroContas.Controls.Add(this.txt_FornecedorAvulso);
            this.pn_CadastroContas.Controls.Add(this.txt_Valor);
            this.pn_CadastroContas.Controls.Add(this.dtp_DataVencimento);
            this.pn_CadastroContas.Controls.Add(this.label14);
            this.pn_CadastroContas.Controls.Add(this.label13);
            this.pn_CadastroContas.Controls.Add(this.cmb_FornecedorCad);
            this.pn_CadastroContas.Controls.Add(this.chk_Cadastrados);
            this.pn_CadastroContas.Controls.Add(this.chk_Avulsos);
            this.pn_CadastroContas.Controls.Add(this.label11);
            this.pn_CadastroContas.Controls.Add(this.cmb_Categoria);
            this.pn_CadastroContas.Controls.Add(this.label10);
            this.pn_CadastroContas.Controls.Add(this.panelSombreado3);
            this.pn_CadastroContas.Controls.Add(this.label4);
            this.pn_CadastroContas.Controls.Add(this.txt_Observação);
            this.pn_CadastroContas.Controls.Add(this.txtDescricao);
            this.pn_CadastroContas.Location = new System.Drawing.Point(544, 513);
            this.pn_CadastroContas.Margin = new System.Windows.Forms.Padding(20);
            this.pn_CadastroContas.Name = "pn_CadastroContas";
            this.pn_CadastroContas.Padding = new System.Windows.Forms.Padding(12);
            this.pn_CadastroContas.Size = new System.Drawing.Size(450, 314);
            this.pn_CadastroContas.TabIndex = 7;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(44, 675);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(158, 38);
            this.btn_Cancelar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_Cancelar.StateCommon.Border.Rounding = 5;
            this.btn_Cancelar.TabIndex = 24;
            this.btn_Cancelar.Values.Text = "Cancelar";
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click_1);
            // 
            // btn_LimparDadosCP
            // 
            this.btn_LimparDadosCP.Location = new System.Drawing.Point(452, 675);
            this.btn_LimparDadosCP.Name = "btn_LimparDadosCP";
            this.btn_LimparDadosCP.Size = new System.Drawing.Size(158, 38);
            this.btn_LimparDadosCP.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_LimparDadosCP.StateCommon.Border.Rounding = 5;
            this.btn_LimparDadosCP.TabIndex = 23;
            this.btn_LimparDadosCP.Values.Text = "Limpar";
            this.btn_LimparDadosCP.Click += new System.EventHandler(this.btn_LimparDadosCP_Click);
            // 
            // btn_CadastarConta
            // 
            this.btn_CadastarConta.Location = new System.Drawing.Point(648, 675);
            this.btn_CadastarConta.Name = "btn_CadastarConta";
            this.btn_CadastarConta.Size = new System.Drawing.Size(158, 38);
            this.btn_CadastarConta.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_CadastarConta.StateCommon.Border.Rounding = 5;
            this.btn_CadastarConta.TabIndex = 22;
            this.btn_CadastarConta.Values.Text = "Cadastar";
            this.btn_CadastarConta.Click += new System.EventHandler(this.btn_CadastarConta_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Observação";
            // 
            // txt_FornecedorAvulso
            // 
            this.txt_FornecedorAvulso.Location = new System.Drawing.Point(233, 260);
            this.txt_FornecedorAvulso.Name = "txt_FornecedorAvulso";
            this.txt_FornecedorAvulso.Size = new System.Drawing.Size(223, 34);
            this.txt_FornecedorAvulso.StateActive.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FornecedorAvulso.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_FornecedorAvulso.StateCommon.Border.Rounding = 5;
            this.txt_FornecedorAvulso.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FornecedorAvulso.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_FornecedorAvulso.StateDisabled.Border.Rounding = 5;
            this.txt_FornecedorAvulso.StateDisabled.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FornecedorAvulso.StateNormal.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FornecedorAvulso.TabIndex = 19;
            // 
            // txt_Valor
            // 
            this.txt_Valor.Location = new System.Drawing.Point(233, 341);
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(223, 34);
            this.txt_Valor.StateActive.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Valor.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_Valor.StateCommon.Border.Rounding = 5;
            this.txt_Valor.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Valor.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_Valor.StateDisabled.Border.Rounding = 5;
            this.txt_Valor.StateDisabled.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Valor.StateNormal.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Valor.TabIndex = 18;
            // 
            // dtp_DataVencimento
            // 
            this.dtp_DataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DataVencimento.Location = new System.Drawing.Point(501, 341);
            this.dtp_DataVencimento.Name = "dtp_DataVencimento";
            this.dtp_DataVencimento.Size = new System.Drawing.Size(255, 32);
            this.dtp_DataVencimento.StateActive.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DataVencimento.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtp_DataVencimento.StateCommon.Border.Rounding = 5;
            this.dtp_DataVencimento.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DataVencimento.StateDisabled.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DataVencimento.StateNormal.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DataVencimento.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(510, 311);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 25);
            this.label14.TabIndex = 16;
            this.label14.Text = "Vencimento";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(284, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 25);
            this.label13.TabIndex = 15;
            this.label13.Text = "Valor (R$)";
            // 
            // cmb_FornecedorCad
            // 
            this.cmb_FornecedorCad.DropDownWidth = 359;
            this.cmb_FornecedorCad.Location = new System.Drawing.Point(501, 260);
            this.cmb_FornecedorCad.Name = "cmb_FornecedorCad";
            this.cmb_FornecedorCad.Size = new System.Drawing.Size(255, 32);
            this.cmb_FornecedorCad.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmb_FornecedorCad.StateCommon.ComboBox.Border.Rounding = 5;
            this.cmb_FornecedorCad.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_FornecedorCad.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_FornecedorCad.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_FornecedorCad.TabIndex = 13;
            // 
            // chk_Cadastrados
            // 
            this.chk_Cadastrados.Location = new System.Drawing.Point(542, 230);
            this.chk_Cadastrados.Name = "chk_Cadastrados";
            this.chk_Cadastrados.Size = new System.Drawing.Size(113, 24);
            this.chk_Cadastrados.StateCommon.AdjacentGap = 5;
            this.chk_Cadastrados.TabIndex = 12;
            this.chk_Cadastrados.Values.Text = " Cadastrados";
            // 
            // chk_Avulsos
            // 
            this.chk_Avulsos.Location = new System.Drawing.Point(289, 232);
            this.chk_Avulsos.Name = "chk_Avulsos";
            this.chk_Avulsos.Size = new System.Drawing.Size(123, 24);
            this.chk_Avulsos.TabIndex = 11;
            this.chk_Avulsos.Values.Text = "Avulso/Outros";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Tipo de Fornecedor";
            // 
            // cmb_Categoria
            // 
            this.cmb_Categoria.DropDownWidth = 359;
            this.cmb_Categoria.Location = new System.Drawing.Point(30, 182);
            this.cmb_Categoria.Name = "cmb_Categoria";
            this.cmb_Categoria.Size = new System.Drawing.Size(363, 32);
            this.cmb_Categoria.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Categoria.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmb_Categoria.StateCommon.ComboBox.Border.Rounding = 5;
            this.cmb_Categoria.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Categoria.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Categoria.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Categoria.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Categoria.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Descrição";
            // 
            // panelSombreado3
            // 
            this.panelSombreado3.BackColor = System.Drawing.Color.White;
            this.panelSombreado3.Controls.Add(this.label8);
            this.panelSombreado3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSombreado3.Location = new System.Drawing.Point(12, 12);
            this.panelSombreado3.Name = "panelSombreado3";
            this.panelSombreado3.Padding = new System.Windows.Forms.Padding(8);
            this.panelSombreado3.Size = new System.Drawing.Size(426, 65);
            this.panelSombreado3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 38);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cadastro de Contas ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descrição";
            // 
            // txt_Observação
            // 
            this.txt_Observação.Location = new System.Drawing.Point(30, 483);
            this.txt_Observação.Multiline = true;
            this.txt_Observação.Name = "txt_Observação";
            this.txt_Observação.Size = new System.Drawing.Size(745, 125);
            this.txt_Observação.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_Observação.StateCommon.Border.Rounding = 10;
            this.txt_Observação.TabIndex = 2;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(27, 106);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(366, 34);
            this.txtDescricao.StateActive.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDescricao.StateCommon.Border.Rounding = 5;
            this.txtDescricao.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDescricao.StateDisabled.Border.Rounding = 5;
            this.txtDescricao.StateDisabled.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.StateNormal.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.TabIndex = 0;
            // 
            // btn_AdicionarRegistro
            // 
            this.btn_AdicionarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AdicionarRegistro.Location = new System.Drawing.Point(944, 37);
            this.btn_AdicionarRegistro.Name = "btn_AdicionarRegistro";
            this.btn_AdicionarRegistro.Size = new System.Drawing.Size(22, 25);
            this.btn_AdicionarRegistro.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.btn_AdicionarRegistro.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.btn_AdicionarRegistro.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_AdicionarRegistro.StateCommon.Back.Image")));
            this.btn_AdicionarRegistro.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btn_AdicionarRegistro.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AdicionarRegistro.StateCommon.Border.Rounding = 70;
            this.btn_AdicionarRegistro.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.btn_AdicionarRegistro.StateNormal.Back.Color2 = System.Drawing.Color.Transparent;
            this.btn_AdicionarRegistro.StateNormal.Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_AdicionarRegistro.StateNormal.Back.Image")));
            this.btn_AdicionarRegistro.StateNormal.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btn_AdicionarRegistro.StateNormal.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.btn_AdicionarRegistro.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AdicionarRegistro.StateNormal.Border.Rounding = 70;
            this.btn_AdicionarRegistro.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_AdicionarRegistro.StatePressed.Border.Image = ((System.Drawing.Image)(resources.GetObject("btn_AdicionarRegistro.StatePressed.Border.Image")));
            this.btn_AdicionarRegistro.StatePressed.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.BottomMiddle;
            this.btn_AdicionarRegistro.StatePressed.Border.Rounding = 70;
            this.btn_AdicionarRegistro.TabIndex = 2;
            this.btn_AdicionarRegistro.Values.Text = "";
            this.btn_AdicionarRegistro.Click += new System.EventHandler(this.btn_AdicionarRegistro_1);
            // 
            // dgvContas
            // 
            this.dgvContas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.Location = new System.Drawing.Point(23, 71);
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.RowHeadersWidth = 51;
            this.dgvContas.RowTemplate.Height = 24;
            this.dgvContas.Size = new System.Drawing.Size(959, 642);
            this.dgvContas.TabIndex = 0;
            // 
            // pn_Lateral
            // 
            this.pn_Lateral.BackColor = System.Drawing.Color.Gainsboro;
            this.pn_Lateral.Controls.Add(this.pn_ResumoContas);
            this.pn_Lateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_Lateral.Location = new System.Drawing.Point(0, 59);
            this.pn_Lateral.Name = "pn_Lateral";
            this.pn_Lateral.Padding = new System.Windows.Forms.Padding(7);
            this.pn_Lateral.Size = new System.Drawing.Size(247, 839);
            this.pn_Lateral.TabIndex = 1;
            // 
            // pn_ResumoContas
            // 
            this.pn_ResumoContas.BackColor = System.Drawing.Color.White;
            this.pn_ResumoContas.Controls.Add(this.lblTotalValor);
            this.pn_ResumoContas.Controls.Add(this.lblTotalQtd);
            this.pn_ResumoContas.Controls.Add(this.label15);
            this.pn_ResumoContas.Controls.Add(this.lblValorPagas);
            this.pn_ResumoContas.Controls.Add(this.lblQtdPagas);
            this.pn_ResumoContas.Controls.Add(this.label12);
            this.pn_ResumoContas.Controls.Add(this.lblValorHoje);
            this.pn_ResumoContas.Controls.Add(this.lblQtdHoje);
            this.pn_ResumoContas.Controls.Add(this.label9);
            this.pn_ResumoContas.Controls.Add(this.lblValorAVencer);
            this.pn_ResumoContas.Controls.Add(this.lblQtdAVencer);
            this.pn_ResumoContas.Controls.Add(this.label6);
            this.pn_ResumoContas.Controls.Add(this.lblValorAtrasadas);
            this.pn_ResumoContas.Controls.Add(this.lblQtdAtrasadas);
            this.pn_ResumoContas.Controls.Add(this.label3);
            this.pn_ResumoContas.Controls.Add(this.label2);
            this.pn_ResumoContas.Controls.Add(this.label1);
            this.pn_ResumoContas.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_ResumoContas.Location = new System.Drawing.Point(7, 7);
            this.pn_ResumoContas.Name = "pn_ResumoContas";
            this.pn_ResumoContas.Padding = new System.Windows.Forms.Padding(8);
            this.pn_ResumoContas.Size = new System.Drawing.Size(257, 825);
            this.pn_ResumoContas.TabIndex = 0;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValor.Location = new System.Drawing.Point(90, 426);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(20, 25);
            this.lblTotalValor.TabIndex = 16;
            this.lblTotalValor.Text = "-";
            // 
            // lblTotalQtd
            // 
            this.lblTotalQtd.AutoSize = true;
            this.lblTotalQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQtd.Location = new System.Drawing.Point(186, 394);
            this.lblTotalQtd.Name = "lblTotalQtd";
            this.lblTotalQtd.Size = new System.Drawing.Size(14, 18);
            this.lblTotalQtd.TabIndex = 15;
            this.lblTotalQtd.Text = "-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 394);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "Total";
            // 
            // lblValorPagas
            // 
            this.lblValorPagas.AutoSize = true;
            this.lblValorPagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPagas.Location = new System.Drawing.Point(119, 359);
            this.lblValorPagas.Name = "lblValorPagas";
            this.lblValorPagas.Size = new System.Drawing.Size(14, 18);
            this.lblValorPagas.TabIndex = 13;
            this.lblValorPagas.Text = "-";
            // 
            // lblQtdPagas
            // 
            this.lblQtdPagas.AutoSize = true;
            this.lblQtdPagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdPagas.Location = new System.Drawing.Point(186, 306);
            this.lblQtdPagas.Name = "lblQtdPagas";
            this.lblQtdPagas.Size = new System.Drawing.Size(14, 18);
            this.lblQtdPagas.TabIndex = 12;
            this.lblQtdPagas.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label12.Location = new System.Drawing.Point(14, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(186, 24);
            this.label12.TabIndex = 11;
            this.label12.Text = "______________________";
            // 
            // lblValorHoje
            // 
            this.lblValorHoje.AutoSize = true;
            this.lblValorHoje.BackColor = System.Drawing.Color.White;
            this.lblValorHoje.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorHoje.ForeColor = System.Drawing.Color.Gold;
            this.lblValorHoje.Location = new System.Drawing.Point(118, 266);
            this.lblValorHoje.Name = "lblValorHoje";
            this.lblValorHoje.Size = new System.Drawing.Size(17, 23);
            this.lblValorHoje.TabIndex = 10;
            this.lblValorHoje.Text = "-";
            // 
            // lblQtdHoje
            // 
            this.lblQtdHoje.AutoSize = true;
            this.lblQtdHoje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdHoje.Location = new System.Drawing.Point(186, 223);
            this.lblQtdHoje.Name = "lblQtdHoje";
            this.lblQtdHoje.Size = new System.Drawing.Size(14, 18);
            this.lblQtdHoje.TabIndex = 9;
            this.lblQtdHoje.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Vence Hoje";
            // 
            // lblValorAVencer
            // 
            this.lblValorAVencer.AutoSize = true;
            this.lblValorAVencer.BackColor = System.Drawing.Color.White;
            this.lblValorAVencer.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAVencer.ForeColor = System.Drawing.Color.Lime;
            this.lblValorAVencer.Location = new System.Drawing.Point(118, 180);
            this.lblValorAVencer.Name = "lblValorAVencer";
            this.lblValorAVencer.Size = new System.Drawing.Size(17, 23);
            this.lblValorAVencer.TabIndex = 7;
            this.lblValorAVencer.Text = "-";
            // 
            // lblQtdAVencer
            // 
            this.lblQtdAVencer.AutoSize = true;
            this.lblQtdAVencer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdAVencer.Location = new System.Drawing.Point(186, 137);
            this.lblQtdAVencer.Name = "lblQtdAVencer";
            this.lblQtdAVencer.Size = new System.Drawing.Size(14, 18);
            this.lblQtdAVencer.TabIndex = 6;
            this.lblQtdAVencer.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "À Vencer";
            // 
            // lblValorAtrasadas
            // 
            this.lblValorAtrasadas.AutoSize = true;
            this.lblValorAtrasadas.BackColor = System.Drawing.Color.White;
            this.lblValorAtrasadas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAtrasadas.ForeColor = System.Drawing.Color.Red;
            this.lblValorAtrasadas.Location = new System.Drawing.Point(118, 100);
            this.lblValorAtrasadas.Name = "lblValorAtrasadas";
            this.lblValorAtrasadas.Size = new System.Drawing.Size(17, 23);
            this.lblValorAtrasadas.TabIndex = 4;
            this.lblValorAtrasadas.Text = "-";
            // 
            // lblQtdAtrasadas
            // 
            this.lblQtdAtrasadas.AutoSize = true;
            this.lblQtdAtrasadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdAtrasadas.Location = new System.Drawing.Point(186, 64);
            this.lblQtdAtrasadas.Name = "lblQtdAtrasadas";
            this.lblQtdAtrasadas.Size = new System.Drawing.Size(14, 18);
            this.lblQtdAtrasadas.TabIndex = 3;
            this.lblQtdAtrasadas.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pagas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Atrasadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resumo de Contas";
            // 
            // pn_Cabeçalho
            // 
            this.pn_Cabeçalho.BackColor = System.Drawing.Color.White;
            this.pn_Cabeçalho.Controls.Add(this.label18);
            this.pn_Cabeçalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Cabeçalho.Location = new System.Drawing.Point(0, 0);
            this.pn_Cabeçalho.Name = "pn_Cabeçalho";
            this.pn_Cabeçalho.Padding = new System.Windows.Forms.Padding(5);
            this.pn_Cabeçalho.Size = new System.Drawing.Size(1253, 59);
            this.pn_Cabeçalho.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(31, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 23);
            this.label18.TabIndex = 17;
            this.label18.Text = "Contas à Pagar";
            // 
            // UC_ContasAPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_GridConta);
            this.Controls.Add(this.pn_Lateral);
            this.Controls.Add(this.pn_Cabeçalho);
            this.Name = "UC_ContasAPagar";
            this.Size = new System.Drawing.Size(1253, 898);
            this.Load += new System.EventHandler(this.UC_ContasAPagar_Load);
            this.pn_GridConta.ResumeLayout(false);
            this.pn_CadastroContas.ResumeLayout(false);
            this.pn_CadastroContas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_FornecedorCad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Categoria)).EndInit();
            this.panelSombreado3.ResumeLayout(false);
            this.panelSombreado3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.pn_Lateral.ResumeLayout(false);
            this.pn_ResumoContas.ResumeLayout(false);
            this.pn_ResumoContas.PerformLayout();
            this.pn_Cabeçalho.ResumeLayout(false);
            this.pn_Cabeçalho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelSombreado pn_Cabeçalho;
        private PanelSombreado pn_GridConta;
        private PanelSombreado pn_ResumoContas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblValorAVencer;
        private System.Windows.Forms.Label lblQtdAVencer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblValorAtrasadas;
        private System.Windows.Forms.Label lblQtdAtrasadas;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblValorPagas;
        private System.Windows.Forms.Label lblQtdPagas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblValorHoje;
        private System.Windows.Forms.Label lblQtdHoje;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblTotalQtd;
        private System.Windows.Forms.DataGridView dgvContas;
        private System.Windows.Forms.Label label18;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_AdicionarRegistro;
        private PanelSombreado pn_CadastroContas;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Observação;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDescricao;
        private PanelSombreado panelSombreado3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_Categoria;
        private System.Windows.Forms.Label label10;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtp_DataVencimento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_FornecedorCad;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_Cadastrados;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_Avulsos;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_FornecedorAvulso;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Valor;
        private System.Windows.Forms.Label label5;
        private PanelSombreado pn_Lateral;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Cancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_LimparDadosCP;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_CadastarConta;
        private ReaLTaiizor.Controls.RadioButton rb_Pagas;
        private ReaLTaiizor.Controls.RadioButton rb_Hoje;
        private ReaLTaiizor.Controls.RadioButton rb_Atrasadas;
        private ReaLTaiizor.Controls.RadioButton rb_Todos;
        private ReaLTaiizor.Controls.RadioButton rb_AVencer;
    }
}
