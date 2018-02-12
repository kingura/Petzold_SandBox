using System;
using System.Drawing;
using System.Windows.Forms;

class TwoButtonsDock : Form
{
  public static void Main()
  {
    Application.Run(new TwoButtonsDock());
  }

  public TwoButtonsDock()
  {
    Text = "Two Buttons Dock";
    ResizeRedraw = true;

    Button btn = new Button();
    btn.Parent = this;
    btn.Text = "&Larger";
    btn.Height = 2 * Font.Height;
    btn.Dock = DockStyle.Top;
    btn.Click += ButtonLargerOnClick;

    btn = new Button();
    btn.Parent = this;
    btn.Text = "&Smaller";
    btn.Height = 2 * Font.Height;
    btn.Dock = DockStyle.Bottom;
    btn.Click += ButtonSmallerOnClick;
  }

  void ButtonLargerOnClick(object obj, EventArgs e)
  {
    Left -= (int)(0.05 * Width);
    Top -= (int)(0.05 * Height);
    Width += (int)(0.1 * Width);
    Height += (int)(0.1 * Height);
  }

  void ButtonSmallerOnClick(object obj, EventArgs e)
  {
    Left += (int)(Width / 22f);
    Top += (int)(Height / 22f);
    Width -= (int)(Width / 11f);
    Height -= (int)(Height / 11f);
  }
}