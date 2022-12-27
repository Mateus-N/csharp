namespace CursoDesignPatterns.Descontos.Interface;

internal interface IDesconto
{
    public IDesconto Proximo { get; set; }

    public double Desconta(Orcamento orcamento);
}
