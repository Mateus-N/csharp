// SETS = Conjuntos

// Duas propriedades
// Não permite duplicidade
// Não tem ordem específica

ISet<string> alunos = new HashSet<string>();

alunos.Add("Vanessa Tonini");
alunos.Add("Ana Losnak");
alunos.Add("Rafael Nercessian");
alunos.Add("Priscila Stuani");
alunos.Add("Rafael Rollo");
alunos.Add("Fabio Lucindo");

Console.WriteLine(string.Join(", ", alunos));

alunos.Remove("Ana Losnak");
alunos.Add("Marcos Crespe");