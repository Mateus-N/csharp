using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

internal class Iss : Imposto
{
    public Iss()
    {
    }

    public Iss(Imposto outroImposto) : base(outroImposto)
    {
    }

    public override double Calcula(Orcamento orcamento)
    {
        return orcamento.Valor * 0.06 + CalculoDoOutroImposto(orcamento);
    }
}
