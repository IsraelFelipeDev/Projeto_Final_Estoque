using Projeto_FinalOficial.Modelos;
using Projeto_FinalOficial.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static  Projeto_FinalOficial.Modelos.Venda;

namespace Projeto_FinalOficial
{
    public partial class UC_Pagamento : UserControl
    {
        // Variáveis de Estado
        private decimal _valorTotalVenda;
        private List<ItemVenda> _itensDaVenda;
        private decimal _valorPendente;
        private Cliente _clienteDaVenda = null;

        // LISTA PARA GUARDAR OS PAGAMENTOS ANTES DE SALVAR NO BANCO
        // (Ex: R$ 50 Pix + R$ 30 Dinheiro)
        private List<Projeto_FinalOficial.Modelos.Venda.PagamentoVenda> _pagamentosRealizados =
    new List<Projeto_FinalOficial.Modelos.Venda.PagamentoVenda>();

        public UC_Pagamento()
        {
            InitializeComponent();
        }

        public UC_Pagamento(decimal total, List<ItemVenda> itens,Cliente clienteSelecionado)
        {
            InitializeComponent();
            _valorTotalVenda = total;
            _itensDaVenda = itens;
            _clienteDaVenda = clienteSelecionado;
        }

        private void UC_Pagamento_Load(object sender, EventArgs e)
        {
            // Proteção para garantir valores iniciais
            if (_valorPendente <= 0 && _valorTotalVenda > 0)
            {
                _valorPendente = _valorTotalVenda;
            }

            lbl_ValorCompra.Text = _valorTotalVenda.ToString("C2");
            lbl_ValorPendente.Text = _valorPendente.ToString("C2");

            // Limpa lista de pagamentos anteriores se houver reload
            _pagamentosRealizados.Clear();
        }

        // ----------------------------------------------------------------------
        // 1. MÉTODO CENTRAL QUE REGISTRA QUALQUER PAGAMENTO (Clean Code)
        // ----------------------------------------------------------------------
        private void RegistrarPagamentoNaMemoria(string formaPagamento, decimal valorPago)
        {
            if (valorPago <= 0) return;

            // 1. Atualiza o valor pendente (Visual)
            _valorPendente -= valorPago;

            // Evita números negativos (Ex: -0.01 por arredondamento)
            if (_valorPendente < 0) _valorPendente = 0;

            lbl_ValorPendente.Text = _valorPendente.ToString("C2");

            // 2. Adiciona na lista para salvar no banco depois
            var novoPagamento = new Venda.PagamentoVenda
            {
            TipoPagamento = formaPagamento,
             Valor = valorPago
};
            _pagamentosRealizados.Add(novoPagamento);

            // 3. Feedback visual
            if (_valorPendente == 0)
            {
                lbl_ValorPendente.ForeColor = Color.Green;
                MessageBox.Show($"Pagamento de {valorPago:C2} recebido via {formaPagamento}.\nTotal quitado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Recebido: {valorPago:C2} ({formaPagamento})\nFalta: {_valorPendente:C2}", "Pagamento Parcial");
            }
        }

        // ----------------------------------------------------------------------
        // 2. EVENTOS DE CLIQUE (PICTURE BOX)
        // ----------------------------------------------------------------------

        private void pic_Pix_Click(object sender, EventArgs e)
        {
            if (_valorPendente <= 0) return;

            // Pergunta simples para confirmar pagamento total no Pix
            var confirm = MessageBox.Show($"Deseja pagar o restante ({_valorPendente:C2}) no PIX?",
                                          "Pagamento Pix", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Manda registrar o valor total restante como Pix
                RegistrarPagamentoNaMemoria("Pix", _valorPendente);
            }
        }

        private void pic_Dinheiro_Click(object sender, EventArgs e)
        {
            if (_valorPendente <= 0) return;

            // Lógica simples: Considera que pagou o restante em dinheiro
            // (Futuramente você pode por um InputBox aqui para calcular troco)
            var confirm = MessageBox.Show($"Deseja confirmar o pagamento de {_valorPendente:C2} em DINHEIRO?",
                                          "Pagamento Dinheiro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                RegistrarPagamentoNaMemoria("Dinheiro", _valorPendente);
            }
        }

