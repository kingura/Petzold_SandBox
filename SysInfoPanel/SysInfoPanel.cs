using System;
using System.Drawing;
using System.Windows.Forms;

class SysInfoPanel : Form
{
    private readonly float cxCol;
    private readonly int cySpace;

    public static void Main()
    {
        Application.Run(new SysInfoPanel());
    }

    public SysInfoPanel()
    {
        Text = "System Information with Panel";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        AutoScroll = true;
        AutoScrollMargin = new Size(10, 10);

        Graphics grfx = CreateGraphics();
        SizeF sizef = grfx.MeasureString(" ", Font);
        cxCol = sizef.Width + SysInfoStrings.MaxLabelWidth(grfx, Font);
        cySpace = Font.Height;

            //Создаём панель

        Panel panel = new Panel();
        panel.Parent = this;
        panel.Paint += new PaintEventHandler(PanelOnPaint);
        panel.Location = Point.Empty;
        panel.Size = new Size((int) Math.Ceiling(cxCol + SysInfoStrings.MaxValueWidth(grfx, Font)),
            cySpace*SysInfoStrings.Count);
        // test
        panel.BackColor = Color.Honeydew;
        panel.Move += new EventHandler(PanelOnMove);

        grfx.Dispose();
    }

    void PanelOnPaint(object obj, PaintEventArgs pea)
    {
        Graphics grfx = pea.Graphics;
        Brush brush = new SolidBrush(ForeColor);

        int iCount = SysInfoStrings.Count;
        string[] astrLabels = SysInfoStrings.Labels;
        string[] astrValues = SysInfoStrings.Values;

        for (int i = 0; i < iCount; i++)
        {
            grfx.DrawString(astrLabels[i], Font, brush, 0, cySpace*i);
            grfx.DrawString(astrValues[i], Font, brush, cxCol, cySpace*i);
        }

        // test Выводим данные свойств класса ScrollableControl, наследуемого экземпляром panel
        grfx.DrawString(HScroll.ToString(), Font, brush, 400, 100);
        grfx.DrawString(VScroll.ToString(), Font, brush, 426, 100);
        grfx.DrawString(AutoScrollPosition.ToString(), Font, brush, 400, 100 + cySpace);
    }

    private void PanelOnMove(object sender, EventArgs ea)
    {
        (sender as Panel).Invalidate();
        //((Panel)sender).Invalidate();
    }
}