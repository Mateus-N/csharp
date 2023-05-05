using AutoMapper;
using IdentityCurso.Data.Dtos;
using IdentityCurso.Models;

namespace IdentityCurso.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
