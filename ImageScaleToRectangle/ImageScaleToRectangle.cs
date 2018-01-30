using System;
using System.Drawing;
using System.Windows.Forms;

class ImageScaleToRectangle: PrintableForm
{
    Image image;

    public new static void Main()
    {
        Application.Run(new ImageScaleToRectangle());
    }

    public ImageScaleToRectangle()
    {
        Text = "Image Scale To Rectangle";

        image = Image.FromFile("..\\..\\..\\Apollo11FullColor_220x240.jpg");
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.DrawImage(image, 0, 0, cx, cy);
    }
}