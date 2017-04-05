using System.Drawing;
using System.Windows.Forms;

class HelloCenteredMeasured : Form
{
    public static void Main()
    {
        Application.Run(new HelloCenteredMeasured());
    }

    public HelloCenteredMeasured()
    {
        Text = "Hello Centered Using MeasureString";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics grfx = e.Graphics;

        string str = "Hello, world!";
        SizeF sizefText = grfx.MeasureString(str, Font);

        grfx.DrawString(str, Font, new SolidBrush(ForeColor),
            (ClientSize.Width - sizefText.Width)/2,
            (ClientSize.Height - sizefText.Height)/2);
    }
}