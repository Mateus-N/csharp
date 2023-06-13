using Features.Clientes;
using Xunit;

namespace Features.Tests._01_Traits;

public class ClienteTestes
{
    [Fact(DisplayName = "Novo cliente válido")]
    public void Cliente_NovoCliente_DeveEstarValido()
    {
        // Arrange
        Cliente cliente = new(
            Guid.NewGuid(),
            "Mateus",
            "Nunes",
            DateTime.Now.AddYears(-22),
            "mateus@email.com",
            true,
            DateTime.Now);

        // Act
        bool result = cliente.EhValido();

        // Assert
        Assert.True(result);
        Assert.Empty(cliente.ValidationResult.Errors);
    }

    [Fact(DisplayName = "Novo cliente inválido")]
    public void Cliente_NovoCliente_DeveEstarInvalido()
    {
        // Arrange
        Cliente cliente = new(
            Guid.NewGuid(),
            "",
            "",
            DateTime.Now,
            "mateus2email.com",
            true,
            DateTime.Now);

        // Act
        bool result = cliente.EhValido();

        // Assert
        Assert.False(result);
        Assert.NotEmpty(cliente.ValidationResult.Errors);
    }
}
