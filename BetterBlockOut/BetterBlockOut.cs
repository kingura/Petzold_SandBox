using System;
using System.Drawing;
using System.Windows.Forms;

class BetterBlockOut : Form
{
    bool bBlocking, bValidBox;
    Point ptBeg, ptEnd;
    Rectangle rectBox;

    static public void Main()
    {
        Application.Run(new BetterBlockOut());
    }
    public BetterBlockOut()
    {
        Text = "Better Blockout";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ptBeg = ptEnd = new Point(e.X, e.Y);

            Graphics grfx = CreateGraphics();
            grfx.DrawRectangle(new Pen(ForeColor), Rect(ptBeg, ptEnd));
            grfx.Dispose();

            bBlocking = true;
        }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (bBlocking && (e.Button & MouseButtons.Left) != 0)
        {
            Graphics grfx = CreateGraphics();
            grfx.DrawRectangle(new Pen(BackColor), Rect(ptBeg, ptEnd));
            ptEnd = new Point(e.X, e.Y);
            grfx.DrawRectangle(new Pen(ForeColor), Rect(ptBeg, ptEnd));
            grfx.Dispose();
            Invalidate();
        }
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (bBlocking)
        {
            Graphics grfx = CreateGraphics();
            rectBox = Rect(ptBeg, new Point(e.X, e.Y));
            grfx.DrawRectangle(new Pen(ForeColor), rectBox);
            grfx.Dispose();

            bBlocking = false;
            bValidBox = true;
            Invalidate();
        }
    }
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (bBlocking && e.KeyChar == '\x001B') // Escape
        {
            Graphics grfx = CreateGraphics();
            grfx.DrawRectangle(new Pen(BackColor), Rect(ptBeg, ptEnd));
            grfx.Dispose();

            bBlocking = false;
            Invalidate();
        }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;

        if (bValidBox)
            grfx.FillRectangle(new SolidBrush(ForeColor), rectBox);

        if (bBlocking)
            grfx.DrawRectangle(new Pen(ForeColor), Rect(ptBeg, ptEnd));
    }
    Rectangle Rect(Point ptBeg, Point ptEnd)
    {
        return new Rectangle(Math.Min(ptBeg.X, ptEnd.X),
                             Math.Min(ptBeg.Y, ptEnd.Y),
                             Math.Abs(ptBeg.X - ptEnd.X),
                             Math.Abs(ptBeg.Y - ptEnd.Y));
    }
}