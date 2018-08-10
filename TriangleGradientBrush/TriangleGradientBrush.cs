using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class TriangleGradientBrush : PrintableForm
{
  public new static void Main()
  {
    Application.Run(new TriangleGradientBrush());
  }

  public TriangleGradientBrush()
  {
    Text = "Triangle Gradient Brush";
  }

  protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
  {
    Point[] apt = { new Point(cx, 0),
                    new Point(cx, cy),
                    new Point(0, cy) };

    PathGradientBrush pgbrush = new PathGradientBrush(apt);

    pgbrush.SurroundColors = new Color[] {Color.Red, Color.Green, Color.Blue};
    grfx.FillRectangle(pgbrush, 0, 0, cx, cy);
  }
}