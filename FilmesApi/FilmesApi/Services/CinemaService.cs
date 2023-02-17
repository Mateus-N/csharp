using AutoMapper;
using FilmesApi2.Data;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi2.Services;

public class CinemaService
{
	private Context context;
	private IMapper mapper;
	
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

	public IEnumerable<ReadCinemaDto> RecuperaTodos(int? enderecoId)
	{
		if (enderecoId == null)
		{
			return mapper.Map<List<ReadCinemaDto>>(context.Cinemas.ToList());
		}
		return mapper.Map<List<ReadCinemaDto>>(
			context.Cinemas.FromSqlRaw
				($"SELECT Id, Nome, EnderecoId FROM cinemas where cinemas.EnderecoId = {enderecoId}")
				.ToList()
		);
	}

	public ReadCinemaDto? RecuperaPorId(int id)
	{
		Cinema? cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
		if (cinema == null) return null;
		return mapper.Map<ReadCinemaDto>(cinema);
	}

	public ReadCinemaDto? Atualiza(int id, UpdateCinemaDto cinemaDto)
	{
		Cinema? cinema = context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
		if (cinema == null) return null;
		mapper.Map(cinemaDto, cinema);
		context.SaveChanges();
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