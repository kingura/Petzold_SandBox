using System;
using System.IO;

class ClassesRWToFile
{
    public static void Main()
    {
        string fileN = "file_with_classes_info_inside.ttt";


        FileStream fs = new FileStream(fileN, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

        BinaryWriter bw = new BinaryWriter(fs);
        SampleClass sc = new SampleClass(true, 2, 'W', "Check", new Fish(false, 666, 'Q', "Fish"));

        Console.WriteLine(sc.ToString());
        Console.WriteLine();

        sc.Write(bw);
        fs.Close();
        

        FileStream fs2 = new FileStream(fileN, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        fs2.Position = 0;

        BinaryReader br = new BinaryReader(fs2);
        SampleClass sc2 = SampleClass.Read(br);

        Console.WriteLine(sc2.ToString());

        fs2.Close();
    }
}


class SampleClass
{
    public bool f_bool;
    public int f_int;
    public char f_char;
    public string f_string;
    public Fish f_fish;

    public SampleClass(bool b, int i, char c, string s, Fish f)
    {
        f_bool = b;
        f_int = i;
        f_char = c;
        f_string = s;
        f_fish = f;
    }

    public void Write(BinaryWriter bw)
    {
        bw.Write(f_bool);
        bw.Write(f_int);
        bw.Write(f_char);
        bw.Write(f_string);
        f_fish.Write(bw);
    }

    public static SampleClass Read(BinaryReader br)
    {
        bool b = br.ReadBoolean();
        int i = br.ReadInt32();
        char c = br.ReadChar();
        string s = br.ReadString();
        Fish f = Fish.Read(br);

        return new SampleClass(b, i, c, s, f);
    }

    public override string ToString()
    {
        return string.Format("{0} [{1}, {2}, {3}, {4},\n{5}]",
            base.ToString(), f_bool, f_int, f_char, f_string, f_fish.ToString());
    }
}

class Fish
{
    public bool f2_bool;
    public int f2_int;
    public char f2_char;
    public string f2_string;

    public Fish(bool b, int i, char c, string s)
    {
        f2_bool = b;
        f2_int = i;
        f2_char = c;
        f2_string = s;
    }

    public void Write(BinaryWriter bw)
    {
        bw.Write(f2_bool);
        bw.Write(f2_int);
        bw.Write(f2_char);
        bw.Write(f2_string);
    }
    
    public static Fish Read(BinaryReader br)
    {
        bool b = br.ReadBoolean();
        int i = br.ReadInt32();
        char c = br.ReadChar();
        string s = br.ReadString();

        return new Fish(b, i, c, s);
    }

    public override string ToString()
    {
        return string.Format("{0} [{1}, {2}, {3}, {4}]",
            base.ToString(), f2_bool, f2_int, f2_char, f2_string);
    }
}