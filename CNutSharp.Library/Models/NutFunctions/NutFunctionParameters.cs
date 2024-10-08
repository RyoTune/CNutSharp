namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionParameters : List<SQObject>
{
    private readonly NutFunction _parent;

    public NutFunctionParameters(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            var obj = new SQObject(br);
            base.Add(obj);
        }
    }

    public new void Add(SQObject item)
    {
        _parent.nParameters++;
        base.Add(item);
    }
}