namespace Demo;

public class Pessoa
{
    public string Nome { get; protected set; }
    public string? Apelido { get; set; }

    public Pessoa(string nome)
    {
        Nome = string.IsNullOrEmpty(nome) ? "Fulano" : nome;
    }
}
