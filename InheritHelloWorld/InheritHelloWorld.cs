using System;
using System.Drawing;
using System.Windows.Forms;

class InheritHelloWorld:HelloWorld
{
    public new static void Main()
    {
        Application.Run(new InheritHelloWorld());
    }

    public InheritHelloWorld()
    {
        Text = "Inherit " + Text;
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics grpx = pea.Graphics;
        grpx.DrawString("Hello from InheritHelloWorld!", Font, Brushes.Black, 0, 100);
    }
} 