using FilmesApi2.Data;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;
using AutoMapper;

namespace FilmesApi2.Services;

public class SessaoService
{
	private Context context;
	private IMapper mapper;
	
	public SessaoService(Context context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	public Sessao Adiciona(CreateSessaoDto dto)
	{
		Sessao sessao = mapper.Map<Sessao>(dto);
		context.Sessoes.Add(sessao);
		context.SaveChanges();
		return sessao;
	}

	public IEnumerable<ReadSessaoDto> RecuperaTodos()
	{	
		return mapper.Map<List<ReadSessaoDto>>(context.Sessoes);
	}

	public ReadSessaoCompletedDto? RecuperaPorId(int filmeId, int cinemaId)
	{
		Sessao? sessao = context.Sessoes.FirstOrDefault(sessao => 
			sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);

		if (sessao == null) return null;
		return mapper.Map<ReadSessaoCompletedDto>(sessao);
	}
}