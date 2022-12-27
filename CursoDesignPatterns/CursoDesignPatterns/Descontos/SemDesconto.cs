using CursoDesignPatterns.Descontos.Interface;

namespace CursoDesignPatterns.Descontos;

internal class SemDesconto : IDesconto
{
    public IDesconto Proximo { get; set; }

    public double Desconta(Orcamento orcamento)
    {
        return 0;
    }
}
