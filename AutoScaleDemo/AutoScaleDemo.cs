﻿using System;
using System.Drawing;
using System.Windows.Forms;

class AutoScaleDemo : Form
{
  public static void Main()
  {
    Application.EnableVisualStyles();
    Application.Run(new AutoScaleDemo());
  }

  public AutoScaleDemo()
  {
    Text = "Auto-Scale Demo";
    Font = new Font("Arial", 12);
    FormBorderStyle = FormBorderStyle.FixedSingle;

    int[] aiPointSize = { 8, 12, 16, 24, 32 };

    for (int i = 0; i < aiPointSize.Length; i++)
    {
      Button btn = new Button();
      btn.Parent = this;
      btn.Text = "Use " + aiPointSize[i] + "-point font";
      btn.Tag = aiPointSize[i];
      btn.Location = new Point(4, 16 + 24 * i);
      btn.Size = new Size(80, 16);
      btn.Click += ButtonOnClick;
    }
    ClientSize = new Size(88, 16 + 24 * aiPointSize.Length);
    AutoScaleBaseSize = new Size(4, 8);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 0, 0);
  }

  void ButtonOnClick(object obj, EventArgs e)
  {
    Button btn = (Button)obj;

#pragma warning disable CS0618 // Type or member is obsolete
    SizeF sizefOld = GetAutoScaleSize(Font);
    Font = new Font(Font.FontFamily, (int)btn.Tag);
    SizeF sizefNew = GetAutoScaleSize(Font);

    Scale(sizefNew.Width / sizefOld.Width, sizefNew.Height / sizefOld.Height);
#pragma warning restore CS0618 // Type or member is obsolete
  }

}