using System;
using System.Drawing;
using System.Windows.Forms;

class BetterContextMenu : Form
{
  MenuItemColor miColor;

  public static void Main()
  {
    Application.Run(new BetterContextMenu());
  }

  public BetterContextMenu()
  {
    Text = "Better Context Menu Demo";

    EventHandler eh = new EventHandler(MenuColorOnClick);

    MenuItemColor[] amic =
    {
      new MenuItemColor(Color.Black, "&Black", eh),
      new MenuItemColor(Color.Blue, "B&lue", eh),
      new MenuItemColor(Color.Green, "&Green", eh),
      new MenuItemColor(Color.Cyan, "&Cyan", eh),
      new MenuItemColor(Color.Red, "&Red", eh),
      new MenuItemColor(Color.Magenta, "&Magenta", eh),
      new MenuItemColor(Color.Yellow, "&Yellow", eh),
      new MenuItemColor(Color.White, "&White", eh)
    };

    foreach (MenuItemColor mi in amic)
      mi.RadioCheck = true;

    miColor = amic[3];
    miColor.Checked = true;
    BackColor = miColor.Color;

    ContextMenu = new ContextMenu(amic);
  }

  void MenuColorOnClick(object obj, EventArgs e)
  {
    miColor.Checked = false;
    miColor = (MenuItemColor)obj;
    miColor.Checked = true;

    BackColor = miColor.Color;
  }
}

class MenuItemColor : MenuItem
{
  Color clr;

  public MenuItemColor(Color clr, string str, EventHandler eh) : base(str, eh)
  {
    Color = clr;
  }

  public Color Color
  {
    get { return clr; }
    set { clr = value; }
  }
}