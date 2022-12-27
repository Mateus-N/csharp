namespace Web
{
    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Livro(string codigo, string nome, double preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }
    }
}
