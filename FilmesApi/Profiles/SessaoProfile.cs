using FilmesApi2.Models;
using FilmesApi2.Data.Dtos;
using AutoMapper;

namespace FilmesApi2.Profiles;

public class SessaoProfile : Profile
{
	public SessaoProfile()
	{
		CreateMap<CreateSessaoDto, Sessao>();
		CreateMap<Sessao, ReadSessaoDto>();
		CreateMap<Sessao, ReadSessaoCompletedDto>();
	}
}