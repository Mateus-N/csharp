using FilmesApi2.Data.Dtos;
using FilmesApi2.Models;
using FilmesApi2.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi2.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
	private CinemaService cinemaService;
	
	public CinemaController(CinemaService cinemaService)
	{
		this.cinemaService = cinemaService;
	}
	
	[HttpPost]
	public IActionResult Adiciona([FromBody] CreateCinemaDto cinemaDto)
	{
		Cinema cinema = cinemaService.Adiciona(cinemaDto);
		return CreatedAtAction(nameof(RecuperaPorId), new { Id = cinema.Id}, cinema);
	}
	
	[HttpGet]
	public IEnumerable<ReadCinemaDto> RecuperaTodos([FromQuery] int? enderecoId = null)
	{
		return cinemaService.RecuperaTodos(enderecoId);
	}
	
	[HttpGet("{id}")]
	public IActionResult RecuperaPorId(int id)
	{
		ReadCinemaDto? readDto = cinemaService.RecuperaPorId(id);
		if (readDto == null) return NotFound();
		return Ok(readDto);
	}
	
	[HttpPut("{id}")]
	public IActionResult Atualiza(int id, [FromBody] UpdateCinemaDto cinemaDto)
	{
		ReadCinemaDto? readDto = cinemaService.Atualiza(id, cinemaDto);
		if (readDto == null) return NotFound();
		return NoContent();
	}
	
	[HttpDelete("{id}")]
	public IActionResult Deleta(int id)
	{
		ReadCinemaDto? readDto = cinemaService.Deleta(id);
		if (readDto == null) return NotFound();
		return NoContent();
	}
}
