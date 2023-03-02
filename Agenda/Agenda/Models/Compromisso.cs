using System.ComponentModel.DataAnnotations;

namespace Agenda.Models;

public class Compromisso
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    public string? Descricao { get; set; }

    [Required]
    public DateTime DataEHorario { get; set; }

    [Required]
    public Guid UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }
}
