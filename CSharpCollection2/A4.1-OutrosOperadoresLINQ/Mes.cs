internal class Mes
{
    public string Nome { get; private set; }
    public int Dias { get; private set; }

    public Mes(string nome, int dias)
    {
        Nome = nome;
        Dias = dias;
    }

    public override string ToString()
    {
        return $"Mês: {Nome}, dias: {Dias}";
    }
}