using System;
using System.Drawing;
using System.Windows.Forms;

class RandomClearResizeRedraw : Form
{
    public static void Main()
    {
        Application.Run(new RandomClearResizeRedraw());
    }

    public RandomClearResizeRedraw()
    {
        Text = "Random Clear with Resize Redraw";
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Random rand = new Random();

        grfx.Clear(Color.FromArgb(rand.Next(256),
                                  rand.Next(256),
                                  rand.Next(256)));
    }

    //protected override void OnResize(EventArgs e)
    //{
    //}
}