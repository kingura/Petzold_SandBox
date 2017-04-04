using System;
using System.Drawing;
using System.Windows.Forms;

class DrawHouse: PrintableForm
{
    public static new void Main()
    {
        Application.Run(new DrawHouse());
    }

    public DrawHouse()
    {
        Text = "Draw a House in One Line";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.DrawLines(new Pen(clr),
                       new Point[] { new Point(    cx / 4, 3 * cy / 4), // Нижний левый
                                     new Point(    cx / 4,     cy / 2),
                                     new Point(    cx / 2,     cy / 4), // Крыша
                                     new Point(3 * cx / 4,     cy / 2),
                                     new Point(3 * cx / 4, 3 * cy / 4), // Нижний правый
                                     new Point(    cx / 4,     cy / 2),
                                     new Point(3 * cx / 4,     cy / 2),
                                     new Point(    cx / 4, 3 * cy / 4), // Нижний левый
                                     new Point(3 * cx / 4, 3 * cy / 4)  // Нижний правый
                                   }
                      );

        //grfx.DrawLine(new Pen(clr), new Point(cx / 4, 3 * cy / 4), new Point(cx / 4, cy / 2)); // Нижний левый
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(cx / 4, cy / 2), new Point(cx / 2, cy / 4));
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(cx / 2, cy / 4), new Point(3 * cx / 4, cy / 2)); // Крыша
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(3 * cx / 4, cy / 2), new Point(3 * cx / 4, 3 * cy / 4));
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(3 * cx / 4, 3 * cy / 4), new Point(cx / 4, cy / 2)); // Нижний правый
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(cx / 4, cy / 2), new Point(3 * cx / 4, cy / 2));
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(3 * cx / 4, cy / 2), new Point(cx / 4, 3 * cy / 4));
        //Console.ReadKey();
        //grfx.DrawLine(new Pen(clr), new Point(cx / 4, 3 * cy / 4), new Point(3 * cx / 4, 3 * cy / 4)); // Нижний левый, Нижний правый

    }
}