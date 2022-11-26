using System;

class program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Executando projeto 13 - Encadeando for");

        for (int contadorLinha = 0; contadorLinha < 10; contadorLinha++)
        {
            for (int contadorColuas = 0; contadorColuas <= contadorLinha; contadorColuas++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}
