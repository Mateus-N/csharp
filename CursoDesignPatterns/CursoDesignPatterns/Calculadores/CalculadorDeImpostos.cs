using CursoDesignPatterns.Impostos.Interface;

namespace CursoDesignPatterns.Calculadores;

internal class CalculadorDeImpostos
{
    public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
    {
        double icms = imposto.Calcula(orcamento);
        Console.WriteLine(icms);
    }
}
