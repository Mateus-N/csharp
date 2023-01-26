using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace AluraByteBankInfraestrututraTestes;

public class ContaCorrenteRepositorioTestes
{
    private readonly IContaCorrenteRepositorio repositorio;

    public ContaCorrenteRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
        var provedor = servico.BuildServiceProvider();
        this.repositorio = provedor.GetService<IContaCorrenteRepositorio>();
    }

    [Fact]
    public void TestaObterTodasContasCorrente()
    {
        List<ContaCorrente> lista = repositorio.ObterTodos();

        Assert.NotNull(lista);
    }

    [Fact]
    public void TestaObterContaCorrentePorId()
    {
        var contaCorrente = repositorio.ObterPorId(3);

        Assert.NotNull(contaCorrente);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public void TestaObterContasConrrentePorVariosId(int id)
    {
        var contaCorrente = repositorio.ObterPorId(id);

        Assert.NotNull(contaCorrente);
    }

    [Fact]
    public void TestaAtualizaSaldoDeterminadaConta()
    {
        var contaCorrente = repositorio.ObterPorId(3);
        double saldoNovo = 15;
        contaCorrente.Saldo = saldoNovo;

        var atualizado = repositorio.Atualizar(3, contaCorrente);

        Assert.True(atualizado);
    }
}
