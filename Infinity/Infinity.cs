using System;
using System.Drawing;
using System.Windows.Forms;

class Infinity : PrintableForm
{
  public new static void Main()
  {
    Application.Run(new Infinity());
  }

  public Infinity()
  {
    Text = "Infinity Sign Using Bezier Splines";
  }

  protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
  {
    cx--;
    cy--;

    Point[] apt =
    {
      new Point(0,          cy / 2),     // Начальная
      new Point(0,          0),          // Управляющая
      new Point(    cx / 3, 0),          // Управляющая
      new Point(    cx / 2, cy / 2),     // Конечная/начальная
      new Point(2 * cx / 3, cy),         // Управляющая
      new Point(    cx,     cy),         // Управляющая
      new Point(    cx,     cy / 2),     // Конечная/начальная
      new Point(    cx,     0),          // Управляющая
      new Point(2 * cx / 3, 0),          // Управляющая
      new Point(    cx / 2, cy / 2),     // Конечная/начальная
      new Point(    cx / 3, cy),         // Управляющая
      new Point(0,          cy),         // Управляющая
      new Point(0,          cy / 2)      // Конечная
    };
    grfx.DrawBeziers(new Pen(clr), apt);
    //grfx.DrawPolygon(new Pen(Color.Gray), apt);
  }
}