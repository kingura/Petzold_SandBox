using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

class SysInfoUpdate : Form
{
    protected int iCount;
    protected string[] astrLabels;
    protected string[] astrValues;
    protected float cxCol;
    protected int cySpace;

    // точка входа
    static void Main()
    {
        Application.Run(new SysInfoUpdate());
    }

    // конструктор
    public SysInfoUpdate()
    {
        Text = "System Information: Update";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        AutoScroll = true;

        UpdateAllInfo();

        // привязываемся с системным событиям
        SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(UserPreferenceChanged);
        SystemEvents.DisplaySettingsChanged += new EventHandler(DisplaySettingsChanged);
    }

    void UserPreferenceChanged(object obj, UserPreferenceChangedEventArgs ea)
    {
        UpdateAllInfo();
        Invalidate();
    }
    void DisplaySettingsChanged(object obj, EventArgs ea)
    {
        UpdateAllInfo();
        Invalidate();
    }

    void UpdateAllInfo()
    {
        iCount = SysInfoStrings.Count;
        astrLabels = SysInfoStrings.Labels;
        astrValues = SysInfoStrings.Values;

        Graphics grfx = CreateGraphics();
        SizeF sizef = grfx.MeasureString(" ", Font);
        cxCol = sizef.Width + SysInfoStrings.MaxLabelWidth(grfx, Font);
        cySpace = Font.Height;

        AutoScrollMinSize = new Size((int)Math.Ceiling(cxCol + SysInfoStrings.MaxValueWidth(grfx, Font)), cySpace * iCount);

        grfx.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Brush brush = Brushes.Black;
        Point pt = AutoScrollPosition;

        for (int i = 0; i < iCount; i++)
        {
            grfx.DrawString(astrLabels[i], Font, brush, pt.X, pt.Y + cySpace * i);
            grfx.DrawString(astrValues[i], Font, brush, pt.X + cxCol, pt.Y + cySpace * i);
        }
        

    }
}