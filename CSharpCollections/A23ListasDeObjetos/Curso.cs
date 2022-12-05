using System.Collections.ObjectModel;

namespace A23ListasDeObjetos
{
    internal class Curso
    {
        private readonly IList<Aula> _aulas;
        public string Nome { get; set; }
        public string Instrutor { get; set; }

        public IList<Aula> Aulas
        {
            get { return new ReadOnlyCollection<Aula>(_aulas); }
        }

        public Curso(string nome, string instrutor)
        {
            Nome = nome;
            Instrutor = instrutor;
            _aulas = new List<Aula>();
        }

        public void Adiciona(Aula aula)
        {
            _aulas.Add(aula);
        }

        // LINQ = Language Integrated Query
        // Consulta Integrada à Linguagem

        public int TempoTotal => _aulas.Sum(aula => aula.Tempo);

        public override string ToString()
        {
            return $"Curso: {Nome}, Tempo: {TempoTotal}, Aulas: {string.Join(", ", _aulas)}";
        }
    }
}
