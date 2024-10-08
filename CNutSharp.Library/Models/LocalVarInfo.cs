namespace CNutSharp.Library.Models;

public class LocalVarInfo(BinaryReader br) : IWrite
{
    public SQObject Name = new(br);
    public ulong Position = br.ReadUInt64();
    public ulong Start_OP = br.ReadUInt64();
    public ulong End_OP = br.ReadUInt64();

    public void Write(BinaryWriter writer)
    {
        Name.Write(writer);
        writer.Write(Position);
        writer.Write(Start_OP);
        writer.Write(End_OP);
    }

    public void WriteText(TextWriter writer)
    {
        throw new NotImplementedException();
    }
};