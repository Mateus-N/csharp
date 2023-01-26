using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace AluraByteBankInfraestrututraTestes;

public class AgenciaRepositorioTestes
{
    private readonly IAgenciaRepositorio repositorio;

    public AgenciaRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
        var provedor = servico.BuildServiceProvider();
        this.repositorio = provedor.GetService<IAgenciaRepositorio>();
    }

    [Fact]
    public void TestaObterTodasAgencias()
    {
        List<Agencia> lista = repositorio.ObterTodos();

        Assert.NotNull(lista);
    }

    [Fact]
    public void TestaObterAgenciaPorId()
    {
        var agencia = repositorio.ObterPorId(3);

        Assert.NotNull(agencia);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public void TestaObterAgenciaPorVariosId(int id)
    {
        var agencia = repositorio.ObterPorId(id);

        Assert.NotNull(agencia);
    }
}
