using System;

class program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Executando o projeto 5 - Caracteres e Textos");

        char letra = 'a';
        Console.WriteLine(letra);

        letra = (char)65;
        Console.WriteLine(letra);

        letra = (char)(65 + 1);
        Console.WriteLine(letra);

        string primeirafrase = "Alura - Cursos de tecnologia ";
        Console.WriteLine(primeirafrase + 2022);

        string vazia = "";
        Console.WriteLine(vazia);

        string cursos = "Cursos disponíveis: - Go - C# - Python - Java";
        Console.WriteLine(cursos);

        string saudacao = "Olá, meu nome é ";
        string nome = "Rômulo ";
        string continuacao = "e minha idade é ";
        int idade = 100;
        Console.WriteLine(saudacao + nome + continuacao + idade);

        Console.WriteLine("Tecle enter para fechar ...");
        Console.ReadLine();
    }
}
