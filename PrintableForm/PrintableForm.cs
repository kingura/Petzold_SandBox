using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

class PrintableForm : Form
{
    public static void Main()
    {
        Application.Run(new PrintableForm());
    }

    public PrintableForm()
    {
        Text = "Printable Form";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        DoPage(e.Graphics, ForeColor, ClientSize.Width, ClientSize.Height);
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        PrintDocument prndoc = new PrintDocument();

        prndoc.DocumentName = Text;
        prndoc.PrintPage += PrintDocumentOnPrintPage;
        prndoc.Print();
    }

    private void PrintDocumentOnPrintPage(object obj, PrintPageEventArgs ppea)
    {
        Graphics grfx = ppea.Graphics;
        SizeF sizef = grfx.VisibleClipBounds.Size;

        DoPage(grfx, Color.Black, (int)sizef.Width, (int)sizef.Height);
    }

    protected virtual void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        Pen pen = new Pen(clr);

        grfx.DrawLine(pen, 0, 0, cx - 1, cy - 1);
        grfx.DrawLine(pen, cx - 1, 0, 0, cy - 1);
    }
}