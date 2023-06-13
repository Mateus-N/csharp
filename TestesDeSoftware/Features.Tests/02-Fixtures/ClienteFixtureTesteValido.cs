using Features.Clientes;
using Xunit;

namespace Features.Tests._02_Fixtures;

[Collection(nameof(ClienteCollection))]
public class ClienteFixtureTesteValido
{
    private readonly ClienteTestesFixture clienteFixture;

    public ClienteFixtureTesteValido(ClienteTestesFixture clienteFixture)
    {
        this.clienteFixture = clienteFixture;
    }


    [Fact(DisplayName = "Novo cliente válido")]
    public void Cliente_NovoCliente_DeveEstarValido()
    {
        // Arrange
        Cliente cliente = clienteFixture.GerarClienteValido();

        // Act
        bool result = cliente.EhValido();

        // Assert
        Assert.True(result);
        Assert.Empty(cliente.ValidationResult.Errors);
    }
}
