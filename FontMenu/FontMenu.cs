using System;
using System.Drawing;
using System.Windows.Forms;

class FontMenu : Form
{
  const int iPointSize = 24;
  string strFaceName;

  public static void Main()
  {
    Application.Run(new FontMenu());
  }

  public FontMenu()
  {
    Text = "Font Menu";

    strFaceName = Font.Name;

    Menu = new MainMenu();

    MenuItem mi = new MenuItem("&Facename");
    mi.Popup += new EventHandler(MenuFacenameOnPopup);
    mi.MenuItems.Add(" "); // Необходимо для события Popup
    Menu.MenuItems.Add(mi);
  }

  void MenuFacenameOnPopup(object obj, EventArgs e)
  {
    MenuItem miFacename = (MenuItem)obj;
    FontFamily[] aff = FontFamily.Families;
    EventHandler ehClick = new EventHandler(MenuFacenameOnClick);
    MenuItem[] ami = new MenuItem[aff.Length];

    for (int i = 0; i < aff.Length; i++)
    {
      ami[i] = new MenuItem(aff[i].Name);
      ami[i].Click += ehClick;

      if (aff[i].Name == strFaceName)
        ami[i].Checked = true;
    }
    miFacename.MenuItems.Clear();
    miFacename.MenuItems.AddRange(ami);
  }

  void MenuFacenameOnClick(object obj, EventArgs e)
  {
    MenuItem mi = (MenuItem)obj;
    strFaceName = mi.Text;
    Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics grfx = e.Graphics;
    Font font = new Font(strFaceName, iPointSize);

    StringFormat strfmt = new StringFormat();
    strfmt.Alignment = strfmt.LineAlignment = StringAlignment.Center;

    grfx.DrawString("Sample Text", font, new SolidBrush(ForeColor), ClientRectangle, strfmt);
  }
}