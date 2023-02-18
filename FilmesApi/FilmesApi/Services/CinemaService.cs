using AutoMapper;
using FilmesApi2.Data;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;

namespace FilmesApi2.Services;

public class CinemaService
{
	private readonly Context context;
	private readonly IMapper mapper;
	
	public CinemaService(Context context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}
	
	public Cinema Adiciona(CreateCinemaDto cinemaDto)
	{
		Cinema cinema = mapper.Map<Cinema>(cinemaDto);
		context.Cinemas.Add(cinema);
		context.SaveChanges();
		return cinema;
	}

	public IEnumerable<ReadCinemaDto> RecuperaTodos()
	{
		return mapper.Map<List<ReadCinemaDto>>(context.Cinemas.ToList());
	}

	public ReadCinemaDto? RecuperaPorId(int id)
	{
		Cinema? cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
		if (cinema == null) return null;
		return mapper.Map<ReadCinemaDto>(cinema);
	}

	public ReadCinemaDto? Deleta(int id)
	{
		Cinema? cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
		if (cinema == null) return null;
		context.Remove(cinema);
		context.SaveChanges();
		return mapper.Map<ReadCinemaDto>(cinema);
	}
}