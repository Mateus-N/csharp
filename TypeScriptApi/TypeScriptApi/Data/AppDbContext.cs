using Microsoft.EntityFrameworkCore;
using TypeScriptApi.Models;

namespace TypeScriptApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Dado> Dados { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base (opts)
    {
    }
}
