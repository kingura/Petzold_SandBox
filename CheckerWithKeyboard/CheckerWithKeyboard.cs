using System;
using System.Drawing;
using System.Windows.Forms;

class CheckerWithKeyboard: Checker
{
    public new static void Main()
    {
        Application.Run(new CheckerWithKeyboard());
    }

    public CheckerWithKeyboard()
    {
        Text += " with Keyboard Interface";
    }

    protected override void OnGotFocus(EventArgs e)
    {
        Cursor.Show();
    }

    protected override void OnLostFocus(EventArgs e)
    {
        Cursor.Hide();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        Point ptCursor = PointToClient(Cursor.Position);

        int x = Math.Max(0, Math.Min(xNum - 1, ptCursor.X / cxBlock));
        int y = Math.Max(0, Math.Min(yNum - 1, ptCursor.Y / cyBlock));

        switch (e.KeyCode)
        {
            case Keys.Up:   y--; break;
            case Keys.Down: y++; break;
            case Keys.Left: x--; break;
            case Keys.Right: x++; break;

            case Keys.Home: x = y = 0; break;
            case Keys.End: x = xNum - 1; y = yNum - 1; break;

            case Keys.Enter:
            case Keys.Space:
                abChecked[x, y] ^= true;
                Invalidate(new Rectangle(x * cxBlock, y * cyBlock, cxBlock, cyBlock));
                return;

            default:
                return;
        }
        x = (x + xNum) % xNum;
        y = (y + yNum) % yNum;

        Cursor.Position = PointToScreen(new Point(x * cxBlock + cxBlock / 2, y * cyBlock + cyBlock / 2));
    }
}