using System;
using System.Drawing;
using System.Windows.Forms;

class PolyEllipse : Form
{
    static void Main()
    {
        Application.Run(new PolyEllipse());
    }

    public PolyEllipse()
    {
        Text = "Ellipse with DrawLines";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // base.OnPaint(e);
        Graphics grfx = e.Graphics;
        grfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        grfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        int cx = ClientSize.Width;
        int cy = ClientSize.Height;
        float t = (float)(2 * Math.PI / (2*(cx+cy)));
        int rx = cx/2;
        int ry = cy/2;
        PointF[] pointF = new PointF[2 * (cx + cy)];
        for (int i = 0; i < (2*(cx + cy)); i++)
        {
            pointF[i].X = cx/2 + (float) (rx*Math.Cos(i*t));
            pointF[i].Y = cy/2 + (float)(ry*Math.Sin(i*t));
        }
        grfx.DrawLines(new Pen(ForeColor), pointF);
    }
}