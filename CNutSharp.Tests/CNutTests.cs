using CNutSharp.Library.Models;
using CNutSharp.Library.Squirrel;

namespace CNutSharp.Tests;

public class CNutTests
{
    [Theory]
    [InlineData("Files/64/ackermann.cnut")]
    public void CNut_WriteOutputSameAsInput(string inputFile)
    {
        // Arrange
        var inputBytes = File.ReadAllBytes(inputFile);

        // Act
        var cnut = new CNut(inputFile);
        var memStream = new MemoryStream();
        cnut.Write(memStream);

        var cnutBytes = memStream.ToArray();

        // Assert
        Assert.True(inputBytes.Length != 0);
        Assert.Equal(inputBytes, cnutBytes);
    }

    [Fact]
    public void Nut_CompilerWorks()
    {
        var compilerPath = "Squirrel/Compiler/sq.exe";
        var compiler = new SqCompiler(compilerPath);

        var nutFile = "Files/64/ackermann_c.cnut";
        compiler.Compile(nutFile);

        Assert.True(File.Exists(nutFile));
    }
}