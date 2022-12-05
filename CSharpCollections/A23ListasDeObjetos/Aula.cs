namespace A23ListasDeObjetos
{
    internal class Aula : IComparable
    {
        public string Titulo { get; set; }
        public int Tempo { get; set; }

        public Aula(string titulo, int tempo)
        {
            Titulo = titulo;
            Tempo = tempo;
        }

        public override string ToString()
        {
            return $"Aula: {Titulo}, com duração: {Tempo} minutos";
        }

        public int CompareTo(object obj)
        {
            Aula that = obj as Aula;
            return Titulo.CompareTo(that.Titulo);
        }
    }
}
