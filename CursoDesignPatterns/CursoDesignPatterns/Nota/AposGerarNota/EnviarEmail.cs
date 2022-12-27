namespace CursoDesignPatterns.Nota.AposGerarNota;

internal class EnviarEmail : AposGerarNotaFiscal
{
    public void Executar(NotaFiscal nf)
    {
        Console.WriteLine(nf);
    }
}
