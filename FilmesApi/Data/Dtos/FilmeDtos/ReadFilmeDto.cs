namespace FilmesApi2.Data.Dtos;

public class ReadFilmeDto
{
	public int Id { get; set; }
	public string Titulo { get; set; }
	public string Genero { get; set; }
	public int Duracao { get; set; }
	public ICollection<ReadSessaoDto> Sessoes { get; set; }
}