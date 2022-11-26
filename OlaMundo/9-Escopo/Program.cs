using System;

class program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Executando projeto 7 - ACondicionais");

        int idadeJoao = 16;
        int quantidadePessoas = 2;

        bool grupo = quantidadePessoas > 1;

        string textoAdicional;

        if (grupo)
        {
            textoAdicional = "João está acompanhado";
        }
        else
        {
            textoAdicional = "João não está acompanhado";
        }

        if (idadeJoao >= 18 || grupo)
        {
            Console.WriteLine(textoAdicional);
            Console.WriteLine("Pode entrar");
        }
        else
        {
            Console.WriteLine(textoAdicional);
            Console.WriteLine("Não pode entrar");

        }

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}
