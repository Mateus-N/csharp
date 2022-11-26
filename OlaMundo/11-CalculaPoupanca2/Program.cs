using System;

class program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Executando o Projeto 10 - Calcula Poupanca");

        double investimento = 1000;

        // rendimento de 0.5% (0.005) ao mês
        /*
        int mes = 1;

        while (mes <= 12)
        {
            investimento += investimento * 0.005;
            mes += 1;
        }
        */

        for (int mes = 1; mes <= 12; mes++)
        {
            investimento += investimento * 0.005;
        }

        Console.WriteLine(investimento);

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}
