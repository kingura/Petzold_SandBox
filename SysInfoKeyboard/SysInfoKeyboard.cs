using System;
using System.Drawing;
using System.Windows.Forms;

internal class SysInfoKeyboard : SysInfoReflection
{
    private new static void Main()
    {
        Application.Run(new SysInfoKeyboard());
    }

    public SysInfoKeyboard()
    {
        Text = "SysInfoKeyboard";
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        Point pt = AutoScrollPosition;
        pt.X = -pt.X;
        pt.Y = -pt.Y;

        switch (e.KeyCode)
        {
            case Keys.Left:
                if (e.Control)
                    pt.X -= ClientSize.Width;
                else
                    pt.X -= Font.Height;
                break;
            case Keys.Right:
                if ((e.Modifiers & Keys.Control) == Keys.Control)
                    pt.X += ClientSize.Width;
                else
                    pt.X += Font.Height;
                break;
            case Keys.Up:
                pt.Y -= cySpace;
                break;
            case Keys.Down:
                pt.Y += cySpace;
                break;

            case Keys.PageUp:
                pt.Y -= ClientSize.Height;
                break;
            case Keys.PageDown:
                pt.Y += ClientSize.Height;
                break;

            case Keys.Home:
                pt = Point.Empty;
                break;
            case Keys.End:
                pt = (Point) DisplayRectangle.Size;
                break;
        }

        AutoScrollPosition = pt;
    }
}