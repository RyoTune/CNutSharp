namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionFunctions : List<NutFunction>
{
    private readonly NutFunction _parent;

    public NutFunctionFunctions(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            var obj = new NutFunction(br);
            base.Add(obj);
        }
    }

    public new void Add(NutFunction item)
    {
        _parent.nFunctions++;
        base.Add(item);
    }
}