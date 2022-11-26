using System;

class program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Executando projeto 7 - ACondicionais");

        int idadeJoao = 16;
        int quantidadePessoas = 2;

        if (idadeJoao >= 18)
        {
            Console.WriteLine("Pode entrar");
        }
        else
        {
            if (quantidadePessoas > 0)
            {
                Console.WriteLine("Ele está acompanhado, pode entrar");
            }
            else
            {
                Console.WriteLine("Não pode entrar");
            }
        }

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}
