using System;
using System.Drawing;
using System.Windows.Forms;

class CheckerChildWithFocus : CheckerChild
{
    protected override void OnGotFocus(EventArgs e)
    {
        Invalidate();
    }

    protected override void OnLostFocus(EventArgs e)
    {
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (Focused)
        {
            Graphics grfx = e.Graphics;
            Pen pen = new Pen(ForeColor, 5);

            grfx.DrawRectangle(pen, ClientRectangle);
        }
    }
}