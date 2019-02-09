using System;
using System.Drawing;
using System.Windows.Forms;

class DateAndTimeStatus : Form
{
  StatusBarPanel sbpMenu, sbpDate, sbpTime;

  public static void Main()
  {
    Application.Run(new DateAndTimeStatus());
  }

  public DateAndTimeStatus()
  {
    Text = "Date and Time Status";
    BackColor = SystemColors.Window;
    ForeColor = SystemColors.WindowText;

    // Создание строки состояния.

    StatusBar sb = new StatusBar();
    sb.Parent = this;
    sb.ShowPanels = true;

    // Создание панелей для строки состояния.

    sbpMenu = new StatusBarPanel();
    sbpMenu.Text = "Reserved for menu help";
    sbpMenu.BorderStyle = StatusBarPanelBorderStyle.None;
    sbpMenu.AutoSize = StatusBarPanelAutoSize.Spring;

    sbpDate = new StatusBarPanel();
    sbpDate.AutoSize = StatusBarPanelAutoSize.Contents;
    sbpDate.ToolTipText = "The current date";

    sbpTime = new StatusBarPanel();
    sbpDate.AutoSize = StatusBarPanelAutoSize.Contents;
    sbpTime.ToolTipText = "The current time";

    // Сопоставление панелей строке состояния.

    sb.Panels.AddRange(new StatusBarPanel[] { sbpMenu, sbpDate, sbpTime });

    // Установка таймера на срабатывание каждую секунду.

    Timer timer = new Timer();
    timer.Tick += new EventHandler(TimerOnTick);
    timer.Interval = 1000;
    timer.Start();
  }

  void TimerOnTick(object sender, EventArgs e)
  {
    DateTime dt = DateTime.Now;

    sbpDate.Text = dt.ToShortDateString();
    sbpTime.Text = dt.ToShortTimeString();
  }
}