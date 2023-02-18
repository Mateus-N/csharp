using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;

namespace FilmesApi2.Profiles;

public class EnderecoProfile : Profile
{
	public EnderecoProfile()
	{
		CreateMap<CreateEnderecoDto, Endereco>();
		CreateMap<Endereco, ReadEnderecoDto>();
	}
}