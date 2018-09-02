using Microsoft.Win32; // Для классов работы с реестром
using System;
using System.ComponentModel; // Для класса CancelEventArgs
using System.Drawing;
using System.IO;
using System.Text; // Для класса Encoding
using System.Windows.Forms;

class NotepadCloneWithFile: NotepadCloneWithRegistry
{

                                                                    // Поля
  protected string strFileName;
  const string strEncoding = "Encoding"; // Для работы с реестром
  const string strFilter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
  MenuItem miEncoding;
  MenuItemEncoding mieChecked;


                                                                    // Точка входа
  [STAThread]
  public new static void Main()
  {
    Application.Run(new NotepadCloneWithFile());
  }


                                                                    // Конструктор
  public NotepadCloneWithFile()
  {
    strProgName = "Notepad Clone with File";
    MakeCaption();
    Menu = new MainMenu();

    // Меню File
    MenuItem mi = new MenuItem("&File");
    Menu.MenuItems.Add(mi);
    int index = Menu.MenuItems.Count - 1;

    // File New
    mi = new MenuItem("&New");
    mi.Click += new EventHandler(MenuFileNewOnClick);
    mi.Shortcut = Shortcut.CtrlN;
    Menu.MenuItems[index].MenuItems.Add(mi);

    // File Open
    MenuItem miFileOpen = new MenuItem("&Open...");
    miFileOpen.Click += new EventHandler(MenuFileOpenOnClick);
    miFileOpen.Shortcut = Shortcut.CtrlO;
    Menu.MenuItems[index].MenuItems.Add(miFileOpen);

    // File Save
    MenuItem miFileSave = new MenuItem("&Save");
    miFileSave.Click += new EventHandler(MenuFileSaveOnClick);
    miFileSave.Shortcut = Shortcut.CtrlS;
    Menu.MenuItems[index].MenuItems.Add(miFileSave);

    // File Save As
    mi = new MenuItem("Save &As...");
    mi.Click += new EventHandler(MenuFileSaveAsOnClick);
    Menu.MenuItems[index].MenuItems.Add(mi);

    // File Encoding
    miEncoding = new MenuItem("&Encoding");
    Menu.MenuItems[index].MenuItems.Add(miEncoding);
    Menu.MenuItems[index].MenuItems.Add("-");

    // Подменю File Encoding
    EventHandler eh = new EventHandler(MenuFileEncodingOnClick);

    string[] astrEncodings = { "&ASCII", "&Unicode", "&Big-Endian Unicode", "UTF-&7", "&UTF-&8" };
    Encoding[] aenc = { Encoding.ASCII, Encoding.Unicode, Encoding.BigEndianUnicode, Encoding.UTF7, Encoding.UTF8 };

    for (int i = 0; i < astrEncodings.Length; i++)
    {
      MenuItemEncoding mie = new MenuItemEncoding();
      mie.Text = astrEncodings[i];
      mie.Encoding = aenc[i];
      mie.RadioCheck = true;
      mie.Click += eh;

      miEncoding.MenuItems.Add(mie);
    }
    mieChecked = (MenuItemEncoding)miEncoding.MenuItems[4]; // UTF-8
    mieChecked.Checked = true;

    // File Page Setup
    mi = new MenuItem("Page Set&up...");
    mi.Click += new EventHandler(MenuFileSetupOnClick);
    Menu.MenuItems[index].MenuItems.Add(mi);

    // File Print Preview
    mi = new MenuItem("Print Pre&view...");
    mi.Click += new EventHandler(MenuFilePreviewOnClick);
    Menu.MenuItems[index].MenuItems.Add(mi);

    // File Print
    mi = new MenuItem("&Print...");
    mi.Click += new EventHandler(MenuFilePrintOnClick);
    mi.Shortcut = Shortcut.CtrlP;
    Menu.MenuItems[index].MenuItems.Add(mi);
    Menu.MenuItems[index].MenuItems.Add("-");

    // File Exit
    mi = new MenuItem("E&xit");
    mi.Click += new EventHandler(MenuFileExitOnClick);
    Menu.MenuItems[index].MenuItems.Add(mi);

    // Установка обработчика системного события.
    SystemEvents.SessionEnding += new SessionEndingEventHandler(OnSessionEnding);
  }


