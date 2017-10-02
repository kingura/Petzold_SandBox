using System;
using System.Drawing;
using System.Windows.Forms;

class TextOnBaseline: PrintableForm
{
    public new static void Main()
    {
        Application.Run(new TextOnBaseline());
    }

    public TextOnBaseline()
    {
        Text = "Text On Baseline";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        float yBaseline = cy / 2;
        Pen pen = new Pen(clr);

        // Рисуем базовую линию в центре клиентской области

        grfx.DrawLine(pen, 0, yBaseline, cx, yBaseline);

        // Создаем 144-пунктный шрифт

        Font font = new Font("Times New Roman", 100);

        // Получаем и вычисляем метрики

        float cyLineSpace = font.GetHeight(grfx);
        int iCellSpace = font.FontFamily.GetLineSpacing(font.Style);
        int iCellAscent = font.FontFamily.GetCellAscent(font.Style);
        float cyAscent = cyLineSpace * iCellAscent / iCellSpace;

        // Отображаем текст на базовой линии

        grfx.DrawString("Baseline", font, new SolidBrush(clr), 0, yBaseline - cyAscent);

    }
}