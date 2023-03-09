using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Produtos.Dtos;
using Produtos.Models;

namespace Produtos.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static IList<Produto> produtos = new List<Produto>();
    private readonly IMapper mapper;

    public ProdutoController(IMapper mapper)
    {
        this.mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = mapper.Map<Produto>(produtoDto);
        produtos.Add(produto);
        return CreatedAtAction(nameof(RecuperaPorId), new { id = produto.Id }, produto);
    }

    [HttpGet]
    public IList<ReadProdutoDto> RecuperaTodos()
    {
        return mapper.Map<List<ReadProdutoDto>>(produtos).ToList();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPorId(Guid id)
    {
        Produto? produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }
}
