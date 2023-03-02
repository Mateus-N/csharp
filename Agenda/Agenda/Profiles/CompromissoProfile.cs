using Agenda.Data.Dtos;
using Agenda.Models;
using AutoMapper;

namespace Agenda.Profiles;

public class CompromissoProfile : Profile
{
    public CompromissoProfile()
    {
        CreateMap<CreateCompromissoDto, Compromisso>();
        CreateMap<Compromisso, ReadCompromisso>();
        CreateMap<Compromisso, ReadCompromissoCompleto>()
            .ForMember(compromissoDto => compromissoDto.Usuario,
                opt => opt.MapFrom(compromisso => compromisso.Usuario));
    }
}
