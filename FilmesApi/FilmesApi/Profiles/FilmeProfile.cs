using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;

namespace FilmesApi2.Profiles;

public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
		CreateMap<CreateFilmeDto, Filme>();
		CreateMap<Filme, ReadFilmeOnlyDto>();
		CreateMap<Filme, ReadFilmeDto>()
			.ForMember(filmeDto => filmeDto.Sessoes,
				opt => opt.MapFrom(filme => filme.Sessoes));
	}
}
