using System.Text;

namespace CNutSharp.Library.Models;

public class NutHeader : IWrite
{
    public ushort MagicFAFA;
    public string MagicSQIR;
    public int SizeChar;
    public int SizeInt;
    public int SizeFloat;

    public NutHeader(BinaryReader br)
    {
        MagicFAFA = br.ReadUInt16();
        MagicSQIR = Encoding.ASCII.GetString(br.ReadBytes(4));
        SizeChar = br.ReadInt32();
        SizeInt = br.ReadInt32();
        SizeFloat = br.ReadInt32();

        if (MagicFAFA != 0xFAFA || MagicSQIR != "RIQS")
        {
            throw new Exception("Header confirmation failed.");
        }
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write(MagicFAFA);
        writer.Write(Encoding.ASCII.GetBytes(MagicSQIR));
        writer.Write(SizeChar);
        writer.Write(SizeInt);
        writer.Write(SizeFloat);
    }

    public void WriteText(TextWriter writer)
    {
        throw new NotImplementedException();
    }
}