        private void pic_cartão_Click(object sender, EventArgs e)
        {
            if (_valorPendente <= 0)
            {
                MessageBox.Show("O pagamento já foi concluído.");
                return;
            }

            // Captura o valor antes de abrir o popup para saber quanto foi pago
            decimal valorAntesDoPopup = _valorPendente;

            var ucCartao = new UC_Cartão();
            // Supondo que você criou a propriedade publica TipoPagamentoSelecionado no UC_Cartão

            using (Form popupForm = new Form())
            {
                ucCartao.ValorTotalPendente = this._valorPendente;

                popupForm.FormBorderStyle = FormBorderStyle.None;
                popupForm.StartPosition = FormStartPosition.CenterParent;
                popupForm.AutoSize = true;
                popupForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                popupForm.Controls.Add(ucCartao);
                ucCartao.Location = new Point(0, 0);

                DialogResult resultado = popupForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // O UC_Cartao devolve o quanto SOBROU a pagar.
                    // Então: ValorPago = ValorQueTinha - ValorQueSobrou
                    decimal novoPendente = ucCartao.ValorRestante;
                    decimal valorPagoAgora = valorAntesDoPopup - novoPendente;

                    // Pega o tipo que veio do UC_Cartão (Ex: "Cartão Crédito" ou "Cartão Débito")
                    // Você precisa ter criado essa propriedade pública lá no UC_Cartao
                    string tipoEscolhido = ucCartao.TipoPagamentoSelecionado;

                    if (string.IsNullOrEmpty(tipoEscolhido)) tipoEscolhido = "Cartão"; // Fallback

                    // Usa nossa função central
                    RegistrarPagamentoNaMemoria(tipoEscolhido, valorPagoAgora);
                }
            }
        }

