using System;

class program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Executando o projeto 12 - Investimento a longo prazo");

        double fatorRendimento = 1.005;
        double investimento = 1000;

        for (int anos = 1; anos <= 5; anos++)
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                investimento *= fatorRendimento;
            }

            fatorRendimento += 0.001;
        }

        Console.WriteLine($"Depois de 5 anos você terá {investimento}");

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}
