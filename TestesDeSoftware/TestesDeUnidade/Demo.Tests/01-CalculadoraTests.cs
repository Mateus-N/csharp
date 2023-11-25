using Xunit;

namespace Demo.Tests;

public class CalculadoraTests
{
    [Fact]
    public void Calculadora_Somar_RetornarValorSoma()
    {
        // Arrange
        Calculadora calculadora = new();

        // Act
        double resultado = calculadora.Somar(2, 2);

        // Assert
        Assert.Equal(4, resultado);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(4, 2, 6)]
    [InlineData(7, 3, 10)]
    [InlineData(6, 6, 12)]
    [InlineData(9, 9, 18)]
    public void Calculadora_Somar_RetornarSomarDosValoresCorretos(double v1, double v2, double total)
    {
        // Arrange
        Calculadora calculadora = new();

        // Act
        double resultado = calculadora.Somar(v1, v2);

        // Assert
        Assert.Equal(total, resultado);
    }
}
