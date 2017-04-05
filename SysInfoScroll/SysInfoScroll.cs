using System;
using System.Drawing;
using System.Windows.Forms;

class SysInfoScroll : Form
{
    private readonly int cySpace;
    private readonly float cxCol;

    static void Main()
    {
        Application.Run(new SysInfoScroll());
    }

    public SysInfoScroll()
    {
        Text = "System Information Scroll";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;

        Graphics grfx = this.CreateGraphics();
        SizeF sizef = grfx.MeasureString(" ", Font);
        cxCol = sizef.Width + SysInfoStrings.MaxLabelWidth(grfx, Font);
        cySpace = Font.Height;
            // Устанавливаем свойства автопрокрутки
        AutoScroll = true;
        AutoScrollMinSize = new Size(
            (int) Math.Ceiling(cxCol + SysInfoStrings.MaxValueWidth(grfx, Font)),
            SysInfoStrings.Count*cySpace);

        grfx.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Brush brush = Brushes.Black;

        int iCount = SysInfoStrings.Count;
        string[] strLabels = SysInfoStrings.Labels;
        string[] strValues = SysInfoStrings.Values;

        Point pt = AutoScrollPosition;

        for (int i = 0; i < iCount; i++)
        {
            grfx.DrawString(strLabels[i], Font, brush, pt.X, pt.Y + i*cySpace);
            grfx.DrawString(strValues[i], Font, brush, pt.X + cxCol, pt.Y + i*cySpace);
        }
    }
}