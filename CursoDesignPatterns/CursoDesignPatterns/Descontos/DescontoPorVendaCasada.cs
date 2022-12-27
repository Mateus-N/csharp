using CursoDesignPatterns.Descontos.Interface;

namespace CursoDesignPatterns.Descontos;

internal class DescontoPorVendaCasada : IDesconto
{
    public IDesconto Proximo { get; set; }

    public double Desconta(Orcamento orcamento)
    {
        if (AconteceuVendaCasadaEm(orcamento))
        {
            return orcamento.Valor * 0.05;
        }

        return Proximo.Desconta(orcamento);
    }

    private static bool AconteceuVendaCasadaEm(Orcamento orcamento)
    {
        return Existe("LAPIS", orcamento) && Existe("CANETA", orcamento);
    }

    private static bool Existe(string nomeDoItem, Orcamento orcamento)
    {
        foreach (Item item in orcamento.Items)
        {
            if (item.Nome.Equals(nomeDoItem))
                return true;
        }

        return false;
    }
}
