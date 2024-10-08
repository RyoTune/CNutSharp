namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionLiterals : List<SQObject>
{
    private readonly NutFunction _parent;

    public NutFunctionLiterals(NutFunction parent, int num, BinaryReader br)
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
        _parent.nLiterals++;
        base.Add(item);
    }
}