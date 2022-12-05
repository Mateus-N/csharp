string[,] resultados = new string[3, 3];
//{
//    { "Alemanha", "Espanha", "Itália" },
//    { "Argentina", "Holanda", "França" },
//    { "Holanda", "Alemanha", "Alemanha" }
//};

resultados[0, 0] = "Alemanha";
resultados[1, 0] = "Argentina";
resultados[2, 0] = "Holanda";

resultados[0, 1] = "Espanha";
resultados[1, 1] = "Holanda";
resultados[2, 1] = "Alemanha";

resultados[0, 2] = "Itália";
resultados[1, 2] = "França";
resultados[2, 2] = "Alemanha";


for (int copa = 0; copa < 3; copa++)
{
    int ano = 2014 - copa * 4;
    Console.Write(ano.ToString().PadRight(12));
}
Console.WriteLine();

for (int posicao = 0; posicao <= resultados.GetUpperBound(0); posicao++)
{
    for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
    {
        Console.Write(resultados[posicao, copa].PadRight(12));
    }
    Console.WriteLine();
}