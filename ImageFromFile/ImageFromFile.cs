using System;
using System.Drawing;
using System.Windows.Forms;

class ImageFromFile: PrintableForm
{
    public new static void Main()
    {
        Application.Run(new ImageFromFile());
    }

    public ImageFromFile()
    {
        Text = "Image From File";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        Image image = Image.FromFile("..\\..\\..\\Apollo11FullColor_220x240.jpg");

        grfx.DrawImage(image, 0, 0);
    }

}