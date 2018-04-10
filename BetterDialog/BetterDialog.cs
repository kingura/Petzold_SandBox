using System;
using System.Drawing;
using System.Windows.Forms;

class BetterDialog : Form
{
  string strDisplay = "";

  public static void Main()
  {
    Application.Run(new BetterDialog());
  }

  public BetterDialog()
  {
    Text = "Better Dialog";

    Menu = new MainMenu();
    Menu.MenuItems.Add("&Dialog!", new EventHandler(MenuOnClick));
  }

  void MenuOnClick(object sender, EventArgs e)
  {
    BetterDialogBox dlg = new BetterDialogBox();
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

class BetterDialogBox : Form
{
  public BetterDialogBox()
  {
    Text = "Simple Dialog Box";

    // Стандартное оформление диалоговых окон

    FormBorderStyle = FormBorderStyle.FixedDialog;
    ControlBox = false;
    MaximizeBox = false;
    MinimizeBox = false;
    ShowInTaskbar = false;
    StartPosition = FormStartPosition.Manual;
    Location = ActiveForm.Location +
               SystemInformation.CaptionButtonSize +
               SystemInformation.FrameBorderSize;

    // Создаем кнопку ОК

    Button btn = new Button();
    btn.Parent = this;
    btn.Text = "OK";
    btn.Location = new Point(50, 50);
    btn.Size = new Size(10 * Font.Height, 2 * Font.Height);
    btn.DialogResult = DialogResult.OK;

    AcceptButton = btn;

    // Создаем кнопку Cancel

    btn = new Button();
    btn.Parent = this;
    btn.Text = "Cancel";
    btn.Location = new Point(50, 100);
    btn.Size = new Size(10 * Font.Height, 2 * Font.Height);
    btn.DialogResult = DialogResult.Cancel;

    CancelButton = btn;
  }
}
