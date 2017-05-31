using System;
using System.Drawing;
using System.Windows.Forms;

class HundredPixelsSquare : PrintableForm
{
    public static new void Main()
    {
        Application.Run(new HundredPixelsSquare());
    }

    public HundredPixelsSquare()
    {
        Text = "Hundred Pixels Square";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.FillRectangle(new SolidBrush(ForeColor), 100, 100, 100, 100);
    }
}