using System;
using System.Drawing;
using System.Windows.Forms;


class DigitalClock : Form
{
    public static void Main()
    {
        Application.Run(new DigitalClock());
    }

    public DigitalClock()
    {
        Text = "Digital Clock";
        ForeColor = SystemColors.WindowText;
        BackColor = SystemColors.Window;
        ResizeRedraw = true;

        Timer timer = new Timer();
        timer.Tick += new EventHandler(TimerOnTick);
        timer.Interval = 1000;
        timer.Start();
    }

    private void TimerOnTick(object obj, EventArgs ea)
    {
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;
        string strTime = DateTime.Now.ToString("T");
        SizeF sizef = grfx.MeasureString(strTime, Font);
        float fScale = Math.Min(ClientSize.Width / sizef.Width, ClientSize.Height / sizef.Height);
        Font font = new Font(Font.FontFamily, fScale * Font.SizeInPoints);

        sizef = grfx.MeasureString(strTime, font);

        grfx.DrawString(strTime, font, new SolidBrush(ForeColor),
            (ClientSize.Width - sizef.Width) / 2, (ClientSize.Height - sizef.Height) / 2);
    }
}