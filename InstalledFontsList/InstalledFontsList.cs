using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

class InstalledFontsList : FamiliesList
{
    public new static void Main()
    {
        Application.Run(new InstalledFontsList());
    }

    public InstalledFontsList()
    {
        Text = "InstalledFontsCollection List";
    }

    protected override FontFamily[] GetFontFamilyArray(Graphics grfx)
    {
        FontCollection fc = new InstalledFontCollection();
        return fc.Families;
        
    }
}