using System;
using System.Drawing;
using System.Windows.Forms;

namespace SandBox
{
    public class FormCode
    {
        public static void Main()
        {
            Form form = new Form();

            form.Text = "Загаловак";
            form.BackColor = Color.White;
            form.Paint += new PaintEventHandler(MyPaintHandler);

            Application.Run(form);
        }

        static void MyPaintHandler(object objSender, PaintEventArgs pea)
        {
            //Console.WriteLine("RePaint");

            Graphics grfx = pea.Graphics;
            //grfx.Clear(Color.Chocolate);
            Form tform = (Form)objSender;
            Font font = tform.Font;
            Brush brush = Brushes.Black;
            grfx.DrawString("Igor said", font, brush, 0, 0);
        }
    }
}