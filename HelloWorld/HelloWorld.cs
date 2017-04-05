using System;
using System.Drawing;
using System.Windows.Forms;

class HelloWorld:Form
{
    public static void Main()
    {
        Application.Run(new HelloWorld());
    }

    public HelloWorld()
    {
        Text = "Hello World";
        BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        base.OnPaint(pea);
        Graphics grfx = pea.Graphics;
        grfx.DrawString("Hello, Windows Forms!", Font, Brushes.Black, 0, 0);
    }
}