                                                                    // Переопределения обработчиков событий
  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);

    // Обработка параметров командной строки.
    string[] astrArgs = Environment.GetCommandLineArgs();

    if (astrArgs.Length > 1) // Первый параметр - имя программы!
    {
      if (File.Exists(astrArgs[1]))
      {
        LoadFile(astrArgs[1]);
      }
      else
      {
        DialogResult dr = MessageBox.Show("Cannot find the " + Path.GetFileName(astrArgs[1]) + " file.\r\n\r\n" +
                                          "Do you want to create a new file?",
                                          strProgName,
                                          MessageBoxButtons.YesNoCancel,
                                          MessageBoxIcon.Question);
        switch (dr)
        {
          case DialogResult.Yes: // Создаем и закрываем файл
            File.Create(strFileName = astrArgs[1]).Close();
            MakeCaption();
            break;

          case DialogResult.No:
            break;

          case DialogResult.Cancel:
            Close();
            break;
        }
      }
    }
  }

  protected override void OnClosing(CancelEventArgs e)
  {
    base.OnClosing(e);

    e.Cancel = !OkToTrash();
  }


                                                                    // Обработчики событий
  private void OnSessionEnding(object sender, SessionEndingEventArgs e)
  {
    e.Cancel = !OkToTrash();
  }


                                                                    // Пункты меню
  private void MenuFileNewOnClick(object sender, EventArgs e)
  {
    if (!OkToTrash()) return;

    txtbox.Clear();
    txtbox.ClearUndo();
    txtbox.Modified = false;

    strFileName = null;
    MakeCaption();
  }

  private void MenuFileOpenOnClick(object sender, EventArgs e)
  {
    if (!OkToTrash()) return;

    OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = strFilter;
    ofd.FileName = "*.txt";

    if (ofd.ShowDialog() == DialogResult.OK)
      LoadFile(ofd.FileName);
  }

  private void MenuFileEncodingOnClick(object sender, EventArgs e)
  {
    mieChecked.Checked = false;
    mieChecked = (MenuItemEncoding)sender;
    mieChecked.Checked = true;
  }

  private void MenuFileSaveOnClick(object sender, EventArgs e)
  {
    if (strFileName == null || strFileName.Length == 0)
      SaveFileDlg();
    else
      SaveFile();
  }

  private void MenuFileSaveAsOnClick(object sender, EventArgs e)
  {
    SaveFileDlg();
  }

  private void MenuFileSetupOnClick(object sender, EventArgs e)
  {
    MessageBox.Show("Page Setup not yet implemented!", strProgName);
  }

  private void MenuFilePreviewOnClick(object sender, EventArgs e)
  {
    MessageBox.Show("Print Preview not yet implemented!", strProgName);
  }

  private void MenuFilePrintOnClick(object sender, EventArgs e)
  {
    MessageBox.Show("Print not yet implemented!", strProgName);
  }

  private void MenuFileExitOnClick(object sender, EventArgs e)
  {
    if (OkToTrash()) Application.Exit();
  }


                                                                    // Переопределения методов
  protected override void LoadRegistryInfo(RegistryKey regkey)
  {
    base.LoadRegistryInfo(regkey);

        // Присваивание параметров кодировки.

    int index = (int)regkey.GetValue(strEncoding, 4);

    mieChecked.Checked = false;
    mieChecked = (MenuItemEncoding)miEncoding.MenuItems[index];
    mieChecked.Checked = true;
  }

  protected override void SaveRegistryInfo(RegistryKey regkey)
  {
    base.SaveRegistryInfo(regkey);

    regkey.SetValue(strEncoding, mieChecked.Index);
  }


                                                                    // Вспомогательные методы
  protected void LoadFile(string strFileName)
  {
    StreamReader sr;

    try
    {
      sr = new StreamReader(strFileName);
    }
    catch (Exception exc)
    {
      MessageBox.Show(exc.Message, strProgName,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Asterisk);
      return;
    }
    txtbox.Text = sr.ReadToEnd();
    sr.Close();

    this.strFileName = strFileName;
    MakeCaption();

    txtbox.SelectionStart = 0;
    txtbox.SelectionLength = 0;
    txtbox.Modified = false;
    txtbox.ClearUndo();
  }

  void SaveFile()
  {
    try
    {
      StreamWriter sw = new StreamWriter(strFileName, false, mieChecked.Encoding);
      sw.Write(txtbox.Text);
      sw.Close();
    }
    catch (Exception exc)
    {
      MessageBox.Show(exc.Message, strProgName,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Asterisk);
      return;
    }
    txtbox.Modified = false;
  }

  bool SaveFileDlg()
  {
    SaveFileDialog sfd = new SaveFileDialog();

    if (strFileName != null && strFileName.Length > 1)
      sfd.FileName = strFileName;
    else
      sfd.FileName = "*.txt";

    sfd.Filter = strFilter;

    if(sfd.ShowDialog() == DialogResult.OK)
    {
      strFileName = sfd.FileName;
      SaveFile();
      MakeCaption();
      return true;
    }
    else
    {
      return false; // Возвращаемые значения используются OkToTrash.
    }
  }

  protected void MakeCaption()
  {
    Text = strProgName + " - " + FileTitle();
  }

  protected string FileTitle()
  {
    return (strFileName != null && strFileName.Length > 1) ?
           Path.GetFileName(strFileName) : "Untitled";
  }

  protected bool OkToTrash()
  {
    if (!txtbox.Modified)
      return true;

    DialogResult dr = MessageBox.Show("The text in the " + FileTitle() + " file has changed.\r\n\r\n" +
                                      "Do you want to save changes?",
                                      strProgName,
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Exclamation);
    switch (dr)
    {
      case DialogResult.Yes:
        return SaveFileDlg();

      case DialogResult.No:
        return true;

      case DialogResult.Cancel:
        return false;
    }
    return false;
  }
}

class MenuItemEncoding: MenuItem
{
  public Encoding Encoding;
}