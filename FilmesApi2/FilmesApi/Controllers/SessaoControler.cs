using Microsoft.AspNetCore.Mvc;
using FilmesApi2.Services;
using FilmesApi2.Models;
using FilmesApi2.Data.Dtos;

namespace FilmesApi2.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
	private SessaoService sessaoService;
	
	public SessaoController(SessaoService sessaoService)
	{
		this.sessaoService = sessaoService;
	}
	
	[HttpPost]
	public IActionResult Adiciona([FromBody] CreateSessaoDto dto)
	{
		Sessao sessao = sessaoService.Adiciona(dto);
		return CreatedAtAction(nameof(RecuperaPorId), new 
			{ filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessao);
	}
	
	[HttpGet]
	public IEnumerable<ReadSessaoDto> RecuperaTodos()
	{
		return sessaoService.RecuperaTodos();
	}
	
	[HttpGet("{filmeId}/{cinemaId}")]
	public IActionResult RecuperaPorId(int filmeId, int cinemaId)
	{
		ReadSessaoCompletedDto? readDto = sessaoService.RecuperaPorId(filmeId, cinemaId);
		if (readDto == null) return NotFound();
		return Ok(readDto);
	}
}
