using CursoDesignPatterns.Nota;
using CursoDesignPatterns.Nota.AposGerarNota;

public class NotaFiscalBuilder
{
    public string? RazaoSocial { get; private set; }
    public string? Cnpj { get; private set; }
    public string? Observacoes { get; private set; }

    private DateTime DataDeEmissao = DateTime.Now;
    private double ValorTotal;
    private double Impostos;
    private IList<ItemDaNota> TodosItens = new List<ItemDaNota>();
    private IList<AposGerarNotaFiscal> TodasAcoesASeremExecutadas = new List<AposGerarNotaFiscal>();

    public NotaFiscal Constroi()
    {
        NotaFiscal nf = new NotaFiscal(RazaoSocial, Cnpj, DataDeEmissao, ValorTotal, Impostos, TodosItens, Observacoes);

        foreach (var acao in TodasAcoesASeremExecutadas)
        {
            acao.Executar(nf);
        }

        return nf;
    }

    public void AdicionaAcao(AposGerarNotaFiscal acao)
    {
        TodasAcoesASeremExecutadas.Add(acao);
    }

    public NotaFiscalBuilder ParaEmpresa(string razaoSocial)
    {
        RazaoSocial = razaoSocial;
        return this;
    }

    public NotaFiscalBuilder ComCnpj(string cnpj)
    {
        Cnpj = cnpj;
        return this;
    }

    public NotaFiscalBuilder Com(ItemDaNota item)
    {
        TodosItens.Add(item);
        ValorTotal += item.Valor;
        Impostos += item.Valor * 0.05;
        return this;
    }

    public NotaFiscalBuilder ComObservacoes(string observacoes)
    {
        Observacoes = observacoes;
        return this;
    }

    public NotaFiscalBuilder NaData(DateTime data)
    {
        DataDeEmissao = data;
        return this;
    }
}