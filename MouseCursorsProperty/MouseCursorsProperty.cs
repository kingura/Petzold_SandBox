using System;
using System.Drawing;
using System.Windows.Forms;

class MouseCursorsProperty : Form
{
    Label[] alabels = new Label[28];


    static void Main()
    {
        Application.Run(new MouseCursorsProperty());
    }

    public MouseCursorsProperty()
    {
        Cursor[] acursor =
         {
              Cursors.AppStarting, Cursors.Arrow,       Cursors.Cross,
              Cursors.Default,     Cursors.Hand,        Cursors.Help,
              Cursors.HSplit,      Cursors.IBeam,       Cursors.No,
              Cursors.NoMove2D,    Cursors.NoMoveHoriz, Cursors.NoMoveVert,
              Cursors.PanEast,     Cursors.PanNE,       Cursors.PanNorth,
              Cursors.PanNW,       Cursors.PanSE,       Cursors.PanSouth,
              Cursors.PanSW,       Cursors.PanWest,     Cursors.SizeAll,
              Cursors.SizeNESW,    Cursors.SizeNS,      Cursors.SizeNWSE,
              Cursors.SizeWE,      Cursors.UpArrow,     Cursors.VSplit,
              Cursors.WaitCursor
        };
        string[] astrCursor =
        {
              "AppStarting",       "Arrow",             "Cross",
              "Default",           "Hand",              "Help",
              "HSplit",            "IBeam",             "No",
              "NoMove2D",          "NoMoveHoriz",       "NoMoveVert",
              "PanEast",           "PanNE",             "PanNorth",
              "PanNW",             "PanSE",             "PanSouth",
              "PanSW",             "PanWest",           "SizeAll",
              "SizeNESW",          "SizeNS",            "SizeNWSE",
              "SizeWE",            "UpArrow",           "VSplit",
              "WaitCursor"
        };

        Text = "Mouse Cursors Using Cursor Property";

        for (int i = 0; i < alabels.Length; i++)
        {
            alabels[i] = new Label();
            alabels[i].Parent = this;
            alabels[i].Text = astrCursor[i];
            alabels[i].Cursor = acursor[i];
            alabels[i].BorderStyle = BorderStyle.FixedSingle;
        }
        OnResize(EventArgs.Empty);
    }

    protected override void OnResize(EventArgs ea)
    {
        for (int i = 0; i < alabels.Length; i++)
        {
            alabels[i].Bounds = Rectangle.FromLTRB(
                (i % 4) * ClientSize.Width / 4,
                (i / 4) * ClientSize.Height / 7,
                (i % 4 + 1) * ClientSize.Width / 4,
                (i / 4 + 1) * ClientSize.Height / 7
                );
        }
    }
}