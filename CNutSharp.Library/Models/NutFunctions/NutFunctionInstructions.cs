namespace CNutSharp.Library.Models.NutFunctions;

public class NutFunctionInstructions : List<Instruction>
{
    private readonly NutFunction _parent;

    public NutFunctionInstructions(NutFunction parent, int num, BinaryReader br)
    {
        _parent = parent;

        for (int i = 0; i < num; i++)
        {
            var obj = new Instruction(br, i);
            base.Add(obj);
        }
    }

    public new void Add(Instruction item)
    {
        _parent.nInstructions++;
        base.Add(item);
    }
}