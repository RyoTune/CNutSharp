namespace CNutSharp.Library.Models;

public class LineInfo(BinaryReader br) : IWrite
{
    public long Line = br.ReadInt64();
    public long OP = br.ReadInt64();

    public void Write(BinaryWriter writer)
    {
        writer.Write(Line);
        writer.Write(OP);
    }

    public void WriteText(TextWriter writer)
    {
        throw new NotImplementedException();
    }
};