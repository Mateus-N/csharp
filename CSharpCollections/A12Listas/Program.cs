static void Imprimir(List<string> aulas)
{
    //for (int i = 0; i < aulas.Count; i++)
    //{
    //    Console.WriteLine(aulas[i]);
    //}

    aulas.ForEach(aula =>
    {
        Console.WriteLine(aula);
    });
}



string aulaIntro = "Introdução às Coleções";
string aulaModelando = "Modelando a Classe Aula";
string aulaSets = "Trabalhando com Conjuntos";

//List<string> aulas = new List<string>
//{
//    aulaIntro,
//    aulaModelando,
//    aulaSets
//};

List<string> aulas = new List<string>
{
    aulaIntro,
    aulaModelando,
    aulaSets
};

Imprimir(aulas);

Console.WriteLine($"A primeira aula é {aulas[0]}");
Console.WriteLine($"A primeira aula é {aulas.First()}");
Console.WriteLine($"A ultima aula é {aulas[^1]}");
Console.WriteLine($"A ultima aula é {aulas.Last()}");

aulas[0] = "Trabalhando com listas";

Imprimir(aulas);

Console.WriteLine($"A primeira aula 'trabalhando' é: {aulas.First(aula => aula.Contains("Trabalhando"))}");
Console.WriteLine($"A ultima aula 'trabalhando' é: {aulas.Last(aula => aula.Contains("Trabalhando"))}");
Console.WriteLine($"A primeira aula 'conclusão' é: {aulas.FirstOrDefault(aula => aula.Contains("Conclusão"))}");

aulas.Reverse();
Imprimir(aulas);

aulas.RemoveAt(aulas.Count - 1);
Imprimir(aulas);

aulas.Add("Conclusão");
aulas.Sort();

List<string> copia = aulas.GetRange(aulas.Count - 2, 2);
Imprimir(copia);

List<string> clone = new List<string>(aulas);