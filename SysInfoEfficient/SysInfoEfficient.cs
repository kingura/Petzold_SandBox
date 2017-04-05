using System;
using System.Drawing;
using System.Windows.Forms;

internal class SysInfoEfficient : SysInfoUpdate
{
    private static void Main()
    {
        Application.Run(new SysInfoEfficient());
    }

    public SysInfoEfficient()
    {
        Text = "System Information: Efficient";
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        Brush brush = new SolidBrush(ForeColor);
        Point pt = AutoScrollPosition;

        int iFirst = (int) ((pea.ClipRectangle.Top - pt.Y)/cySpace);
        int iLast = (int) ((pea.ClipRectangle.Bottom - pt.Y)/cySpace);
        iLast = Math.Min(iLast, iCount - 1);

        for (int i = iFirst; i <= iLast; i++)
        {
            grfx.DrawString(astrLabels[i], Font, brush, pt.X, pt.Y + cySpace*i);
            grfx.DrawString(astrValues[i], Font, brush, pt.X + cxCol, pt.Y + cySpace*i);
        }
    }
}