using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

class NotepadCloneWithRegistry : NotepadCloneNoMenu
{
  Rectangle rectNormal;
  protected string strProgName;
  string strRegKey = "Software\\ProgrammingWindowsWithCSharp\\";
  const string strWinState = "WindowState";
  const string strLocationX = "LocationX";
  const string strLocationY = "LocationY";
  const string strWidth = "Width";
  const string strHeight = "Height";

  public new static void Main()
  {
    Application.Run(new NotepadCloneWithRegistry());
  }

  public NotepadCloneWithRegistry()
  {
    Text = strProgName = "Notepad Clone with Registry";
    rectNormal = DesktopBounds;
  }

  protected override void OnMove(EventArgs e)
  {
    base.OnMove(e);

    if (WindowState == FormWindowState.Normal)
      rectNormal = DesktopBounds;
  }

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);

    if (WindowState == FormWindowState.Normal)
      rectNormal = DesktopBounds;
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);

    // Формируем полный раздел реестра.

    strRegKey = strRegKey + strProgName;

    // Загружаем информацию из реестра.

    RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegKey);

    if (regkey != null)
    {
      LoadRegistryInfo(regkey);
      regkey.Close();
    }
  }

  protected override void OnClosed(EventArgs e)
  {
    base.OnClosed(e);

    // Сохраняем информацию в реестре.

    RegistryKey regkey = Registry.CurrentUser.OpenSubKey(strRegKey, true);
    if (regkey == null)
      regkey = Registry.CurrentUser.CreateSubKey(strRegKey);

    SaveRegistryInfo(regkey);
    regkey.Close();
  }

  protected virtual void SaveRegistryInfo(RegistryKey regkey)
  {
    regkey.SetValue(strWinState, (int)WindowState);
    regkey.SetValue(strLocationX, rectNormal.X);
    regkey.SetValue(strLocationY, rectNormal.Y);
    regkey.SetValue(strWidth, rectNormal.Width);
    regkey.SetValue(strHeight, rectNormal.Height);
  }

  protected virtual void LoadRegistryInfo(RegistryKey regkey)
  {
    int x = (int)regkey.GetValue(strLocationX, 100);
    int y = (int)regkey.GetValue(strLocationY, 100);
    int cx = (int)regkey.GetValue(strWidth, 380);
    int cy = (int)regkey.GetValue(strHeight, 300);

    rectNormal = new Rectangle(x, y, cx, cy);

    // приводим прямоугольник в соответствие с размерами экрана (размеры экрана могли измениться)

    Rectangle rectDesk = SystemInformation.WorkingArea;

    rectNormal.Width = Math.Min(rectNormal.Width, rectDesk.Width);
    rectNormal.Height = Math.Min(rectNormal.Height, rectDesk.Height);
    rectNormal.X -= Math.Max(rectNormal.Right - rectDesk.Right, 0);
    rectNormal.Y -= Math.Max(rectNormal.Bottom - rectDesk.Bottom, 0);

    // Присваиваем значения свойствам формы.

    DesktopBounds = rectNormal;
    WindowState = (FormWindowState)regkey.GetValue(strWinState, 0);
  }
}