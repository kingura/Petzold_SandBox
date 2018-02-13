using System;
using System.Drawing;
using System.Windows.Forms;

class CheckBoxDemo : Form
{
    public static void Main()
    {
        Application.Run(new CheckBoxDemo());
    }

    public CheckBoxDemo()
    {
        Text = "CheckBox Demo";

        CheckBox[] achkbox = new CheckBox[4];
        int cyText = Font.Height;
        int cxText = cyText/2;
        string[] astrText = {"Bold", "Italic", "Underline", "Strikeout"};

        for (int i = 0; i < 4; i++)
        {
            achkbox[i] = new CheckBox();
            achkbox[i].Text = astrText[i];

            //achkbox[i].Parent = this;

            achkbox[i].Location = new Point(2*cxText, (4 + 3*i)*cyText/2);
            achkbox[i].Size = new Size(12*cxText, cyText);
            achkbox[i].CheckedChanged += new EventHandler(CheckBoxOnCheckedChanged);
        }
        Controls.AddRange(achkbox);
    }

    void CheckBoxOnCheckedChanged(object obj, EventArgs e)
    {
        Invalidate(false);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics grfx = e.Graphics;
        FontStyle fs = 0;
        FontStyle[] afs = {FontStyle.Bold, FontStyle.Italic, FontStyle.Underline, FontStyle.Strikeout};
        
        for (int i = 0; i < 4; i++)
            if (((CheckBox) Controls[i]).Checked) fs |= afs[i];

        Font font = new Font(Font, fs);
        grfx.DrawString(Text, font, new SolidBrush(ForeColor), 0, 0);
    }
}