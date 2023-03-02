using System.ComponentModel.DataAnnotations;

namespace Agenda.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string Name { get; set; }
}
