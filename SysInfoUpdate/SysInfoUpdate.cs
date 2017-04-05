using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

internal class SysInfoUpdate : Form
{
    protected int iCount;
    protected string[] astrLabels;
    protected string[] astrValues;
    protected float cxCol;
    protected int cySpace;

    // точка входа
    private static void Main()
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

    private void UserPreferenceChanged(object obj, UserPreferenceChangedEventArgs ea)
    {
        UpdateAllInfo();
        Invalidate();
    }

    private void DisplaySettingsChanged(object obj, EventArgs ea)
    {
        UpdateAllInfo();
        Invalidate();
    }

    private void UpdateAllInfo()
    {
        iCount = SysInfoStrings.Count;
        astrLabels = SysInfoStrings.Labels;
        astrValues = SysInfoStrings.Values;

        Graphics grfx = CreateGraphics();
        SizeF sizef = grfx.MeasureString(" ", Font);
        cxCol = sizef.Width + SysInfoStrings.MaxLabelWidth(grfx, Font);
        cySpace = Font.Height;

        AutoScrollMinSize = new Size((int) Math.Ceiling(cxCol + SysInfoStrings.MaxValueWidth(grfx, Font)),
            cySpace*iCount);

        grfx.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Brush brush = new SolidBrush(ForeColor);
        Point pt = AutoScrollPosition;

        for (int i = 0; i < iCount; i++)
        {
            grfx.DrawString(astrLabels[i], Font, brush, pt.X, pt.Y + cySpace*i);
            grfx.DrawString(astrValues[i], Font, brush, pt.X + cxCol, pt.Y + cySpace*i);
        }

        Console.WriteLine(e.ClipRectangle);
    }
}