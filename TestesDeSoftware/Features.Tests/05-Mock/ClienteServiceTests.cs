using Features.Clientes;
using Features.Tests._04_DadosHumanos;
using MediatR;
using Moq;
using Xunit;

namespace Features.Tests._05_Mock;

[Collection(nameof(ClienteBogusCollection))]
public class ClienteServiceTests
{
    private readonly ClienteTestsBogusFixture clienteTestsBogus;

    public ClienteServiceTests(ClienteTestsBogusFixture clienteTestsBogus)
    {
        this.clienteTestsBogus = clienteTestsBogus;
    }

    [Fact(DisplayName = "Adicionar cliente com sucessso")]
    public void ClienteService_Adicionar_DeveExecutarComSucesso()
    {
        // Arrange
        Cliente cliente = clienteTestsBogus.GerarClienteValido();
        Mock<IClienteRepository> clienteRepo = new();
        Mock<IMediator> mediatr = new();

        ClienteService clienteService = new(clienteRepo.Object, mediatr.Object);

        // Act
        clienteService.Adicionar(cliente);

        // Assert
        Assert.True(cliente.EhValido());
    }

    [Fact(DisplayName = "Adicionar cliente com falha")]
    public void CLienteService_Adicionar_DeveFalharDevidoClienteInvalido()
    {

    }
}
