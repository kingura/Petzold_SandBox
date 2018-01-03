using System;
using System.Drawing;
using System.Windows.Forms;

class JeuDeTaquinTile: UserControl
{
    int iNum;

    public JeuDeTaquinTile(int iNum)
    {
        this.iNum = iNum;
        Enabled = false;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;
        grfx.Clear(SystemColors.Control);

        int cx = this.Size.Width;
        int cy = Size.Height;
        int wx = SystemInformation.FrameBorderSize.Width;
        int wy = SystemInformation.FrameBorderSize.Height;

        grfx.FillPolygon(SystemBrushes.ControlLightLight,
            new Point[] {new Point(cx, 0), new Point(0, 0), new Point(0, cy)
                        ,new Point(wx, cy-wy), new Point(wx, wy), new Point(cx-wx, wy)});

        grfx.FillPolygon(SystemBrushes.ControlDark,
            new Point[] {new Point(cx, 0), new Point(cx, cy), new Point(0, cy)
                        ,new Point(wx, cy-wy), new Point(cx-wx, cy-wy), new Point(cx-wx, wy)});

        Font font = new Font("Arial", 24);
        StringFormat strfmt = new StringFormat();
        strfmt.Alignment = strfmt.LineAlignment = StringAlignment.Center;

        grfx.DrawString(iNum.ToString(), font, SystemBrushes.ControlText, ClientRectangle, strfmt);
    }
}