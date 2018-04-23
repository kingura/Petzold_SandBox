using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class HatchBrushArray : PrintableForm
{
  const int iSize = 32, iMargin = 8;
  const int iMin = 0, iMax = 52; // Минимальное и максимальное значения HatchStyle

  public new static void Main()
  {
    Application.Run(new HatchBrushArray());
  }

  public HatchBrushArray()
  {
    Text = "Hatch Brush Array";
    ClientSize = new Size(8 * iSize + 9 * iMargin, 7 * iSize + 8 * iMargin);
  }

  protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
  {
    for (HatchStyle hs = (HatchStyle)iMin; hs <= (HatchStyle)iMax; hs++)
    {
      HatchBrush hbrush = new HatchBrush(hs, Color.White, Color.Black);
      int y = (int)hs / 8;
      int x = (int)hs % 8;

      grfx.FillRectangle(hbrush, iMargin + x * (iMargin + iSize),
                                 iMargin + y * (iMargin + iSize),
                                 iSize, iSize);
    }
  }
}