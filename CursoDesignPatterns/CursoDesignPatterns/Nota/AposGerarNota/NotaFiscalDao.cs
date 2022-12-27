namespace CursoDesignPatterns.Nota.AposGerarNota;

internal class NotaFiscalDao : AposGerarNotaFiscal
{
    public void Executar(NotaFiscal nf)
    {
        Console.WriteLine(nf);
    }
}
