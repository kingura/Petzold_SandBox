using System.Drawing;
using System.Windows.Forms;

class XMarksTheSpot : Form
{
    static void Main()
    {
        Application.Run(new XMarksTheSpot());
    }

    public XMarksTheSpot()
    {
        Text = "X Marks The Spot";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        //base.OnPaint(e);
        Graphics grfx = e.Graphics;
        Pen pen = new Pen(ForeColor);

        grfx.DrawLine(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        grfx.DrawLine(pen, 0, ClientSize.Height - 1, ClientSize.Width - 1, 0);
    }

}