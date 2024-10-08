namespace CNutSharp.Library.Models;

public interface IWrite
{
    void Write(BinaryWriter writer);

    void WriteText(TextWriter writer);
}