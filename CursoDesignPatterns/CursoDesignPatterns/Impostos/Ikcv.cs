using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Impostos;

internal class Ikcv : TemplateDeImpostoCondicional
{


    public Ikcv(Imposto outroImposto) : base(outroImposto)
    {
    }

    public Ikcv()
    {
    }

    public override bool DeveUsarMaximataxacao(Orcamento orcamento)
    {
        return orcamento.Valor > 500 && TemItemMaiorQue100ReaisNo(orcamento);
    }

    public override double Minimataxacao(Orcamento orcamento)
    {
        return orcamento.Valor * 0.06;
    }

    public override double MaximaTaxacao(Orcamento orcamento)
    {
        return orcamento.Valor * 0.1;
    }

    private static bool TemItemMaiorQue100ReaisNo(Orcamento orcamento)
    {
        foreach (Item item in orcamento.Items)
        {
            if (item.Valor > 100) return true;
        }

        return false;
    }
}
