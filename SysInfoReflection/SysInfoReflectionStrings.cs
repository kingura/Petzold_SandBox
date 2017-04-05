using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

class SysInfoReflectionStrings
{
    // Поля
    private static bool bValidInfo = false;
    private static int iCount;
    private static string[] astrLabels;
    static private string[] astrValues;


    // Конструктор
    static SysInfoReflectionStrings()
    {
        SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(UserPreferenceChanged);
        SystemEvents.DisplaySettingsChanged += new EventHandler(DisplaySettingsChanged);
    }


    // Свойства
    public static string[] Labels
    {
        get
        {
            GetSysInfo();
            return astrLabels;
        }
    }

    public static string[] Values
    {
        get
        {
            GetSysInfo();
            return astrValues;
        }
    }

    public static int Count
    {
        get
        {
            GetSysInfo();
            return iCount;
        }
    }


    // Обработчики событий
    static void UserPreferenceChanged(object obj, UserPreferenceChangedEventArgs ea)
    {
        bValidInfo = false;
    }

    static void DisplaySettingsChanged(object obj, EventArgs ea)
    {
        bValidInfo = false;
    }


    // Методы
    static void GetSysInfo()
    {
        if (bValidInfo)
            return;

        // Получаем сведения о свойстве класса SystemInformation
        Type type = typeof (SystemInformation);
        PropertyInfo[] apropinfo = type.GetProperties();

        // Счетчик числа статических, считываемых свойств
        iCount = 0;
        foreach (PropertyInfo pi in apropinfo)
        {
            if (pi.CanRead && pi.GetGetMethod().IsStatic)
                iCount++;
        }

        // Выделение строковых массивов
        astrLabels = new string[iCount];
        astrValues = new string[iCount];

        // Снова проходим по всем свойствам
        iCount = 0;
        foreach (PropertyInfo pi in apropinfo)
        {
            if (pi.CanRead && pi.GetGetMethod().IsStatic)
            {
                // Получаем имена и значения свойств
                astrLabels[iCount] = pi.Name;
                astrValues[iCount] = pi.GetValue(type, null).ToString();
                iCount++;   
            }
        }

        Array.Sort(astrLabels, astrValues);
        bValidInfo = true;
    }

    public static float MaxLabelWidth(Graphics grfx, Font font)
    {
        return MaxWidth(Labels, grfx, font);
    }

    public static float MaxValueWidth(Graphics grfx, Font font)
    {
        return MaxWidth(Values, grfx, font);
    }

    static float MaxWidth(string[] astr, Graphics grfx, Font font)
    {
        float fMax = 0;
        //GetSysInfo(); -- думаю этот вызов даже излишен

        // Ищем максимальную длину в пикселях
        foreach (string str in astr)
            fMax = Math.Max(fMax, grfx.MeasureString(str, font).Width);
        
        return fMax;
    }
}