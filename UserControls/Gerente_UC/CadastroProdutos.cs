using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Projeto_FinalOficial
{
    public partial class CadastroProdutos : UserControl
    {
        private readonly UserLogger _logger = new UserLogger();
        public CadastroProdutos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
        
            // Cria a janela de seleção de arquivos
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Define o título da janela
                ofd.Title = "Selecione a foto do produto";

                // Filtra para aparecer apenas imagens (JPG, PNG, BMP)
                ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

                // Abre a janela e verifica se o usuário clicou em "OK"
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Carrega a imagem selecionada para dentro do PictureBox
                    pic_Foto.Image = Image.FromFile(ofd.FileName);

                    // Ajusta o modo de exibição para a imagem caber certinho no quadrado
                    // StretchImage: Estica a imagem (pode distorcer um pouco)
                    // Zoom: Mantém a proporção (pode deixar bordas brancas)
                    pic_Foto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                _logger.LogClick(sender, this);
            }
        }

        

        private void btn_Cadastrar_Click(object sender, System.EventArgs e)
        {
            // 1. Validação (Está ok)
            if (string.IsNullOrWhiteSpace(txt_Nome.Text) ||
               string.IsNullOrWhiteSpace(txt_Valor.Text) || // Adicionei validações principais
               string.IsNullOrWhiteSpace(txt_CodigoBarras.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            try
            {
                // 2. Tratamento da Imagem (Está ok)
                byte[] fotoBytes = null;
                if (pic_Foto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Dica: Use Png para melhor qualidade/transparência, ou Jpeg para arquivo menor
                        pic_Foto.Image.Save(ms, ImageFormat.Png);
                        fotoBytes = ms.ToArray();
                    }
                }

                // 3. Criação do Objeto (Está ok)
                Produtos produto = new Produtos
                {
                    Nome = txt_Nome.Text,
                    Cor = txt_Cor.Text,
                    Categoria = txt_Categoria.Text,
                    // Cuidado: int.Parse quebra se o campo estiver vazio ou for letra. 
                    // Em produção use int.TryParse. Para agora, manteremos assim.
                    QtdAtual = int.Parse(txt_QuantidadeAt.Text),
                    QtdMax = int.Parse(txt_QuantidadeMax.Text),
                    QtdMin = int.Parse(txt_QuantidadeMin.Text),
                    Valor = decimal.Parse(txt_Valor.Text),
                    CodigoBarras = txt_CodigoBarras.Text,
                    Foto = fotoBytes
                };

                // -------------------------------------------------------
                // 4. O PASSO QUE FALTAVA: CHAMAR O SALVAR
                // -------------------------------------------------------
                if (produto.Salvar())
                {
                    MessageBox.Show("Produto cadastrado com sucesso!");
                    LimparCampos(); // Crie um método para limpar os textos
                    _logger.LogClick(sender, this);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar no banco de dados.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique se os campos numéricos (Qtd, Valor) estão corretos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        // Método auxiliar sugerido
        private void LimparCampos()
        {
            txt_Nome.Clear();
            txt_Cor.Clear();
            txt_Categoria.Clear();
            txt_QuantidadeAt.Text = "0";
            txt_QuantidadeMax.Text = "0";
            txt_QuantidadeMin.Text = "0";
            txt_Valor.Text = "0.00";
            txt_CodigoBarras.Clear();
            pic_Foto.Image = null;
        }

        private void CadastroProdutos_Load(object sender, EventArgs e)
        {
            _logger.LogOpen(this);
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
