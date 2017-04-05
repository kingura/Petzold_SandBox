using System.Drawing;
using System.Windows.Forms;

class FourCorners : Form
{
    public static void Main()
    {
        Application.Run(new FourCorners());
    }

    public FourCorners ()
    {
        Text = "Four Corners Text Alignment";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics grfx = e.Graphics;
        Brush brush = new SolidBrush(ForeColor);
        StringFormat strfrm = new StringFormat();

        strfrm.Alignment = StringAlignment.Near;
        strfrm.LineAlignment = StringAlignment.Near;
        grfx.DrawString("Верхний левый угол", Font, brush, 0, 0, strfrm);

        strfrm.Alignment = StringAlignment.Far;
        strfrm.LineAlignment = StringAlignment.Near;
        grfx.DrawString("Верхний правый угол", Font, brush, ClientSize.Width, 0, strfrm);

        strfrm.Alignment = StringAlignment.Near;
        strfrm.LineAlignment = StringAlignment.Far;
        grfx.DrawString("Нижний левый угол", Font, brush, 0, ClientSize.Height, strfrm);

        strfrm.Alignment = StringAlignment.Far;
        strfrm.LineAlignment = StringAlignment.Far;
        grfx.DrawString("Нижний правый угол", Font, brush, ClientSize.Width, ClientSize.Height, strfrm);
    }
}