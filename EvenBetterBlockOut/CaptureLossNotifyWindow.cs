using System;
using System.Drawing;
using System.Windows.Forms;

interface ICaptureLossNotify
{
    void OnLostCapture();
}

class CaptureLossNotifyWindow: NativeWindow
{
    public ICaptureLossNotify control;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 533) // WM_CAPTURECHANGED
            control.OnLostCapture();

        base.WndProc(ref m);
    }
}