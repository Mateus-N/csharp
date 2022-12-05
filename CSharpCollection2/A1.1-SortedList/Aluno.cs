internal class Aluno
{
    public string Nome { get; }
    public int NumeroMatricula { get; }

    public Aluno(string nome, int numeroMatricula)
    {
        Nome = nome;
        NumeroMatricula = numeroMatricula;
    }

    public override string ToString()
    {
        return $"Aluno: {Nome}, matricula: {NumeroMatricula}";
    }
}
