namespace CursoDesignPatterns.Nota.AposGerarNota;

internal class EnviadorDeSms : AposGerarNotaFiscal
{
    public void Executar(NotaFiscal nf)
    {
        Console.WriteLine(nf); ;
    }
}
