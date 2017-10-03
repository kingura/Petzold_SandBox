using System;
using System.Drawing;
using System.Windows.Forms;

class StringAlignmentPoint : PrintableForm
{
    public new static void Main()
    {
        Application.Run(new StringAlignmentPoint());
    }

    public StringAlignmentPoint()
    {
        Text = "String Alignment (PointF in DrawString)";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        Brush brush = new SolidBrush(clr);
        Pen pen = new Pen(clr);
        PointF pointf = new PointF(cx / 2, cy / 2);
        string[] strAlign = { "Near", "Center", "Far" };
        StringFormat strfmt = new StringFormat();

        grfx.DrawLine(pen, 0, cy / 2, cx, cy / 2);
        grfx.DrawLine(pen, cx / 2, 0, cx / 2, cy);

        for (int iVert = 1; iVert < 3; iVert += 2) // for (int iVert = 0; iVert < 3; iVert += 2)
            for (int iHorz = 1; iHorz < 3; iHorz += 2)  // for (int iHorz = 0; iHorz < 3; iHorz += 2)
            {
                strfmt.Alignment = (StringAlignment)iHorz;
                strfmt.LineAlignment = (StringAlignment)iVert;

                grfx.DrawString(String.Format("LineAlignment = {0}\nAlignment = {1}", strAlign[iVert], strAlign[iHorz]), Font, brush, pointf, strfmt);
            }
    }
}