using System;
using System.Drawing;
using System.Windows.Forms;

class ScribbleWithBitmap : Form
{
  bool bTracking;
  Point ptLast;
  Bitmap bitmap; 
  Graphics grfxBm;

  public static void Main()
  {
    Application.Run(new ScribbleWithBitmap());
  }

  public ScribbleWithBitmap()
  {
    Text = "Scribble with Bitmap";
    BackColor = SystemColors.Window;
    ForeColor = SystemColors.WindowText;

    // Создаем битовую карту
    Size size = SystemInformation.PrimaryMonitorMaximizedWindowSize;
    bitmap = new Bitmap(size.Width, size.Height);

    // Создаем объект Graphics для битовой карты
    grfxBm = Graphics.FromImage(bitmap);
    grfxBm.Clear(BackColor);

    Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
  }

  private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
  {
    // Пересоздаем битовую карту с новым размером
    Size size = SystemInformation.PrimaryMonitorMaximizedWindowSize;
    bitmap = new Bitmap(bitmap, size.Width, size.Height);
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Left)
      return;

    ptLast = e.Location;
    bTracking = true;
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (!bTracking)
      return;

    Point ptNew = e.Location;

    Pen pen = new Pen(ForeColor);
    Graphics grfx = CreateGraphics();
    grfx.DrawLine(pen, ptLast, ptNew);
    grfx.Dispose();

    // Рисуем на битовой карте
    grfxBm.DrawLine(pen, ptLast, ptNew);

    ptLast = ptNew;
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    bTracking = false;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    // Отображаем битовую карту
    e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
  }
}