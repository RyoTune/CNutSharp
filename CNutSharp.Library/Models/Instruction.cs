using CNutSharp.Library.Models.NutEnums;

namespace CNutSharp.Library.Models;

public class Instruction : IWrite
{
    // Instruction position?
    public int _ip;

    public (int Int, float Float) Arg1;
    public SQOpcode OP;
    public byte Arg0, Arg2, Arg3;

    public Instruction(BinaryReader br, int ip)
    {
        _ip = ip;

        var arg1Bytes = br.ReadBytes(4);
        Arg1.Int = BitConverter.ToInt32(arg1Bytes);
        Arg1.Float = BitConverter.ToSingle(arg1Bytes);

        OP = (SQOpcode)br.ReadChar();
        Arg0 = br.ReadByte();
        Arg2 = br.ReadByte();
        Arg3 = br.ReadByte();
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write(BitConverter.GetBytes(Arg1.Int));
        writer.Write((byte)OP);
        writer.Write(Arg0);
        writer.Write(Arg2);
        writer.Write(Arg3);
    }

    public void WriteText(TextWriter writer)
    {
        throw new NotImplementedException();
    }
}