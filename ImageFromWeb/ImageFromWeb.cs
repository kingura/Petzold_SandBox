using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;

class ImageFromWeb : PrintableForm
{
    Image image;

    public new static void Main()
    {
        Application.Run(new ImageFromWeb());
    }

    public ImageFromWeb()
    {
        Text = "Image From Web";
        
        string strUrl = "http://solarviews.com/browse/apo/as11_40_5903.jpg";

        WebRequest webreq = WebRequest.Create(strUrl);
        WebResponse webres = webreq.GetResponse();

        Stream stream = webres.GetResponseStream();

        image = Image.FromStream(stream);
        stream.Close();
        webres.Close();
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.DrawImage(image, 0, 0);
    }
}