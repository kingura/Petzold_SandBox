using System;

class StringAppend
{
  const int iIterations = 100000;

  public static void Main()
  {
    DateTime dt = DateTime.Now;
    string str = String.Empty;

    for (int i = 0; i < iIterations; i++)
      str += "abcdefghijklmnopqrstuvwxyz\r\n";

    Console.WriteLine(DateTime.Now - dt);
  }
}