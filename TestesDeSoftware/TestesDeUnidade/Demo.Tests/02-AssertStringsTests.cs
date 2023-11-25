using Xunit;

namespace Demo.Tests;

public class AssertStringsTests
{
    [Fact]
    public void StringTools_UnirNomes_RetornarNomeCompleto()
    {
        // Arrange
        StringTools sut = new();

        // Act
        string nomeCompleto = sut.Unir("Eduardo", "Pires");

        // Assert
        Assert.Equal("Eduardo Pires", nomeCompleto);
    }

    [Fact]
    public void StringTools_UnirNomes_DeveIgnorarCase()
    {
        // Arrange
        StringTools sut = new();

        // Act
        string nomeCompleto = sut.Unir("Eduardo", "Pires");

        // Assert
        Assert.Equal("EDUARDO PIRES", nomeCompleto, true);
    }

    [Fact]
    public void StringTools_UnirNomes_DeveConterTrecho()
    {
        // Arrange
        StringTools sut = new();

        // Act
        string nomeCompleto = sut.Unir("Eduardo", "Pires");

        // Assert
        Assert.Contains("ardo", nomeCompleto);
    }

    [Fact]
    public void StringTools_UnirNomes_DeveComecarCom()
    {
        // Arrange
        StringTools sut = new();

        // Act
        string nomeCompleto = sut.Unir("Eduardo", "Pires");

        // Assert
        Assert.StartsWith("Edu", nomeCompleto);
    }

    [Fact]
    public void StringTools_UnirNomes_DeveAcabarCom()
    {
        // Arrange
        StringTools sut = new();

        // Act
        string nomeCompleto = sut.Unir("Eduardo", "Pires");

        // Assert
        Assert.EndsWith("res", nomeCompleto);
    }

    [Fact]
    public void StringTools_UnirNomes_ValidaExpressaoRegular()
    {
        // Arrange
        StringTools sut = new();

        // Act
        string nomeCompleto = sut.Unir("Eduardo", "Pires");

        // Assert
        Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
    }
}
