using System;
using System.Drawing;
using System.Windows.Forms;

class BitmapButtons : Form
{
  readonly int cxBtn, cyBtn, dxBtn;
  readonly Button btnLarger, btnSmaller;

  public static void Main()
  {
    Application.Run(new BitmapButtons());
  }

  public BitmapButtons()
  {
    Text = "Bitmap Buttons";
    ResizeRedraw = true;

    dxBtn = Font.Height;

    // Создаем первую кнопку

    btnLarger = new Button();
    btnLarger.Parent = this;
    btnLarger.Image = new Bitmap(GetType(), "BitmapButtons.LargerButton.bmp");

    // Вычисляем размеры кнопки по размеру изображения
    cxBtn = btnLarger.Image.Width;
    cyBtn = btnLarger.Image.Height;

    btnLarger.Size = new Size(cxBtn, cyBtn);
    btnLarger.Click += new EventHandler(ButtonLargerOnClick);

    // Создаем вторую кнопку

    btnSmaller = new Button();
    btnSmaller.Parent = this;
    btnSmaller.Image = new Bitmap(GetType(), "BitmapButtons.SmallerButton.bmp");
    btnSmaller.Size = new Size(cxBtn, cyBtn);
    btnSmaller.Click += new EventHandler(ButtonSmallerOnClick);

    OnResize(EventArgs.Empty);
  }

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);

    btnLarger.Location =
      new Point(ClientSize.Width / 2 - cxBtn - dxBtn/2,
               (ClientSize.Height - cyBtn) / 2);

    btnSmaller.Location =
      new Point((ClientSize.Width + dxBtn) / 2,
                (ClientSize.Height - cyBtn) / 2);
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