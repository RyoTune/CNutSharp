namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionLocalVarInfo : List<LocalVarInfo>
{
    private readonly NutFunction _parent;

    public NutFunctionLocalVarInfo(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            var obj = new LocalVarInfo(br);
            base.Add(obj);
        }
    }

    public new void Add(LocalVarInfo item)
    {
        _parent.nLocalVarInfos++;
        base.Add(item);
    }
}