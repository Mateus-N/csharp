using IdentityCurso.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityCurso.Data;

public class UsuarioDbContext : IdentityDbContext<Usuario>
{
    public UsuarioDbContext
        (DbContextOptions<UsuarioDbContext> opts) : base(opts)
    { }
}
