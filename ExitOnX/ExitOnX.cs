﻿using System;
using System.Drawing;
using System.Windows.Forms;

class ExitOnX : Form
{
    public static void Main()
    {
        Application.Run(new ExitOnX());
    }

    public ExitOnX()
    {
        Text = "Exit on X";
        BackColor = SystemColors.Window;
        ForeColor = SystemColors.WindowText;
    }

    protected override void OnKeyDown(KeyEventArgs kea)
    {
        Keys keys = Control.ModifierKeys;

        if (  keys == (Keys.Shift | Keys.Control)
            | keys == Keys.Shift
            | keys == Keys.Control
            )
        {
            if (kea.KeyCode == Keys.X)
                Close();

            //if (kea.KeyCode == (Keys)(int)'X')
            //    Close();
        }
    }
}