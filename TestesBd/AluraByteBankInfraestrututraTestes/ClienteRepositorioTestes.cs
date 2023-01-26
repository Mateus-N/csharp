using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace AluraByteBankInfraestrututraTestes;

public class ClienteRepositorioTestes
{
    private readonly IClienteRepositorio repositorio;

    public ClienteRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
        var provedor = servico.BuildServiceProvider();
        this.repositorio = provedor.GetService<IClienteRepositorio>();
    }

    [Fact]
    public void TestaObterTodosClientes()
    {
        List<Cliente> lista = repositorio.ObterTodos();

        Assert.NotNull(lista);
        Assert.Equal(5, lista.Count);
    }

    [Fact]
    public void TestaObterClientePorId()
    {
        var cliente = repositorio.ObterPorId(4);

        Assert.NotNull(cliente);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(5)]
    public void TestaObterClientePorVariosId(int id)
    {
        var cliente = repositorio.ObterPorId(id);

        Assert.NotNull(cliente);
    }
}
