using Agenda.Models;

namespace Agenda.Data.Dtos;

public class ReadUsuarioComCompromissosDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<ReadCompromisso> Compromissos { get; set; }
}
