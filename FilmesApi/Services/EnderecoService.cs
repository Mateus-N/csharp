using AutoMapper;
using FilmesApi2.Data;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;

namespace FilmesApi2.Services;

public class EnderecoService
{
	private readonly Context context;
	private readonly IMapper mapper;
	
	public EnderecoService(Context context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	public Endereco Adiciona(CreateEnderecoDto enderecoDto)
	{
		Endereco endereco = mapper.Map<Endereco>(enderecoDto);
		context.Enderecos.Add(endereco);
		context.SaveChanges();
		return endereco;
	}

	public IEnumerable<ReadEnderecoDto> RecuperaTodos()
	{
		return mapper.Map<IList<ReadEnderecoDto>>(context.Enderecos);
	}
	
	public ReadEnderecoDto? RecuperaPorId(int id)
	{
		Endereco? endereco = context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
		if (endereco == null) return null;
		return mapper.Map<ReadEnderecoDto>(endereco);
	}

	public ReadEnderecoDto? Deleta(int id)
	{
		Endereco? endereco = context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
		if (endereco == null) return null;
		context.Remove(endereco);
		context.SaveChanges();
		return mapper.Map<ReadEnderecoDto>(endereco);
	}
}