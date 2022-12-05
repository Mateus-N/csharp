IDictionary<string, Aluno> sorted = new SortedDictionary<string, Aluno>
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