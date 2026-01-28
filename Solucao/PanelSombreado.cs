using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// Versão Melhorada: Sombra mais suave e com direção (Efeito 3D)
public class PanelSombreado : Panel
{
    // Aumentei o tamanho para a sombra ter mais espaço para "espalhar" suavemente
    private int _shadowSpread = 10;
    // Diminui a opacidade inicial para ficar mais sutil (Alpha 40)
    private int _startAlpha = 40;
    private Color _shadowBaseColor = Color.Black;

    public PanelSombreado()
    {
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.UserPaint, true);

        this.BackColor = Color.White;
        // Padding maior para acomodar a sombra deslocada
        this.Padding = new Padding(2, 2, _shadowSpread + 2, _shadowSpread + 2);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality; // Qualidade máxima
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

        // Define a área do cartão branco (conteúdo)
        // Deixamos margem à direita e embaixo para a sombra cair
        Rectangle rectContent = new Rectangle(
            this.Padding.Left,
            this.Padding.Top,
            this.Width - this.Padding.Horizontal,
            this.Height - this.Padding.Vertical);

        // --- DESENHO DA SOMBRA (MELHORADO) ---
        // Desenhamos de fora para dentro.
        for (int i = _shadowSpread; i >= 1; i--)
        {
            // FÓRMULA MÁGICA: Decaimento exponencial da transparência.
            // Em vez de diminuir linearmente, diminui em curva, ficando muito suave nas bordas.
            // Math.Pow(0.85, i) cria essa curva de suavidade.
            int currentAlpha = (int)(_startAlpha * Math.Pow(0.85, i));
            currentAlpha = Math.Max(0, Math.Min(255, currentAlpha)); // Garante que está entre 0-255

            using (Pen shadowPen = new Pen(Color.FromArgb(currentAlpha, _shadowBaseColor), 1.5f))
            {
                // Criamos um retângulo para esta camada da sombra.
                // O truque do 3D: Deslocamos ligeiramente (+ i/2) para baixo e direita.
                Rectangle shadowLayer = new Rectangle(
                    rectContent.X - i + (i / 2),  // Deslocamento X
                    rectContent.Y - i + (i / 2),  // Deslocamento Y
                    rectContent.Width + (i * 2),
                    rectContent.Height + (i * 2)
                );

                // Usar DrawRoundedRectangle aqui ficaria ainda melhor, mas exige mais código.
                // O DrawRectangle com Pen suave já melhora muito.
                g.DrawRectangle(shadowPen, shadowLayer);
            }
        }

        // --- DESENHO DO CARD BRANCO ---
        // Desenhamos o retângulo branco sólido por cima de tudo para cobrir o centro da sombra
        using (SolidBrush brushbg = new SolidBrush(this.BackColor))
        {
            g.FillRectangle(brushbg, rectContent);
        }

        // (Opcional) Borda super fina para definição
        using (Pen borderPen = new Pen(Color.FromArgb(240, 240, 240), 1))
        {
            g.DrawRectangle(borderPen, rectContent);
        }
    }
}