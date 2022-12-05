IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>
{
    { "VT", new Aluno("Vanessa", 34672) },
    { "AL", new Aluno("Ana", 56172) },
    { "RN", new Aluno("Rafael", 17237) },
    { "WM", new Aluno("Wanderson", 21654) }
};

foreach (var aluno in alunos)
{
    Console.WriteLine(aluno);
}

alunos.Remove("AL");
alunos.Add("MO", new Aluno("Marcelo", 12345));

Console.WriteLine();
foreach (var aluno in alunos)
{
    Console.WriteLine(aluno);
}

IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>
{
    { "VT", new Aluno("Vanessa", 34672) },
    { "AL", new Aluno("Ana", 56172) },
    { "RN", new Aluno("Rafael", 17237) },
    { "WM", new Aluno("Wanderson", 21654) }
};

foreach (var aluno in sorted)
{
    Console.WriteLine(aluno);
}