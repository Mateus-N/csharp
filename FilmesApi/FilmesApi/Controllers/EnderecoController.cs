using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;
using FilmesApi2.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi2.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
	private EnderecoService enderecoService;
	
	public EnderecoController(EnderecoService enderecoService)
	{
		this.enderecoService = enderecoService;
	}
	
	[HttpPost]
	public IActionResult Adiciona([FromBody] CreateEnderecoDto enderecoDto)
	{
		Endereco endereco = enderecoService.Adiciona(enderecoDto);
		return CreatedAtAction(nameof(RecuperaPorId), new { Id = endereco.Id }, endereco);
	}
	
	[HttpGet]
	public IEnumerable<ReadEnderecoDto> RecuperaTodos()
	{
		return enderecoService.RecuperaTodos();
	}
	
	[HttpGet("{id}")]
	public IActionResult RecuperaPorId(int id)
	{
		ReadEnderecoDto? readDto = enderecoService.RecuperaPorId(id);
		if (readDto == null) return NotFound();
		return Ok(readDto);
	}
	
	[HttpDelete("{id}")]
	public IActionResult Deleta(int id)
	{
		ReadEnderecoDto? readDto = enderecoService.Deleta(id);
		if (readDto == null) return NotFound();
		return NoContent();
	}
}
