using System;
using System.Drawing;
using System.Windows.Forms;

internal class ProgramWithIcon : Form
{
  public static void Main()
  {
    Application.Run(new ProgramWithIcon());
  }

  public ProgramWithIcon()
  {
    Text = "Program With Icon";

    Icon = new Icon(typeof(ProgramWithIcon), "ProgramWithIcon.ProgramWithIcon.ico");
  }
}