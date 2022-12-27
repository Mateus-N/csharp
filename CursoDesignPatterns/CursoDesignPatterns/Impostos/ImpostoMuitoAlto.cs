using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

internal class ImpostoMuitoAlto : Imposto
{
    public ImpostoMuitoAlto()
    {
    }

    public ImpostoMuitoAlto(Imposto outroImposto) : base(outroImposto)
    {
    }

    public override double Calcula(Orcamento orcamento)
    {
        return orcamento.Valor * 0.2;
    }
}
