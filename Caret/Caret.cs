using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Petzold.ProgrammingWindowsWithCSharp
{
    public class Caret
    {
        [DllImport("user32.dll")]
        public static extern int CreateCaret(IntPtr hwnd, IntPtr hbm, int cx, int cy);

        [DllImport("user32.dll")]
        public static extern int DestroyCaret();

        [DllImport("user32.dll")]
        public static extern int SetCaretPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern int ShowCaret(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int SetCaretBlinkTime(uint uMSeconds);

        [DllImport("user32.dll")]
        public static extern int HideCaret(IntPtr hwnd);

        // Поля

        Control ctrl;
        Size size;
        Point ptPos;
        bool bVisible;

        // Конструкторы

        // Конструктор по умолчанию недоступен
        private Caret()
        {
        }

        // Доступен только конструктор с аргументом Control

        public Caret(Control ctrl)
        {
            this.ctrl = ctrl;
            Position = Point.Empty;
            Size = new Size(1, ctrl.Font.Height);

            Control.GotFocus += new EventHandler(ControlOnGotFocus);
            Control.LostFocus += new EventHandler(ControlOnLostFocus);

            // Если элемент управления имеет фокус, создаем каретку

            if (ctrl.Focused)
                ControlOnGotFocus(ctrl, new EventArgs());
        }

        // Свойства

        public Control Control
        {
            get { return ctrl; }
        }

        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        public Point Position
        {
            get { return ptPos; }
            set
            {
                ptPos = value;
                SetCaretPos(ptPos.X, ptPos.Y);
            }
        }

        public bool Visibility
        {
            get { return bVisible; }
            set
            {
                if (bVisible = value)
                    ShowCaret(ctrl.Handle);
                else
                    HideCaret(ctrl.Handle);
            }
        }

        // Методы

        public void Show()
        {
            Visibility = true;
        }

        public void Hide()
        {
            Visibility = false;
        }

        public void Dispose()
        {
            // Если элемент управления имеет фокус, уничтожаем каретку
            if (ctrl.Focused)
                ControlOnLostFocus(ctrl, new EventArgs());

            Control.GotFocus -= new EventHandler(ControlOnGotFocus);
            Control.LostFocus -= new EventHandler(ControlOnLostFocus);
        }

        // Обработчики событий

        void ControlOnGotFocus(object obj, EventArgs ea)
        {
            CreateCaret(Control.Handle, IntPtr.Zero, Size.Width, Size.Height);
            SetCaretPos(Position.X, Position.Y);
            SetCaretBlinkTime(1200);
            Show();
        }

        void ControlOnLostFocus(object obj, EventArgs ea)
        {
            Hide();
            DestroyCaret();
        }

    }
}