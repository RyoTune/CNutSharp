namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionDefaultParams : List<long>
{
    private readonly NutFunction _parent;

    public NutFunctionDefaultParams(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            base.Add(br.ReadInt64());
        }
    }

    public new void Add(long item)
    {
        _parent.nDefaultParams++;
        base.Add(item);
    }
}