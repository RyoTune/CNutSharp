namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionLineInfo : List<LineInfo>
{
    private readonly NutFunction _parent;

    public NutFunctionLineInfo(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            var obj = new LineInfo(br);
            base.Add(obj);
        }
    }

    public new void Add(LineInfo item)
    {
        _parent.nLineInfos++;
        base.Add(item);
    }
}