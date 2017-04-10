using System;
using System.Drawing;
using System.Windows.Forms;

internal class ClientEllipse : PrintableForm
{
    private new static void Main()
    {
        Application.Run(new ClientEllipse());
    }

    public ClientEllipse()
    {
        Text = "Client Ellipse";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.DrawEllipse(new Pen(clr), 0, 0, cx - 1, cy - 1);
    }
}