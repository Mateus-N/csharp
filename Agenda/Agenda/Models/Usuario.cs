using System.ComponentModel.DataAnnotations;

namespace Agenda.Models;

public class Usuario
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Compromisso> Compromissos { get; set; }
}
