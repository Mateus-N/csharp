using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

internal class Icpp : TemplateDeImpostoCondicional
{
    public Icpp()
    {
    }

    public Icpp(Imposto outroImposto) : base(outroImposto)
    {
    }

    public override bool DeveUsarMaximataxacao(Orcamento orcamento)
    {
        return orcamento.Valor >= 500;
    }

    public override double MaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.Valor * 0.07;
    }

    public override double Minimataxacao(Orcamento orcamento)
    {
        return orcamento.Valor * 0.05;
    }
}
