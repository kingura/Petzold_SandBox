﻿using System.Drawing;
using System.Windows.Forms;

class HelloCenteredRectangle : Form
{
    public static void Main()
    {
        Application.Run(new HelloCenteredRectangle());
    }

    public HelloCenteredRectangle()
    {
        Text = "Hello Centered Using Rectangle";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics grfx = e.Graphics;
        StringFormat strfmt = new StringFormat();

        strfmt.Alignment = StringAlignment.Center;
        strfmt.LineAlignment = StringAlignment.Center;

        grfx.DrawString("Hello, world!", Font, new SolidBrush(ForeColor), ClientRectangle, strfmt);
    }
}