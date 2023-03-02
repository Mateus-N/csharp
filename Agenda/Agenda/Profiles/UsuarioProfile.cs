using Agenda.Data.Dtos;
using Agenda.Models;
using AutoMapper;

namespace Agenda.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<Usuario, ReadUsuario>();
        CreateMap<Usuario, ReadUsuarioComCompromissosDto>()
            .ForMember(usuarioDto => usuarioDto.Compromissos,
                opt => opt.MapFrom(usuario => usuario.Compromissos));
    }
}
