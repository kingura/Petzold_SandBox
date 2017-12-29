using System;
using System.Drawing;
using System.Windows.Forms;

class AnalogClock : Form
{
    ClockControl clkctl;

    public static void Main()
    {
        Application.Run(new AnalogClock());
    }
    public AnalogClock()
    {
        Text = "Analog Clock";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;

        clkctl = new ClockControl();
        clkctl.Parent = this;
        clkctl.Time = DateTime.Now;
        clkctl.Dock = DockStyle.Fill;
        clkctl.BackColor = Color.Black;
        clkctl.ForeColor = Color.White;

        Timer timer = new Timer();
        timer.Interval = 100;
        timer.Tick += new EventHandler(TimerOnTick);
        timer.Start();
    }

    void TimerOnTick(object obj, EventArgs ea)
    {
        //clkctl.Time = DateTime.Now;

        DateTime dt = DateTime.Now;
        dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        clkctl.Time = dt;

        //clkctl.Time += new TimeSpan(10000000);

        //clkctl.Time -= new TimeSpan(1000000);
    }
}