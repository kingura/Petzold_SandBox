using System;
using System.IO;
using System.Net.Security;

internal class WildCardHexDump : HexDump
{
    public new static int Main(string[] astrArgs)
    {
        if (astrArgs.Length == 0)
        {
            Console.WriteLine("Syntax: HexDump file1 file2 ...");
            return 1;
        }

        foreach (string str in astrArgs)
            ExpandWildCard(str);

        return 0;
    }

    private static void ExpandWildCard(string strWildCard)
    {
        string[] astrFiles;

        try
        {
            astrFiles = Directory.GetFiles(strWildCard);
        }
        catch
        {
            try
            {
                string strDir = Path.GetDirectoryName(strWildCard);
                string strFile = Path.GetFileName(strWildCard);

                if (strDir == null || strDir.Length == 0)
                    strDir = ".";

                astrFiles = Directory.GetFiles(strDir, strFile);
            }
            catch
            {
                Console.WriteLine(strWildCard + ": No Files found!");
                return;
            }
        }
        if (astrFiles.Length == 0)
            Console.WriteLine(strWildCard + ": No Files found!");

        foreach (var strFile in astrFiles)
            DumpFile(strFile);
    }
}