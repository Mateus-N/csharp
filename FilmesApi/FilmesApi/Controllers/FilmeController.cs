using Microsoft.AspNetCore.Mvc;
using FilmesApi2.Models;
using FilmesApi2.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using FilmesApi2.Services;
using Microsoft.AspNetCore.Authorization;

namespace FilmesApi2.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
	private readonly FilmeService filmeService;
	
	public FilmeController(FilmeService filmeService)
	{
		this.filmeService = filmeService;
	}
	
	[HttpPost]
	[Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
	public IActionResult Adiciona([FromBody] CreateFilmeDto filmeDto)
	{
		Filme filme = filmeService.Adiciona(filmeDto);
		return CreatedAtAction(nameof(RecuperaPorId), new { id = filme.Id }, filme);
	}
	
	[HttpGet]
	public IEnumerable<ReadFilmeDto> RecuperaTodos(
		[FromQuery] int skip = 0, [FromQuery] int take = 10, string? nomeCinema = null)
	{
		return filmeService.RecuperaTodos(skip, take, nomeCinema);
	}
	
	[HttpGet("{id}")]
	public IActionResult RecuperaPorId(int id)
	{
		ReadFilmeDto? readDto = filmeService.RecuperaPorId(id);
		if (readDto == null) return NotFound();
		return Ok(readDto);
	}
	
	[HttpDelete("{id}")]
	public IActionResult Deleta(int id)
	{
		ReadFilmeDto? readDto = filmeService.Deleta(id);
		if (readDto == null) return NotFound();
		return NoContent();
	}
}
