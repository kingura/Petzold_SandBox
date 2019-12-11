﻿using System;
using System.Drawing;
using System.Windows.Forms;

class OnePanelWithSplitter : Form
{
  public static void Main()
  {
    Application.Run(new OnePanelWithSplitter());
  }

  public OnePanelWithSplitter()
  {
    Text = "One Panel with Splitter";

    Splitter splitter = new Splitter();
    splitter.Parent = this;
    splitter.Dock = DockStyle.Left;

    Panel panel = new Panel();
    panel.Parent = this;
    panel.Dock = DockStyle.Left;
    panel.BackColor = Color.Lime;
    panel.Resize += new EventHandler(PanelOnResize);
    panel.Paint += new PaintEventHandler(PanelOnPaint);
  }

  void PanelOnResize(object obj, EventArgs ea)
  {
    ((Panel) obj).Invalidate();
  }

  void PanelOnPaint(object obj, PaintEventArgs pea)
  {
    Panel panel = (Panel) obj;
    Graphics grfx = pea.Graphics;

    grfx.DrawEllipse(Pens.Black, 0, 0, panel.Width - 1, panel.Height - 1);

  }
}