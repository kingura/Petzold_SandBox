using System;
using System.Drawing;
using System.Windows.Forms;

class TextBoxDemo : Form
{
  Label label;

  public static void Main()
  {
    Application.Run(new TextBoxDemo());
  }

  public TextBoxDemo()
  {
    Text = "TextBox Demo";

    // Создаем текстовое поле.

    TextBox txtbox = new TextBox();
    txtbox.Parent = this;
    txtbox.Location = new Point(Font.Height, Font.Height);
    txtbox.Size = new Size(ClientSize.Width - 2 * Font.Height, Font.Height);
    txtbox.Anchor |= AnchorStyles.Right;
    txtbox.TextChanged += new EventHandler(TextBoxOnTextChanged);

    // Создаём надпись.

    label = new Label();
    label.Parent = this;
    label.Location = new Point(Font.Height, 3 * Font.Height);
    label.AutoSize = true;
  }

  void TextBoxOnTextChanged(object obj, EventArgs e)
  {
    TextBox txtbox = (TextBox)obj;
    label.Text = txtbox.Text;
  }
}