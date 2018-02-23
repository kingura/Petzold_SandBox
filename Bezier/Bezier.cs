using System;
using System.Drawing;
using System.Windows.Forms;

class Bezier : Form
{
    protected Point[] apt = new Point[4];

    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Bezier());
    }

    public Bezier()
    {
        Text = "Bezier (Mouse Defines Control Points)";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;

        OnResize(EventArgs.Empty);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        int cx = ClientSize.Width;
        int cy = ClientSize.Height;

        apt[0] = new Point(cx/4, cy/2);
        apt[1] = new Point(cx/2, cy/4);
        apt[2] = new Point(cx/2, 3*cy/4);
        apt[3] = new Point(3*cx/4, cy/2);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Point pt;
        if (e.Button == MouseButtons.Left)
            pt = apt[1];
        else if (e.Button == MouseButtons.Right)
            pt = apt[2];
        else
            return;

        Cursor.Position = PointToScreen(pt);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            apt[1] = e.Location;
            Invalidate();
        }
        else if (e.Button == MouseButtons.Right)
        {
            apt[2] = e.Location;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;

        grfx.DrawBeziers(new Pen(ForeColor), apt);

        Pen pen = new Pen(Color.FromArgb(0x80, ForeColor));
        grfx.DrawLine(pen, apt[0], apt[1]);
        grfx.DrawLine(pen, apt[2], apt[3]);
    }
}