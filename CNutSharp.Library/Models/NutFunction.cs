using CNutSharp.Library.Models.NutFunctions;

namespace CNutSharp.Library.Models;

public class NutFunction
{
    public SQObject SourceName;
    public SQObject Name;
    public long nLiterals;
    public long nParameters;
    public long nOuterValues;
    public long nLocalVarInfos;
    public long nLineInfos;
    public long nDefaultParams;
    public long nInstructions;
    public long nFunctions;
    public long StackSize;
    public byte IsGenerator;
    public long VarParams;

    public NutFunctionLiterals Literals;
    public NutFunctionParameters Parameters;
    public NutFunctionOuterValues OuterValues;
    public NutFunctionLocalVarInfo LocalVarInfos;
    public NutFunctionLineInfo LineInfos;
    public NutFunctionDefaultParams DefaultParams;
    public NutFunctionInstructions Instructions;
    public NutFunctionFunctions Functions;

    public NutFunction(BinaryReader br)
    {
        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        SourceName = new SQObject(br);
        Name = new SQObject(br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        nLiterals = br.ReadInt64();
        nParameters = br.ReadInt64();
        nOuterValues = br.ReadInt64();
        nLocalVarInfos = br.ReadInt64();
        nLineInfos = br.ReadInt64();
        nDefaultParams = br.ReadInt64();
        nInstructions = br.ReadInt64();
        nFunctions = br.ReadInt64();

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        Literals = new(this, (int)nLiterals, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        Parameters = new(this, (int)nParameters, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        OuterValues = new(this, (int)nOuterValues, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        LocalVarInfos = new(this, (int)nLocalVarInfos, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        LineInfos = new(this, (int)nLineInfos, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        DefaultParams = new(this, (int)nDefaultParams, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        Instructions = new(this, (int)nInstructions, br);

        if (!NutUtils.ConfirmPart(br)) throw new Exception($"PART missing at position: {br.BaseStream.Position}");
        Functions = new(this, (int)nFunctions, br);

        StackSize = br.ReadInt64();
        IsGenerator = br.ReadByte();
        VarParams = br.ReadInt64();
    }

    public void Write(BinaryWriter writer)
    {
        NutUtils.WritePart(writer);
        SourceName.Write(writer);
        Name.Write(writer);

        NutUtils.WritePart(writer);
        writer.Write(nLiterals);
        writer.Write(nParameters);
        writer.Write(nOuterValues);
        writer.Write(nLocalVarInfos);
        writer.Write(nLineInfos);
        writer.Write(nDefaultParams);
        writer.Write(nInstructions);
        writer.Write(nFunctions);

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nLiterals; i++)
        {
            Literals[i].Write(writer);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nParameters; i++)
        {
            Parameters[i].Write(writer);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nOuterValues; i++)
        {
            OuterValues[i].Write(writer);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nLocalVarInfos; i++)
        {
            LocalVarInfos[i].Write(writer);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nLineInfos; i++)
        {
            LineInfos[i].Write(writer);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nDefaultParams; i++)
        {
            writer.Write(DefaultParams[i]);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nInstructions; i++)
        {
            Instructions[i].Write(writer);
        }

        NutUtils.WritePart(writer);
        for (int i = 0; i < (int)nFunctions; i++)
        {
            Functions[i].Write(writer);
        }

        writer.Write(StackSize);
        writer.Write(IsGenerator);
        writer.Write(VarParams);
    }
}
