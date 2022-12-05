string[] seq1 = { "janeiro", "fevereiro", "março" };
string[] seq2 = { "fevereiro", "MARÇO", "abril" };

var consulta = seq1.Concat(seq2);

foreach (var item in consulta)
{
    Console.WriteLine(item);
}
Console.WriteLine();

var consulta2 = seq1.Union(seq2);

foreach (var item in consulta2)
{
    Console.WriteLine(item);
}
Console.WriteLine();

var consulta3 = seq1.Union(seq2, StringComparer.InvariantCultureIgnoreCase);

foreach (var item in consulta3)
{
    Console.WriteLine(item);
}
Console.WriteLine();

var consulta4 = seq1.Intersect(seq2);

foreach (var item in consulta4)
{
    Console.WriteLine(item);
}
Console.WriteLine();

var consulta5 = seq1.Except(seq2);

foreach (var item in consulta5)
{
    Console.WriteLine(item);
}
