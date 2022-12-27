using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

public class Icms : Imposto
{
    public Icms()
    {
    }

    public Icms(Imposto outroImposto) : base(outroImposto)
    {
    }

    public override double Calcula(Orcamento orcamento)
    {
        return orcamento.Valor * 0.05 + 50 + CalculoDoOutroImposto(orcamento);
    }
}
