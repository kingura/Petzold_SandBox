﻿using System;
using System.Drawing;
using System.Windows.Forms;

class OutlineClientRectangle : PrintableForm
{
    static new void Main()
    {
        Application.Run(new OutlineClientRectangle());
    }

    public OutlineClientRectangle()
    {
        Text = "Outline Client Rectangle";
    }

    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        grfx.DrawRectangle(Pens.Red, 0, 0, cx - 1, cy - 1);
    }
}