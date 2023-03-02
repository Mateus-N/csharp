using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data;

public class AgendaContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Compromisso> Compromissos { get; set; }

    public AgendaContext(DbContextOptions<AgendaContext> opts) : base(opts)
    {
    }
}
