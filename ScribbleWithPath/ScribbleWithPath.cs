using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class ScribbleWithPath: Form
{
  GraphicsPath path;
  bool bTracking;
  Point ptLast;

  public static void Main()
  {
    Application.Run(new ScribbleWithPath());
  }

  public ScribbleWithPath()
  {
    Text = "Scribble with Path";
    BackColor = SystemColors.Window;
    ForeColor = SystemColors.WindowText;

    // Создаем контур

    path = new GraphicsPath();
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Left)
      return;

    ptLast = e.Location;
    bTracking = true;

    // Начало фигуры

    path.StartFigure();
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (!bTracking)
      return;

    Point ptNew = e.Location;

    Graphics grfx = CreateGraphics();
    grfx.DrawLine(new Pen(ForeColor), ptLast, ptNew);
    grfx.Dispose();

    // Добавляем линию

    path.AddLine(ptLast, ptNew);

    ptLast = ptNew;
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    bTracking = false;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    // Рисуем контур

    e.Graphics.DrawPath(new Pen(ForeColor), path);
  }
}