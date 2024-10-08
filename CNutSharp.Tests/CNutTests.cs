using CNutSharp.Library.Models;

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
}