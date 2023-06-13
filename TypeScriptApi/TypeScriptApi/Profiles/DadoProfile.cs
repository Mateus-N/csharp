using AutoMapper;
using TypeScriptApi.Dtos;
using TypeScriptApi.Models;

namespace TypeScriptApi.Profiles;

public class DadoProfile : Profile
{
    public DadoProfile()
    {
        CreateMap<CreateDadoDto, Dado>();
        CreateMap<Dado, ReadDadoDto>();
    }
}
