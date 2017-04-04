using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

class AntiAlias: Form
{
    public static void Main()
    {
        Application.Run(new AntiAlias());
    }

    public AntiAlias()
    {
        Text = "Anti-Alias Demo";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics grfx = e.Graphics;
        Pen pen = new Pen(ForeColor);

        grfx.SmoothingMode = SmoothingMode.AntiAlias;
        grfx.PixelOffsetMode = PixelOffsetMode.HighQuality;

        grfx.DrawLine(pen, 2, 2, 18, 10);
    }
}