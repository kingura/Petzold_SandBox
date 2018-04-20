using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

class ImageOpen : Form
{
  protected string strProgName;
  protected string strFileName;
  protected Image image;

  [STAThread] // for correct working of OpenFileDialog
  public static void Main()
  {
    Application.Run(new ImageOpen());
  }

  public ImageOpen()
  {
    Text = strProgName = "Image Open";
    ResizeRedraw = true;

    Menu = new MainMenu();
    Menu.MenuItems.Add("&File");
    Menu.MenuItems[0].MenuItems.Add(new MenuItem("&Open...", new EventHandler(MenuFileOpenOnClick), Shortcut.CtrlO));
  }

  private void MenuFileOpenOnClick(object sender, EventArgs e)
  {
    OpenFileDialog dlg = new OpenFileDialog();

    dlg.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;" +
                              "*.jfif;*.png;*.tif;*.tiff;*.wmf;*.emf|" +
                       "Windows Bitmap (*.bmp)|*.bmp|" +
                       "Windows Icon (*.ico)|*.ico|" +
                       "Graphics Interchange Format (*.gif)|*.gif|" +
                       "JPEG File Interchange Format (*.jpg)|" +
                              "*.jpg;*.jpeg;*.jfif|" +
                       "Portable Network Graphics (*.png)|*.png|" +
                       "Tag Image File Format (*.tif)|*.tif;*.tiff|" +
                       "Windows Metafile (*.wmf)|*.wmf|" +
                       "Enhanced Metafile (*.emf)|*.emf|" +
                       "All Files (*.*)|*.*";
    if (dlg.ShowDialog() == DialogResult.OK)
    {
      try
      {
        image = Image.FromFile(dlg.FileName);
      }
      catch (Exception exc)
      {
        MessageBox.Show(exc.Message, strProgName);
        return;
      }
      strFileName = dlg.FileName;
      Text = strProgName + " - " + Path.GetFileName(strFileName);
      Invalidate();
    }
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics grfx = e.Graphics;

    if (image != null)
      grfx.DrawImage(image, 0, 0);
  }
}