namespace CursoDesignPatterns.Impostos.Interface;

public abstract class Imposto
{
    public Imposto? OutroImposto { get; set; }

    protected Imposto()
    {
        OutroImposto = null;
    }

    protected Imposto(Imposto outroImposto)
    {
        OutroImposto = outroImposto;
    }

    public abstract double Calcula(Orcamento orcamento);

    protected double CalculoDoOutroImposto(Orcamento orcamento)
    {
        if (OutroImposto == null) return 0;
        return OutroImposto.Calcula(orcamento);
    }
}