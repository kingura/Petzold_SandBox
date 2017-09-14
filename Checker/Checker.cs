using System;
using System.Windows.Forms;
using System.Drawing;

class Checker:Form
{
    protected const int xNum = 5;   // Количество клеток по горизонтали
    protected const int yNum = 4;   // Количество клеток по вертикали
    protected int cxBlock, cyBlock;
    protected bool[,] abChecked = new bool[xNum, yNum];

    public static void Main()
    {
        Application.Run(new Checker());
    }

    public Checker()
    {
        Text = "Checker";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;

        OnResize(EventArgs.Empty);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);   // Иначе ResizeRedraw не будет работать

        cxBlock = ClientSize.Width / xNum;
        cyBlock = ClientSize.Height / yNum;
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        int x = e.X / cxBlock;
        int y = e.Y / cyBlock;

        if (x < xNum && y < yNum)
        {
            abChecked[x, y] ^= true;
            Invalidate(new Rectangle(x * cxBlock, y * cyBlock, cxBlock, cyBlock));
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Pen pen = new Pen(ForeColor);

        for (int x = 0; x < xNum; x++)
            for (int y = 0; y < yNum; y++)
            {
                grfx.DrawRectangle(pen, x * cxBlock, y * cyBlock, cxBlock, cyBlock);
                if (abChecked[x, y])
                {
                    grfx.DrawLine(pen, x * cxBlock, y * cyBlock, (x + 1) * cxBlock, (y + 1) * cyBlock);
                    grfx.DrawLine(pen, x * cxBlock, (y + 1) * cyBlock, (x + 1) * cxBlock, y * cyBlock);
                }
            }
    }
}