namespace FilmesApi2.Data.Dtos;

public class ReadCinemaOnlyDto
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public ReadEnderecoDto Endereco { get; set; }
}