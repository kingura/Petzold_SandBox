using System;
using System.Drawing;
using System.Windows.Forms;

class EnterLeave : Form
{
    bool bInside = false;

    static public void Main()
    {
        Application.Run(new EnterLeave());
    }
    public EnterLeave()
    {
        Text = "Enter/Leave";
    }
    protected override void OnMouseEnter(EventArgs e)
    {
        bInside = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        bInside = false;
        Invalidate();
    }
    protected override void OnMouseHover(EventArgs e)
    {
        Graphics grfx = CreateGraphics();

        grfx.Clear(Color.Red);
        System.Threading.Thread.Sleep(100);
        grfx.Clear(Color.Green);
        grfx.Dispose();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;
        grfx.Clear(bInside ? Color.Green : BackColor);
    }
}