namespace CNutSharp.Library.Models;

public class OuterValueInfo(BinaryReader br)
{
    public int Type = br.ReadInt32();
    public SQObject Src = new(br);
    public SQObject Name = new(br);

    public void Write(BinaryWriter writer)
    {
        writer.Write(Type);
        Src.Write(writer);
        Name.Write(writer);
    }
};