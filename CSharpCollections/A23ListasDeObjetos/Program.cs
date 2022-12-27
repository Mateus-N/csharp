using A23ListasDeObjetos;

static void Imprimir(IList<Aula> aulas)
{
    foreach (var aula in aulas)
    {
        Console.WriteLine(aula);
    }
}


Curso cSharpColecoes = new("C# Collections", "Marcelo Oliveira");
cSharpColecoes.Adiciona(new Aula("Trabalhando com listas", 20));
cSharpColecoes.Adiciona(new Aula("Criando uma aula", 20));
cSharpColecoes.Adiciona(new Aula("Modelando com coleções", 19));
Imprimir(cSharpColecoes.Aulas);

List<Aula> aulasCopiadas = new List<Aula>(cSharpColecoes.Aulas);

aulasCopiadas.Sort();
Imprimir(aulasCopiadas);


Console.WriteLine(cSharpColecoes.TempoTotal);


Console.WriteLine(cSharpColecoes);
//var aulaIntro = new Aula("Introdução às Coleções", 20);
//var aulaModelando = new Aula("Modelando a Classe Aula", 18);
//var aulaSets = new Aula("Trabalhando com Conjuntos", 16);

//List<Aula> aulas = new()
//{
//    aulaIntro,
//    aulaModelando,
//    aulaSets
//};

//aulas.Sort();
//Imprimir(aulas);

//aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));
//Imprimir(aulas);