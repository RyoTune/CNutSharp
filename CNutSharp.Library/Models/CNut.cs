namespace CNutSharp.Library.Models;

public class CNut
{
    public CNut(string file) : this(File.OpenRead(file))
    {
    }

    public CNut(Stream inStream)
    {
        using var br = new BinaryReader(inStream);
        Header = new NutHeader(br);
        FuncMain = new NutFunction(br);
        End = new NutEnd(br);
    }

    public NutHeader Header;
    public NutFunction FuncMain;
    public NutEnd End;

    public void Write(Stream outStream)
    {
        using BinaryWriter bw = new(outStream);
        Write(bw);
    }

    public void Write(BinaryWriter bw)
    {
        Header.Write(bw);
        FuncMain.Write(bw);
        End.Write(bw);
    }
}