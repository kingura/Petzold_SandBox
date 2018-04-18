using System;
using System.Drawing;
using System.Windows.Forms;

class FontAndColorDialogs : Form
{
  public static void Main()
  {
    Application.Run(new FontAndColorDialogs());
  }

  public FontAndColorDialogs()
  {
    Text = "Font and Color Dialogs";
    ResizeRedraw = true;

    Menu = new MainMenu();
    Menu.MenuItems.Add("&Format");
    Menu.MenuItems[0].MenuItems.Add("&Font...", new EventHandler(MenuFontOnClick));
    Menu.MenuItems[0].MenuItems.Add("&Background Color...", new EventHandler(MenuColorOnClick));
  }

  private void MenuFontOnClick(object sender, EventArgs e)
  {
    FontDialog fontdlg = new FontDialog();

    fontdlg.Font = Font;
    fontdlg.Color = ForeColor;
    fontdlg.ShowColor = true;
    //fontdlg.ShowEffects = false;

    if (fontdlg.ShowDialog() == DialogResult.OK)
    {
      Font = fontdlg.Font;
      ForeColor = fontdlg.Color;
      Invalidate();
    }
  }

  private void MenuColorOnClick(object sender, EventArgs e)
  {
    ColorDialog clrdlg = new ColorDialog();

    clrdlg.Color = BackColor;

    if (clrdlg.ShowDialog() == DialogResult.OK)
      BackColor = clrdlg.Color;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics grfx = e.Graphics;
    StringFormat strfmt = new StringFormat();

    strfmt.Alignment = strfmt.LineAlignment = StringAlignment.Center;

    grfx.DrawString("Hello common dialog boxes!", Font, new SolidBrush(ForeColor), this.ClientRectangle, strfmt);
  }
}