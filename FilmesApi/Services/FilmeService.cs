using AutoMapper;
using FilmesApi2.Data;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi2.Services;

public class FilmeService
{
	private Context context;
	private IMapper mapper;
	
	public FilmeService(Context context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	public Filme Adiciona(CreateFilmeDto filmeDto)
	{
		Filme filme = mapper.Map<Filme>(filmeDto);
		context.Filmes.Add(filme);
		context.SaveChanges();
		return filme;
	}

	public IEnumerable<ReadFilmeDto> RecuperaTodos(int skip, int take, string? nomeCinema)
	{
		if (nomeCinema == null)
		{
			return mapper.Map<List<ReadFilmeDto>>(context.Filmes.Skip(skip).Take(take).ToList());
		}
		return mapper.Map<List<ReadFilmeDto>>(context.Filmes
			.Skip(skip).Take(take).ToList()
			.Where(filme => filme.Sessoes
			.Any(sessao => sessao.Cinema.Nome == nomeCinema)));
	}

	public ReadFilmeDto? RecuperaPorId(int id)
	{
		var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
		if (filme == null) return null;
		return mapper.Map<ReadFilmeDto>(filme);
	}
	
	public ReadFilmeDto? Atualiza(int id, UpdateFilmeDto filmeDto)
	{
		var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
		if (filme == null) return null;
		mapper.Map(filmeDto, filme);
		context.SaveChanges();
		return mapper.Map<ReadFilmeDto>(filme);
	}

	public UpdateFilmeDto? ValidaAtualizacaoParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
	{
		var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
		if (filme == null) return null;
		
		return mapper.Map<UpdateFilmeDto>(filme);
	}

	public void AtualizaParcial(int id, UpdateFilmeDto updateDto)
	{
		var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
		mapper.Map(updateDto, filme);
		context.SaveChanges();
	}

	public ReadFilmeDto? Deleta(int id)
	{
		var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);
		if (filme == null) return null;
		context.Remove(filme);
		context.SaveChanges();
		return mapper.Map<ReadFilmeDto>(filme);
	}
}