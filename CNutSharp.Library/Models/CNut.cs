using Microsoft.Extensions.Logging;

namespace CNutSharp.Library.Models;

public class CNut
{
    public CNut(string file, ILogger? log = null) : this(File.OpenRead(file), log)
    {
    }

    public CNut(Stream inStream, ILogger? log = null)
    {
        using var br = new BinaryReader(inStream);
        Header = new NutHeader(br);
        FuncMain = new NutFunction(br, log);
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

    public void Merge(CNut mergeNut) => FuncMain.Merge(mergeNut.FuncMain);
}