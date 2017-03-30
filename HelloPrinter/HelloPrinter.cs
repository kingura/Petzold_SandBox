using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

class HelloPrinter : Form
{
    static void Main()
    {
        Application.Run(new HelloPrinter());
    }

    public HelloPrinter()
    {
        Text = "HelloPrinter";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs pea)
    {
        // base.OnPaint(e);

        Graphics grfx = pea.Graphics;
        Brush brush = new SolidBrush(ForeColor);

        StringFormat strfmt = new StringFormat();
        strfmt.Alignment = strfmt.LineAlignment = StringAlignment.Center;
        //strfmt.Alignment = StringAlignment.Center;
        //strfmt.LineAlignment = StringAlignment.Center;

        grfx.DrawString("ВНИМАНИЕ! При клике на форме распечатается на принтере по-умолчанию фраза HelloPrinter.", Font, brush, ClientRectangle, strfmt);
    }

    protected override void OnClick(EventArgs ea)
    {
        //base.OnClick(ea);

        PrintDocument prndoc = new PrintDocument();

        prndoc.DocumentName = Text;
        prndoc.PrintPage += new PrintPageEventHandler(PrintDocumentOnPrintPage);
        prndoc.Print();
    }

    private void PrintDocumentOnPrintPage(object obj, PrintPageEventArgs ppea)
    {
        // throw new NotImplementedException();

        Graphics grfx = ppea.Graphics;

        grfx.DrawString(Text, Font, Brushes.Black, 0, 0);

        SizeF sizef = grfx.MeasureString(Text, Font);

        grfx.DrawLine(Pens.Black, sizef.ToPointF(), grfx.VisibleClipBounds.Size.ToPointF());
    }
}