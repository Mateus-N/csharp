using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos;

public class CreateSessaoDto
{
	[Required]
	public int FilmeId { get; set; }
	[Required]
	public int CinemaId { get; set; }
}