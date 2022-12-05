List<string> frutas = new()
{
    "abacate", "banana", "caqui", "damasco", "figo"
};

foreach (var fr in frutas)
{
    Console.WriteLine(fr);
}

LinkedList<string> dias = new();
var d4 = dias.AddFirst("quarta");

Console.WriteLine(d4.Value);

var d2 = dias.AddBefore(d4, "segunda");

var d3 = dias.AddAfter(d2, "terça");

var d6 = dias.AddAfter(d4, "sexta");

var d7 = dias.AddAfter(d6, "sabado");

var d5 = dias.AddBefore(d6, "quinta");

var d1 = dias.AddBefore(d2, "Domingo");

foreach (var dia in dias)
{
    Console.WriteLine(dia);
}