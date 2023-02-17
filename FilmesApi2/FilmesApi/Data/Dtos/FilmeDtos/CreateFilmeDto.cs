using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos;

public class CreateFilmeDto
{
	[Required(ErrorMessage = "O campo título é obrigatório")]
	public string Titulo { get; set; }
	//
	[Required(ErrorMessage = "O campo gênero é obrigatório")]
	[StringLength(50, ErrorMessage = "O tamanho do Genero não pode exceder 50 caracteres")]
	public string Genero { get; set; }
	//
	[Required(ErrorMessage = "O campo duracao é obrigatorio")]
	[Range(70, 600, ErrorMessage = "A duração deve ter no mínimo 70 e no máximo 600 minutos")]
	public int Duracao { get; set; }
}