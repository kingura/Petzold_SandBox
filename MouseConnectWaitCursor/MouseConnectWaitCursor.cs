using System;
using System.Drawing;
using System.Windows.Forms;

class MouseConnectWaitCursor : MouseConnect
{
    static new void Main()
    {
        Application.Run(new MouseConnectWaitCursor());
    }
    public MouseConnectWaitCursor()
    {
        Text = "MouseConnectWaitCursor";
    }
    protected override void OnPaint(PaintEventArgs pea)
    {
        Cursor.Current = Cursors.WaitCursor;
        Cursor.Show();

        base.OnPaint(pea);

        Cursor.Hide();
        Cursor.Current = Cursors.Arrow;
    }
}
