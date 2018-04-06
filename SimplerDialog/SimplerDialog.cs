using System;
using System.Drawing;
using System.Windows.Forms;

class SimplerDialog : Form
{
  string strDisplay = "";

  public static void Main()
  {
    Application.Run(new SimplerDialog());
  }

  public SimplerDialog()
  {
    Text = "Simpler Dialog";

    Menu = new MainMenu();
    Menu.MenuItems.Add("&Dialog!", new EventHandler(MenuOnClick));
  }

  void MenuOnClick(object sender, EventArgs e)
  {
    SimplerDialogBox dlg = new SimplerDialogBox();
    DialogResult dr = dlg.ShowDialog();

    strDisplay = "Dialog box terminated with " + dr + "!";
    Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics grfx = e.Graphics;
    grfx.DrawString(strDisplay, Font, new SolidBrush(ForeColor), 0, 0);
  }
}

class SimplerDialogBox : Form
{
  public SimplerDialogBox()
  {
    Text = "Simple Dialog Box";

    // Стандартное оформление диалоговых окон

    FormBorderStyle = FormBorderStyle.FixedDialog;
    ControlBox = false;
    MaximizeBox = false;
    MinimizeBox = false;
    ShowInTaskbar = false;

    // Создаем кнопку ОК

    Button btn = new Button();
    btn.Parent = this;
    btn.Text = "OK";
    btn.Location = new Point(50, 50);
    btn.Size = new Size(10 * Font.Height, 2 * Font.Height);
    btn.DialogResult = DialogResult.OK;

    // Создаем кнопку Cancel

    btn = new Button();
    btn.Parent = this;
    btn.Text = "Cancel";
    btn.Location = new Point(50, 100);
    btn.Size = new Size(10 * Font.Height, 2 * Font.Height);
    btn.DialogResult = DialogResult.Cancel;
  }
}
