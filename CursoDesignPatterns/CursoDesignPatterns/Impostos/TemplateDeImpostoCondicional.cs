using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

internal abstract class TemplateDeImpostoCondicional : Imposto
{


    protected TemplateDeImpostoCondicional(Imposto outroImposto) : base(outroImposto)
    {
    }

    protected TemplateDeImpostoCondicional()
    {
    }

    public override double Calcula(Orcamento orcamento)
    {
        if (DeveUsarMaximataxacao(orcamento))
        {
            return MaximaTaxacao(orcamento) + CalculoDoOutroImposto(orcamento);
        }

        return Minimataxacao(orcamento) + CalculoDoOutroImposto(orcamento);
    }

    public abstract double Minimataxacao(Orcamento orcamento);
    public abstract double MaximaTaxacao(Orcamento orcamento);
    public abstract bool DeveUsarMaximataxacao(Orcamento orcamento);
}
