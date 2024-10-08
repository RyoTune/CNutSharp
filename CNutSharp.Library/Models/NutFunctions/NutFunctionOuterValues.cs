namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionOuterValues : List<OuterValueInfo>
{
    private readonly NutFunction _parent;

    public NutFunctionOuterValues(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            var obj = new OuterValueInfo(br);
            base.Add(obj);
        }
    }

    public new void Add(OuterValueInfo item)
    {
        _parent.nOuterValues++;
        base.Add(item);
    }
}