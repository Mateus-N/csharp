namespace CursoDesignPatterns.Nota;

internal class ItemDaNotaBuilder
{
    public string Nome { get; set; }
    public double Valor { get; set; }

    public ItemDaNota Constroi()
    {
        return new ItemDaNota(Nome, Valor);
    }

    public ItemDaNotaBuilder ComNome(string nome)
    {
        Nome = nome;
        return this;
    }

    public ItemDaNotaBuilder ComValor(double valor)
    {
        Valor = valor;
        return this;
    }
}
