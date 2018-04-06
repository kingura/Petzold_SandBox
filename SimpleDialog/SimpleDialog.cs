using System;
using System.Drawing;
using System.Windows.Forms;

class SimpleDialog : Form
{
  string strDisplay = "";

  public static void Main()
  {
    Application.Run(new SimpleDialog());
  }

  public SimpleDialog()
  {
    Text = "Simple Dialog";

    Menu = new MainMenu();
    Menu.MenuItems.Add("&Dialog!", new EventHandler(MenuOnClick));
  }

  void MenuOnClick(object sender, EventArgs e)
  {
    SimpleDialogBox dlg = new SimpleDialogBox();

    dlg.ShowDialog();

    strDisplay = "Dialog box terminated with " + dlg.DialogResult + "!";

    Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics grfx = e.Graphics;
    grfx.DrawString(strDisplay, Font, new SolidBrush(ForeColor), 0, 0);
  }
}

class SimpleDialogBox : Form
{
  public SimpleDialogBox()
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
    btn.Click += new EventHandler(ButtonOkOnClick);

    // Создаем кнопку Cancel

    btn = new Button();
    btn.Parent = this;
    btn.Text = "Cancel";
    btn.Location = new Point(50, 100);
    btn.Size = new Size(10 * Font.Height, 2 * Font.Height);
    btn.Click += new EventHandler(ButtonCancelOnClick);
  }

  private void ButtonOkOnClick(object sender, EventArgs e)
  {
    DialogResult = DialogResult.OK;
  }

  private void ButtonCancelOnClick(object sender, EventArgs e)
  {
    DialogResult = DialogResult.Cancel;
  }
}
