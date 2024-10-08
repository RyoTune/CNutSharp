using System.Text;
using CNutSharp.Library.Models.NutEnums;

namespace CNutSharp.Library.Models;

public class SQObject
{
    public SQObjectType Type;
    public int Value;
    public float ValueFloat;
    public string ValueString = string.Empty;
    public List<SQObject> ValueArray = [];

    public SQObject(BinaryReader br)
    {
        Type = (SQObjectType)br.ReadInt32();
        switch (Type)
        {
            case SQObjectType.OT_STRING:
                var len = br.ReadInt64();
                if (len > 0)
                {
                    ValueString = Encoding.UTF8.GetString(br.ReadBytes((int)len));
                }
                else
                {
                    ValueString = "[null string]";
                }
                break;
            case SQObjectType.OT_INTEGER:
            case SQObjectType.OT_BOOL:
                Value = br.ReadInt32();
                break;
            case SQObjectType.OT_FLOAT:
                ValueFloat = br.ReadSingle();
                break;
            case SQObjectType.OT_ARRAY:
                int arraySize = br.ReadInt32();
                ValueArray = new List<SQObject>(arraySize);
                for (int i = 0; i < arraySize; i++)
                {
                    var element = new SQObject(br);
                    ValueArray.Add(element);
                }
                break;
        }
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write((int)Type);
        switch (Type)
        {
            case SQObjectType.OT_STRING:
                writer.Write((long)ValueString.Length);
                writer.Write(Encoding.UTF8.GetBytes(ValueString));
                break;
            case SQObjectType.OT_INTEGER:
            case SQObjectType.OT_BOOL:
                writer.Write(Value);
                break;
            case SQObjectType.OT_FLOAT:
                writer.Write(ValueFloat);
                break;
            case SQObjectType.OT_ARRAY:
                writer.Write(ValueArray.Count);
                foreach (var item in ValueArray)
                {
                    item.Write(writer);
                }
                break;
        }
    }
}