using Xunit;

namespace Demo.Testes;

public class CalculadoraTestes
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
    [InlineData(3, 4, 7)]
    [InlineData(1, 1, 2)]
    [InlineData(2, 4, 6)]
    [InlineData(9, 4, 13)]
    public void Calculadora_Somar_RetornarValoresSomaCorretos(double v1, double v2, double total)
    {
        // Arrange
        Calculadora calculadora = new();
        // Act
        double resultado = calculadora.Somar(v1, v2);
        // Assert
        Assert.Equal(total, resultado);
    }
}
