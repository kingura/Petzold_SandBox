using System;
using System.Drawing;
using System.Windows.Forms;

class SimpleButton : Form
{
    public static void Main()
    {
        Application.Run(new SimpleButton());
    }

    public SimpleButton()
    {
        Text = "Simple Button";

        Button button = new Button();
        button.Parent = this;
        button.Text = "Click me!";
        button.Location = new Point(100, 100);
        button.Click += new EventHandler(ButtonOnClick);
    }

    void ButtonOnClick(object obj, EventArgs ea)
    {
        Graphics grfx = CreateGraphics();
        Point ptText = Point.Empty;
        string str = "Button Clicked!";

        grfx.DrawString(str, Font, new SolidBrush(ForeColor), ptText);
        System.Threading.Thread.Sleep(250);
        grfx.FillRectangle(new SolidBrush(BackColor),
            new RectangleF(ptText, grfx.MeasureString(str, Font)));
        grfx.Dispose();
    }
}