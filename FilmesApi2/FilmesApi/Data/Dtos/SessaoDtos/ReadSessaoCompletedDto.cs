using FilmesApi2.Models;

namespace FilmesApi2.Data.Dtos;

public class ReadSessaoCompletedDto
{
	public ReadFilmeOnlyDto Filme { get; set; }
	public ReadCinemaOnlyDto Cinema { get; set; }
}