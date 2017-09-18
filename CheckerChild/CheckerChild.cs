using System;
using System.Drawing;
using System.Windows.Forms;

internal class CheckerChild : UserControl
{
    private bool bChecked = false;

    public CheckerChild()
    {
        ResizeRedraw = true;
    }

    protected override void OnClick(EventArgs ea)
    {
        base.OnClick(ea);

        bChecked = !bChecked;
        Invalidate();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        switch (e.KeyCode)
        {
            case Keys.Space:
            case Keys.Enter:
                OnClick(EventArgs.Empty);
                break;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Pen pen = new Pen(ForeColor);

        grfx.DrawRectangle(pen, ClientRectangle);

        if (bChecked)
        {
            grfx.DrawLine(pen,0,0,ClientSize.Width,ClientSize.Height);
            grfx.DrawLine(pen, 0, ClientSize.Height, ClientSize.Width, 0);
        }
    }
}