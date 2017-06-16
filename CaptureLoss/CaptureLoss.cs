using System;
using System.Drawing;
using System.Windows.Forms;

class CaptureLoss: Form
{
    static public void Main()
    {
        Application.Run(new CaptureLoss());
    }
    public CaptureLoss()
    {
        Text = "Capture Loss";

        // Подключить объект NativeWindow
        CaptureLossWindow win = new CaptureLossWindow();
        win.form = this;
        win.AssignHandle(Handle);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        Invalidate();
    }
    public void OnLostCapture()
    {
        Invalidate();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;

        if (Capture)
            grfx.FillRectangle(Brushes.Red, ClientRectangle);
        else
            grfx.FillRectangle(Brushes.Gray, ClientRectangle);
    }
}

class CaptureLossWindow: NativeWindow
{
    public CaptureLoss form;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 533) // WM_CAPTURECHANGED
            form.OnLostCapture();

        base.WndProc(ref m);
    }
}