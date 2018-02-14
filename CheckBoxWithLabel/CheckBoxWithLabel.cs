using System;
using System.Drawing;
using System.Windows.Forms;

class CheckBoxWithLabel : Form
{
    private Label label;

    public static void Main()
    {
        Application.Run(new CheckBoxWithLabel());
    }

    public CheckBoxWithLabel()
    {
        Text = "CheckBox Demo with Label";

        int cyText = Font.Height;
        int cxText = cyText / 2;
        string[] astrText = { "Bold", "Italic", "Underline", "Strikeout" };

        label = new Label();
        label.Parent = this;
        label.Text = Text + ": Sample Text";
        label.AutoSize = true;
        //label.BorderStyle = BorderStyle.Fixed3D;

        for (int i = 0; i < 4; i++)
        {
            CheckBox chkbox = new CheckBox();
            chkbox.Parent = this;
            chkbox.Text = astrText[i];
            chkbox.Location = new Point(2 * cxText, (4 + 3 * i) * cyText / 2);
            chkbox.Size = new Size(12 * cxText, cyText);
            chkbox.CheckedChanged += new EventHandler(CheckBoxOnCheckedChanged);
        }
    }

    void CheckBoxOnCheckedChanged(object obj, EventArgs e)
    {
        FontStyle fs = 0;
        FontStyle[] afs = { FontStyle.Bold, FontStyle.Italic, FontStyle.Underline, FontStyle.Strikeout };

        for (int i = 0; i < 4; i++)
            if (((CheckBox) Controls[i + 1]).Checked) fs |= afs[i];

        label.Font = new Font(label.Font, fs);
    }
}