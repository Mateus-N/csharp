using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

internal class Ihit : TemplateDeImpostoCondicional
{
    public Ihit()
    {
    }

    public Ihit(Imposto outroImposto) : base(outroImposto)
    {
    }

    public override bool DeveUsarMaximataxacao(Orcamento orcamento)
    {
        IList<string> noOrcamento = new List<string>();

        foreach (Item item in orcamento.Items)
        {
            if (noOrcamento.Contains(item.Nome))
                return true;
            else
                noOrcamento.Add(item.Nome);
        }

        return false;
    }

    public override double MaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.Valor * 0.13 + 100;
    }

    public override double Minimataxacao(Orcamento orcamento)
    {
        return orcamento.Valor * (0.01 * orcamento.Items.Count);
    }
}
