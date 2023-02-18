using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;

namespace FilmesApi2.Profiles;

public class CinemaProfile : Profile
{
	public CinemaProfile()
	{
		CreateMap<CreateCinemaDto, Cinema>();
		CreateMap<Cinema, ReadCinemaDto>()
			.ForMember(cinemaDto => cinemaDto.Endereco,
				opt => opt.MapFrom(cinema => cinema.Endereco))
			.ForMember(cinemaDto => cinemaDto.Sessoes,
				opt => opt.MapFrom(cinema => cinema.Sessoes));
		CreateMap<Cinema, ReadCinemaOnlyDto>()
			.ForMember(cinemaDto => cinemaDto.Endereco,
				opt => opt.MapFrom(cinema => cinema.Endereco));
	}
}