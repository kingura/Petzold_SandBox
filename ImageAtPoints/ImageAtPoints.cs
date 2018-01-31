using System;
using System.Drawing;
using System.Windows.Forms;

class ImageAtPoints: PrintableForm
{
  Image image;

  public static new void Main()
  {
    Application.Run(new ImageAtPoints());
  }

  public ImageAtPoints()
  {
    Text = "Image At Points";

    image = Image.FromFile("..\\..\\..\\Apollo11FullColor_220x240.jpg");
  }

  protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
  {
    grfx.DrawImage(image, new Point[] { new Point(cx / 2, 0), new Point(cx, cy / 2), new Point(0, cy / 2) });
  }
}