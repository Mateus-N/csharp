using AutoMapper;
using Produtos.Dtos;
using Produtos.Models;

namespace Produtos.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>()
            .ForMember(produtoDto => produtoDto.EstadoDoProduto,
                opt => opt.MapFrom(produto => produto.EstadoDoProduto.ToString()));
    }
}
