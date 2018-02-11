using System;
using System.Drawing;
using System.Windows.Forms;

class TwoButtonsAnchor : Form
{
  public static void Main()
  {
    Application.Run(new TwoButtonsAnchor());
  }

  public TwoButtonsAnchor()
  {
    Text = "Two Buttons Anchor";
    ResizeRedraw = true;

    int cxBtn = 5 * Font.Height;
    int cyBtn = 2 * Font.Height;
    int dxBtn = Font.Height;

    Button btn = new Button();
    btn.Parent = this;
    btn.Text = "&Larger";
    btn.Location = new Point(dxBtn, dxBtn);
    btn.Size = new Size(cxBtn, cyBtn);
    btn.Click += new EventHandler(ButtonLargerOnClick);

    btn = new Button();
    btn.Parent = this;
    btn.Text = "&Smaller";
    btn.Location = new Point(ClientSize.Width - dxBtn - cxBtn, ClientSize.Height - dxBtn - cyBtn);
    btn.Size = new Size(cxBtn, cyBtn);
    btn.Click += new EventHandler(ButtonSmallerOnClick);
    btn.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
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