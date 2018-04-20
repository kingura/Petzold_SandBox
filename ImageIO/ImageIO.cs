using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

class ImageIO: ImageOpen
{
  MenuItem miSaveAs;

  [STAThread]
  public new static void Main()
  {
    Application.Run(new ImageIO());
  }

  public ImageIO()
  {
    Text = strProgName = "Image I/O";

    Menu.MenuItems[0].Popup += new EventHandler(MenuFileOnPopup);
    miSaveAs = new MenuItem("Save &As...");
    miSaveAs.Click += MenuFileSaveAsOnClick;
    Menu.MenuItems[0].MenuItems.Add(miSaveAs);
  }

  private void MenuFileOnPopup(object sender, EventArgs e)
  {
    miSaveAs.Enabled = (image != null);
  }

  private void MenuFileSaveAsOnClick(object sender, EventArgs e)
  {
    SaveFileDialog savedlg = new SaveFileDialog();

    savedlg.InitialDirectory = Path.GetDirectoryName(strFileName);
    savedlg.FileName = Path.GetFileNameWithoutExtension(strFileName);
    savedlg.AddExtension = true;
    savedlg.Filter = "Windows Bitmap (*.bmp)|*.bmp|" +
                     "Graphics Interchange Format (*.gif)|*.gif|" +
                     "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg;*.jfif|" +
                     "Portable Network Graphics (*.png)|*.png|" +
                     "Tagged Imaged File Format (*.tif)|*.tif;*.tiff";

    ImageFormat[] aif = { ImageFormat.Bmp, ImageFormat.Gif, ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Tiff };

    if (savedlg.ShowDialog() == DialogResult.OK)
    {
      try
      {
        image.Save(savedlg.FileName, aif[savedlg.FilterIndex - 1]);
      }
      catch (Exception exc)
      {
        MessageBox.Show(exc.Message, Text);
        return;
      }
      strFileName = savedlg.FileName;
      Text = strProgName + " - " + Path.GetFileName(strFileName);
    }
  } 
}