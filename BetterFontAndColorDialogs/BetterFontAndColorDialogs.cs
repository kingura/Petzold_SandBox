using System;
using System.Drawing;
using System.Windows.Forms;

class BetterFontAndColorDialogs : Form
{
    protected ColorDialog clrdlg = new ColorDialog();

    public static void Main()
    {
        Application.Run(new BetterFontAndColorDialogs());
    }

    public BetterFontAndColorDialogs()
    {
        Text = "Better Font and Color Dialogs";
        //ResizeRedraw = true;

        Menu = new MainMenu();
        Menu.MenuItems.Add("&Format");
        Menu.MenuItems[0].MenuItems.Add("&Font...", new EventHandler(MenuFontOnClick));
        Menu.MenuItems[0].MenuItems.Add("&Background Color...", new EventHandler(MenuColorOnClick));
    }

    private void MenuFontOnClick(object sender, EventArgs e)
    {
        FontDialog fontdlg = new FontDialog();

        fontdlg.Font = Font;
        fontdlg.Color = ForeColor;
        fontdlg.ShowColor = true;
        fontdlg.ShowApply = true;
        fontdlg.Apply += new EventHandler(FontDialogOnApply);

        if (fontdlg.ShowDialog() == DialogResult.OK)
        {
            Font = fontdlg.Font;
            ForeColor = fontdlg.Color;
            Invalidate();
        }
    }

    private void MenuColorOnClick(object sender, EventArgs e)
    {
        clrdlg.Color = BackColor;

        if (clrdlg.ShowDialog() == DialogResult.OK)
            BackColor = clrdlg.Color;
    }

    void FontDialogOnApply(object obj, EventArgs ea)
    {
        FontDialog fontdlg = (FontDialog) obj;

        Font = fontdlg.Font;
        ForeColor = fontdlg.Color;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;
        grfx.DrawString("Hello common dialog boxes!", Font, new SolidBrush(ForeColor), 0, 0);
    }
}