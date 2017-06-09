using System;
using System.Drawing;
using System.Windows.Forms;

class ArbitraryCoordinates: PrintableForm
{
    static public new void Main()
    {
        Application.Run(new ArbitraryCoordinates());
    }

    public ArbitraryCoordinates()
    {
        Text = "Arbitrary Coordinates";
        MinimumSize = SystemInformation.MinimumWindowSize + new Size(0, 1);
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.PageUnit = GraphicsUnit.Pixel;
        SizeF sizef = grfx.VisibleClipBounds.Size;

        grfx.PageUnit = GraphicsUnit.Inch;
        //try
        //{
            grfx.PageScale = Math.Min(sizef.Width / grfx.DpiX / 1000,
                                      sizef.Height / grfx.DpiX / 1000);
        //}
        //catch
        //{
        //    return;
        //}

        grfx.DrawEllipse(new Pen(clr), 0, 0, 990, 990);
    }
}