using Features.Clientes;
using Xunit;

namespace Features.Tests._02_Fixtures;

[Collection(nameof(ClienteCollection))]
public class ClienteFixtureTesteInvalido
{
    private readonly ClienteTestesFixture clienteFixture;

    public ClienteFixtureTesteInvalido(ClienteTestesFixture clienteFixture)
    {
        this.clienteFixture = clienteFixture;
    }

    [Fact(DisplayName = "Novo cliente inválido")]
    public void Cliente_NovoCliente_DeveEstarInvalido()
    {
        // Arrange
        Cliente cliente = clienteFixture.GerarClienteInvalido();

        // Act
        bool result = cliente.EhValido();

        // Assert
        Assert.False(result);
        Assert.NotEmpty(cliente.ValidationResult.Errors);
    }
}
