using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class KeyExamineWithScroll: KeyExamine
{
    public static void Main()
    {
        Application.Run(new KeyExamineWithScroll());
    }

    public KeyExamineWithScroll()
    {
        Text += " With Scroll";
    }

    // Объявление структуры прямоугольника в стиле Win32

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    // Объявление вызова ScrollWindow
    [DllImport("user32.dll")]
    public static extern int ScrollWindow(IntPtr hwnd, int cx, int cy, ref RECT rectScroll, ref RECT rectClip);

    // Переопределение методов в KeyExamine

    protected override void ScrollLines()
    {
        RECT rect;

        rect.left = 0;
        rect.top = Font.Height;
        rect.right = ClientSize.Width;
        rect.bottom = ClientSize.Height;

        ScrollWindow(Handle, 0, -Font.Height, ref rect, ref rect);
    }
}