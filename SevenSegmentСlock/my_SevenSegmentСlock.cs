using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

class my_SevenSegmentСlock : Form
{
    DateTime dt = DateTime.Now;

    public static void Main()
    {
        Application.Run(new my_SevenSegmentСlock());
    }

    public my_SevenSegmentСlock()
    {
        Text = "Seven Segment Сlock";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;

        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += new EventHandler(OnTimerTick);
        timer.Start();
    }

    private void OnTimerTick(object obj, EventArgs ea)
    {
        dt = DateTime.Now;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Brush brush = Brushes.Red;

        my_SevenSegmentDisplay ssd = new my_SevenSegmentDisplay(e.Graphics);
        string str = dt.ToString("T", DateTimeFormatInfo.InvariantInfo);
        SizeF sizef = ssd.MeasureString(str);
        float fScale = Math.Min(ClientSize.Width / sizef.Width, ClientSize.Height / sizef.Height);

        ssd.DrawString(str, brush, fScale,
            (ClientSize.Width - sizef.Width * fScale) / 2,
            (ClientSize.Height - sizef.Height * fScale) / 2);
    }
}