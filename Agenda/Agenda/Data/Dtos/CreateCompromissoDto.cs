using System.ComponentModel.DataAnnotations;

namespace Agenda.Data.Dtos;

public class CreateCompromissoDto
{
    [Required]
    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    [Required]
    public DateTime DataEHorario { get; set; }

    [Required]
    public Guid UsuarioId { get; set; }
}
