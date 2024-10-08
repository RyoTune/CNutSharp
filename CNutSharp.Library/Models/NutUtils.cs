using System.Text;

internal static class NutUtils
{
    public static bool ConfirmPart(BinaryReader br)
        => Encoding.ASCII.GetString(br.ReadBytes(4)) == "TRAP";

    public static void WritePart(BinaryWriter bw)
        => bw.Write(Encoding.ASCII.GetBytes("TRAP"));
}
