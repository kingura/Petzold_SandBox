using System;
using System.Drawing;
using System.Windows.Forms;

class StandardMenu : Form
{
  MenuItem miFileOpen, miFileSave;
  MenuItem miEditCut, miEditCopy, miEditPaste;

  // Экспериментальные переменные для кода Popup

  bool bDocumentPresent = true;
  bool bNonNullSelection = true;
  bool bStuffInClipboard = false;

  public static void Main()
  {
    Application.Run(new StandardMenu());
  }
  public StandardMenu()
  {
    Text = "Standard Menu";
    Menu = new MainMenu();

    // File

    MenuItem mi = new MenuItem("&File");
    mi.Popup += new EventHandler(MenuFileOnPopup);
    Menu.MenuItems.Add(mi);
    int index = Menu.MenuItems.Count - 1;

    // File - Open

    miFileOpen = new MenuItem("&Open...");
    miFileOpen.Click += new EventHandler(MenuFileOpenOnClick);
    miFileOpen.Shortcut = Shortcut.CtrlO;
    Menu.MenuItems[index].MenuItems.Add(miFileOpen);

    // File - Save

    miFileSave = new MenuItem("&Save");
    miFileSave.Click += new EventHandler(MenuFileSaveOnClick);
    miFileSave.Shortcut = Shortcut.CtrlS;
    Menu.MenuItems[index].MenuItems.Add(miFileSave);

    // Горизонтальная линия

    mi = new MenuItem("-");
    Menu.MenuItems[index].MenuItems.Add(mi);

    // File - Exit

    mi = new MenuItem("E&xit");
    mi.Click += new EventHandler(MenuFileExitOnClick);
    Menu.MenuItems[index].MenuItems.Add(mi);

    // Edit

    mi = new MenuItem("&Edit");
    mi.Popup += new EventHandler(MenuEditOnPopup);
    Menu.MenuItems.Add(mi);
    index = Menu.MenuItems.Count - 1;

    // Edit - Cut

    miEditCut = new MenuItem("Cu&t");
    miEditCut.Click += new EventHandler(MenuEditCutOnClick);
    miEditCut.Shortcut = Shortcut.CtrlX;
    Menu.MenuItems[index].MenuItems.Add(miEditCut);

    // Edit - Copy

    miEditCopy = new MenuItem("&Copy");
    miEditCopy.Click += new EventHandler(MenuEditCopyOnClick);
    miEditCopy.Shortcut = Shortcut.CtrlC;
    Menu.MenuItems[index].MenuItems.Add(miEditCopy);

    // Edit - Paste

    miEditPaste = new MenuItem("&Paste");
    miEditPaste.Click += new EventHandler(MenuEditCopyOnClick);
    miEditPaste.Shortcut = Shortcut.CtrlV;
    Menu.MenuItems[index].MenuItems.Add(miEditPaste);

    // Help

    mi = new MenuItem("&Help");
    Menu.MenuItems.Add(mi);
    index = Menu.MenuItems.Count - 1;

    // Help - About

    mi = new MenuItem("&About StandardMenu...");
    mi.Click += new EventHandler(MenuHelpAboutOnClick);
    Menu.MenuItems[index].MenuItems.Add(mi);
  }
  void MenuFileOnPopup(object obj, EventArgs ea)
  {
    miFileSave.Enabled = bDocumentPresent;
  }
  void MenuEditOnPopup(object obj, EventArgs ea)
  {
    miEditCut.Enabled = bNonNullSelection;
    miEditCopy.Enabled = bNonNullSelection;
    miEditPaste.Enabled = bStuffInClipboard;
  }
  void MenuFileOpenOnClick(object obj, EventArgs ea)
  {
    MessageBox.Show("This should be a File Open dialog box!", Text);
  }
  void MenuFileSaveOnClick(object obj, EventArgs ea)
  {
    MessageBox.Show("This should be a File Save dialog box!", Text);
  }
  void MenuFileExitOnClick(object obj, EventArgs ea)
  {
    Close();
  }
  void MenuEditCutOnClick(object obj, EventArgs ea)
  {
    // Копирование выбранного фрагмента в буфер обмена
    // и удаление его из документа
  }
  void MenuEditCopyOnClick(object obj, EventArgs ea)
  {
    // Копирование выбранного фрагмента в буфер обмена
  }
  void MenuEditPasteOnClick(object obj, EventArgs ea)
  {
    // Копирование данных из буфера обмена в документ
  }
  void MenuHelpAboutOnClick(object obj, EventArgs ea)
  {
    MessageBox.Show("StandardMenu (C) 2018 by Joe Black", Text);
  }
}