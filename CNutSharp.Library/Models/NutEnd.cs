using System.Text;

namespace CNutSharp.Library.Models;

public class NutEnd
{
    public string TAIL;

    public NutEnd(BinaryReader br)
    {
        TAIL = Encoding.ASCII.GetString(br.ReadBytes(4));
        if (TAIL != "LIAT")
        {
            throw new Exception("Tail end confirmation failed.");
        }
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write(Encoding.ASCII.GetBytes(TAIL));
    }
}