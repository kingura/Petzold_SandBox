using System;
using System.Drawing;
using System.Windows.Forms;

class SimpleClock : Form
{
    public static void Main()
    {
        Application.Run(new SimpleClock());
    }

    public SimpleClock()
    {
        Text = "Simple Clock";
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
        base.OnPaint(e);

        StringFormat strfmt = new StringFormat();
        strfmt.Alignment = strfmt.LineAlignment = StringAlignment.Center;

        e.Graphics.DrawString(DateTime.Now.ToString("F"), Font, new SolidBrush(ForeColor),
            ClientRectangle, strfmt);
    }
}