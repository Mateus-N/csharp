ISet<string> alunos = new SortedSet<string>(new ComparadorMinusculo())
{
    "Vanessa Tonini",
    "Ana Losnak",
    "Rafael Nercessian",
    "Priscila Stuani",
    "Rafael Rollo",
    "Fabio Gushiken",
    "FABIO GUSHIKEN"
};

foreach (var aluno in alunos)
{
    Console.WriteLine(aluno);
}

ISet<string> outroConjunto = new HashSet<string>();

alunos.IsSubsetOf(outroConjunto);

alunos.IsSupersetOf(outroConjunto);

alunos.SetEquals(outroConjunto);

alunos.ExceptWith(outroConjunto);

alunos.IntersectWith(outroConjunto);

alunos.SymmetricExceptWith(outroConjunto);

alunos.UnionWith(outroConjunto);