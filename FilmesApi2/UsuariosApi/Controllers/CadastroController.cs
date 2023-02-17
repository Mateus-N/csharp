using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CadastroController : ControllerBase
{
	private CadastroService cadastroService;
	
	public CadastroController(CadastroService cadastroService)
	{
		this.cadastroService = cadastroService;
	}

	[HttpPost]
	public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
	{
		Result resultado = cadastroService.CadastraUsuario(createDto);
		if (resultado.IsFailed) return StatusCode(500);
		return Ok(resultado.Successes.FirstOrDefault());
	}
	
	[HttpPost("/ativa")]
	public IActionResult AtivaContaUsuario(AtivaContaRequest request)
	{
		Result resultado = cadastroService.AtivaContaUsuario(request);
		if (resultado.IsFailed) return StatusCode(500);
		return Ok(resultado.Successes.FirstOrDefault());
	}
}