        // ----------------------------------------------------------------------
        // 3. FINALIZAR VENDA (SALVAR NO BANCO)
        // ----------------------------------------------------------------------
        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            // Validação: Só finaliza se pagou tudo!
            if (_valorPendente > 0)
            {
                MessageBox.Show($"Ainda falta receber {_valorPendente:C2} para fechar a venda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Sessao.ID <= 0 || Sessao.IDCaixaAtual <= 0)
            {
                MessageBox.Show("Erro de Sessão ou Caixa Fechado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Venda novaVenda = new Venda();
                novaVenda.IdUsuario = Sessao.ID;
                novaVenda.IdFluxoCaixa = Sessao.IDCaixaAtual;
                novaVenda.ValorTotal = _valorTotalVenda;
                novaVenda.DataVenda = DateTime.Now;
                novaVenda.Itens = _itensDaVenda;
                // --- CORREÇÃO 2 e 3: Usando os nomes corretos das propriedades (Maiúscula) ---
                if (_clienteDaVenda != null)
                {
                    // Usar IdCliente (Maiúsculo)
                    novaVenda.IdCliente = _clienteDaVenda.Id;

                    // Usar Cliente (Maiúsculo)
                    novaVenda.Cliente = _clienteDaVenda;
                }

                // *** IMPORTANTE ***
                // Passamos a lista de pagamentos (Pix, Dinheiro, etc) para a Venda
                // Você precisará adicionar: public List<PagamentoVenda> Pagamentos { get; set; } na sua classe Venda
                novaVenda.Pagamentos = _pagamentosRealizados;

                if (novaVenda.RealizarVendaCompleta())
                {
                    DialogResult resposta = MessageBox.Show("Venda realizada! Imprimir cupom?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        ImpressoraService impressora = new ImpressoraService();
                        impressora.ImprimirCupom(novaVenda);
                    }

                    // Volta para a tela de vendas
                    Principla formPrincipal = this.ParentForm as Principla;
                    if (formPrincipal != null)
                    {
                        formPrincipal.RenderizarControl(new UC_Vendas());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------------------------
        // Designer Code (Mantido abaixo oculto para organização)
        // ----------------------------------------------------------------------
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private PictureBox pic_Cartão;
        private PictureBox pic_Pix;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private PictureBox pic_Dinheiro;
        private Label lbl_ValorPendente;
        private Label lbl_ValorCompra;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Pagamento));
            this.parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbl_ValorCompra = new System.Windows.Forms.Label();
            this.lbl_ValorPendente = new System.Windows.Forms.Label();
            this.pic_Dinheiro = new System.Windows.Forms.PictureBox();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.pic_Pix = new System.Windows.Forms.PictureBox();
            this.pic_Cartão = new System.Windows.Forms.PictureBox();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.parrotGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Dinheiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cartão)).BeginInit();
            this.SuspendLayout();
            // 
            // parrotGradientPanel1
            // 
            this.parrotGradientPanel1.BottomLeft = System.Drawing.Color.Black;
            this.parrotGradientPanel1.BottomRight = System.Drawing.Color.DarkBlue;
            this.parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.parrotGradientPanel1.Controls.Add(this.kryptonGroupBox1);
            this.parrotGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.parrotGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.parrotGradientPanel1.Name = "parrotGradientPanel1";
            this.parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.parrotGradientPanel1.PrimerColor = System.Drawing.Color.White;
            this.parrotGradientPanel1.Size = new System.Drawing.Size(1119, 729);
            this.parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            this.parrotGradientPanel1.TabIndex = 0;
            this.parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.parrotGradientPanel1.TopLeft = System.Drawing.Color.DeepSkyBlue;
            this.parrotGradientPanel1.TopRight = System.Drawing.Color.RoyalBlue;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(337, 116);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonButton1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_ValorCompra);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_ValorPendente);
            this.kryptonGroupBox1.Panel.Controls.Add(this.pic_Dinheiro);
            this.kryptonGroupBox1.Panel.Controls.Add(this.bigLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.pic_Pix);
            this.kryptonGroupBox1.Panel.Controls.Add(this.pic_Cartão);
            this.kryptonGroupBox1.Panel.Controls.Add(this.bigLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(669, 473);
            this.kryptonGroupBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroupBox1.StateCommon.Border.Rounding = 40;
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(218, 387);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(171, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 10;
            this.kryptonButton1.TabIndex = 10;
            this.kryptonButton1.Values.Text = "Finalizar Venda";
            this.kryptonButton1.Click += new System.EventHandler(this.btn_Finalizar_Click);
            // 
            // lbl_ValorCompra
            // 
            this.lbl_ValorCompra.AutoSize = true;
            this.lbl_ValorCompra.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ValorCompra.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorCompra.Location = new System.Drawing.Point(117, 294);
            this.lbl_ValorCompra.Name = "lbl_ValorCompra";
            this.lbl_ValorCompra.Size = new System.Drawing.Size(205, 32);
            this.lbl_ValorCompra.TabIndex = 9;
            this.lbl_ValorCompra.Text = "Valor da Compra";
            // 
            // lbl_ValorPendente
            // 
            this.lbl_ValorPendente.AutoSize = true;
            this.lbl_ValorPendente.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ValorPendente.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorPendente.Location = new System.Drawing.Point(117, 239);
            this.lbl_ValorPendente.Name = "lbl_ValorPendente";
            this.lbl_ValorPendente.Size = new System.Drawing.Size(222, 32);
            this.lbl_ValorPendente.TabIndex = 7;
            this.lbl_ValorPendente.Text = "Valor da Pendente";
            // 
            // pic_Dinheiro
            // 
            this.pic_Dinheiro.BackColor = System.Drawing.Color.Transparent;
            this.pic_Dinheiro.Image = ((System.Drawing.Image)(resources.GetObject("pic_Dinheiro.Image")));
            this.pic_Dinheiro.Location = new System.Drawing.Point(441, 114);
            this.pic_Dinheiro.Name = "pic_Dinheiro";
            this.pic_Dinheiro.Size = new System.Drawing.Size(177, 101);
            this.pic_Dinheiro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Dinheiro.TabIndex = 5;
            this.pic_Dinheiro.TabStop = false;
            this.pic_Dinheiro.Click += new System.EventHandler(this.pic_Dinheiro_Click);
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bigLabel2.Location = new System.Drawing.Point(104, 52);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(250, 57);
            this.bigLabel2.TabIndex = 4;
            this.bigLabel2.Text = "Pagamento";
            // 
            // pic_Pix
            // 
            this.pic_Pix.BackColor = System.Drawing.Color.Transparent;
            this.pic_Pix.Image = ((System.Drawing.Image)(resources.GetObject("pic_Pix.Image")));
            this.pic_Pix.Location = new System.Drawing.Point(230, 114);
            this.pic_Pix.Name = "pic_Pix";
            this.pic_Pix.Size = new System.Drawing.Size(184, 101);
            this.pic_Pix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Pix.TabIndex = 3;
            this.pic_Pix.TabStop = false;
            this.pic_Pix.Click += new System.EventHandler(this.pic_Pix_Click);
            // 
            // pic_Cartão
            // 
            this.pic_Cartão.BackColor = System.Drawing.Color.Transparent;
            this.pic_Cartão.Image = ((System.Drawing.Image)(resources.GetObject("pic_Cartão.Image")));
            this.pic_Cartão.Location = new System.Drawing.Point(26, 114);
            this.pic_Cartão.Name = "pic_Cartão";
            this.pic_Cartão.Size = new System.Drawing.Size(169, 101);
            this.pic_Cartão.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Cartão.TabIndex = 2;
            this.pic_Cartão.TabStop = false;
            this.pic_Cartão.Click += new System.EventHandler(this.pic_cartão_Click);
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.White;
            this.bigLabel1.Location = new System.Drawing.Point(220, 0);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(169, 57);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "Formas";
            // 
            // UC_Pagamento
            // 
            this.Controls.Add(this.parrotGradientPanel1);
            this.Name = "UC_Pagamento";
            this.Size = new System.Drawing.Size(1119, 729);
            this.Load += new System.EventHandler(this.UC_Pagamento_Load);
            this.parrotGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Dinheiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cartão)).EndInit();
            this.ResumeLayout(false);
        }
    }

    
}