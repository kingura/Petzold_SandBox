using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

class TextColumns : PrintableForm
{
    public new static void Main()
    {
        Application.Run(new TextColumns());
    }

    public TextColumns()
    {
        Text = "Edith Wharton's \"The Age of Innocence\"";
        Font = new Font("Times New Roman", 10);
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        Brush brush = new SolidBrush(clr);
        int iChars, iLines;
        string str = AgeOfInnocence.Text;
        StringFormat strfmt = new StringFormat();

        // Делаем пункты единицами измерения для преобразования размеров
        PointF[] aptf = { new PointF(cx, cy) };
        grfx.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, aptf);
        grfx.PageUnit = GraphicsUnit.Point;
        grfx.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, aptf);
        float fcx = aptf[0].X;
        float fcy = aptf[0].Y;

        // Свойства, флаги и позиции табуляции StringFormat

        strfmt.HotkeyPrefix = HotkeyPrefix.Show;
        strfmt.Trimming = StringTrimming.Word;
        strfmt.FormatFlags |= StringFormatFlags.NoClip;
        strfmt.SetTabStops(0, new float[] { 18 });

        // Отображение текста

        for (int x = 0; x < fcx && str.Length > 0; x += 156)
        {
            RectangleF rectf = new RectangleF(x, 0, 144, fcy - Font.GetHeight(grfx));
            grfx.DrawString(str, Font, brush, rectf, strfmt);
            grfx.MeasureString(str, Font, rectf.Size, strfmt, out iChars, out iLines);
            str = str.Substring(iChars);
        }
    }
}