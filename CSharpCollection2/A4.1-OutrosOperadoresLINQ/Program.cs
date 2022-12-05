List<Mes> meses = new List<Mes>
{
    new Mes("Janeiro", 31),
    new Mes("Fevereiro", 28),
    new Mes("Março", 31),
    new Mes("Abril", 30),
    new Mes("Maio", 31),
    new Mes("Junho", 30),
    new Mes("Julho", 31),
    new Mes("Agosto", 31),
    new Mes("Setembro", 30),
    new Mes("Outubro", 31),
    new Mes("Novembro", 30),
    new Mes("Dezembro", 31)
};

var consulta = meses.Take(3);

foreach (var mes in consulta)
{
    Console.WriteLine(mes);
}
Console.WriteLine();

var consulta2 = meses.Skip(3);

foreach (var mes in consulta2)
{
    Console.WriteLine(mes);
}
Console.WriteLine();

var consulta3 = meses
                    .Skip(6)
                    .Take(3);

foreach (var mes in consulta3)
{
    Console.WriteLine(mes);
}
Console.WriteLine();

var consulta4 = meses.TakeWhile(mes => !mes.Nome.StartsWith('S'));

foreach (var mes in consulta4)
{
    Console.WriteLine(mes);
}
Console.WriteLine();

var consulta5 = meses.SkipWhile(mes => !mes.Nome.StartsWith('S'));

foreach (var mes in consulta5)
{
    Console.WriteLine(mes);
}