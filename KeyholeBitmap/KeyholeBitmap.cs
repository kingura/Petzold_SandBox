using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

class KeyholeBitmap : PrintableForm
{
  Bitmap bitmap;

  public new static void Main()
  {
    Application.Run(new KeyholeBitmap());
  }
  public KeyholeBitmap()
  {
    Text = "Keyhole Bitmap";

    // Загрузка изображения

    Image image = Image.FromFile(
         "..\\..\\..\\Apollo11FullColor_220x240.jpg");

    // Создание контура отсечения

    GraphicsPath path = new GraphicsPath();
    path.AddArc(80, 0, 80, 80, 45, -270);
    path.AddLine(70, 180, 170, 180);

    // Получение размера контура отсечения

    RectangleF rectf = path.GetBounds();

    // Создание нового прозрачного растра

    bitmap = new Bitmap((int)rectf.Width, (int)rectf.Height,
                        PixelFormat.Format32bppArgb);

    // Создание объекта Graphics на основе нового растра

    Graphics grfx = Graphics.FromImage(bitmap);

    // Рисуем исходное изображение на растр с отсечением

    grfx.SetClip(path);
    grfx.TranslateClip(-rectf.X, -rectf.Y);
    grfx.DrawImage(image, (int)-rectf.X, (int)-rectf.Y,
                           image.Width, image.Height);
    grfx.Dispose();
  }
  protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
  {
    grfx.DrawImage(bitmap, (cx - bitmap.Width) / 2,
                           (cy - bitmap.Height) / 2,
                           bitmap.Width, bitmap.Height);
  }
}