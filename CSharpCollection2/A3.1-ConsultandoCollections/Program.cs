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

//meses.Sort();

//foreach (Mes mes in meses)
//{
//    if (mes.Dias == 31)
//    {
//        Console.WriteLine(mes.Nome.ToUpper());
//    }
//}

// LINQ Consulta integrada a linguagem

IEnumerable<string>
    consulta = meses
        .Where(mes => mes.Dias == 31)
        .OrderBy(mes => mes.Nome)
        .Select(mes => mes.Nome.ToUpper());


foreach (var item in consulta)
{
    Console.WriteLine(item);
}
