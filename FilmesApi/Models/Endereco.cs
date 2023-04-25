using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Models;

public class Endereco
{
	[Key]
	[Required]
	public int Id { get; set; }
	public string Logradouro { get; set; }
	public int Numero { get; set; }
	public virtual Cinema cinema { get; set; }
}