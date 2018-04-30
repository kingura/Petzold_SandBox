using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class TwoPointLinearGradientBrush : PrintableForm
{
  public new static void Main()
  {
    Application.Run(new TwoPointLinearGradientBrush());
  }

  public TwoPointLinearGradientBrush()
  {
    Text = "Two-Point Linear Gradient Brush";
  }

  protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
  {
    LinearGradientBrush lgbrush = new LinearGradientBrush(
      new Point(cx / 4, cy / 4),
      new Point(cx * 3 / 4, cy * 3 / 4),
      Color.White, Color.Black);

    lgbrush.WrapMode = WrapMode.TileFlipX;

    grfx.FillRectangle(lgbrush, 0, 0, cx, cy);
  }
}