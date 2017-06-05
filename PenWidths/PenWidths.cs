using System;
using System.Drawing;
using System.Windows.Forms;

class PenWidths : PrintableForm
{
    static public new void Main()
    {
        Application.Run(new PenWidths());
    }

    public PenWidths()
    {
        Text = "Pen Widths";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        Brush brush = new SolidBrush(clr);
        float y = 0;

        for (float f = 0; f < 3.2f; f += 0.2f)
        {
            Pen pen = new Pen(clr, f);
            string str = String.Format("{0:F1}-point-wide pen: ", f);
            SizeF sizef = grfx.MeasureString(str, Font);

            grfx.DrawString(str, Font, brush, 0, y);
            grfx.DrawLine(pen, sizef.Width, y + sizef.Height/2, sizef.Width + 144, y + sizef.Height/2);

            y += sizef.Height;
        }
    }
}