using Microsoft.AspNetCore.Identity;

namespace IdentityCurso.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }

    public Usuario() : base() { }
}
