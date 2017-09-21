using System;
using System.Drawing;
using System.Windows.Forms;

class Scribble : Form
{
    private bool bTracking;
    private Point ptLast;

    public static void Main()
    {
        Application.Run(new Scribble());
    }

    public Scribble()
    {
        Text = "Scribble";
        ForeColor = SystemColors.WindowText;
        BackColor = SystemColors.Window;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
            return;

        ptLast = e.Location;
        bTracking = true;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (!bTracking)
            return;

        Graphics grfx = CreateGraphics();
        grfx.DrawLine(new Pen(ForeColor), ptLast, e.Location);
        grfx.Dispose();
        ptLast = e.Location;
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        bTracking = false;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // А что делается здесь?
    }
}