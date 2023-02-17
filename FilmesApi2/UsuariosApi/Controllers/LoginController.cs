using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
	private LoginService loginService;

	public LoginController(LoginService loginService)
	{
		this.loginService = loginService;
	}
	
	[HttpPost]
	public IActionResult LogaUsuario(LoginRequest request)
	{
		Result resultado = loginService.LogaUsuario(request);
		if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
		return Ok(resultado.Successes.FirstOrDefault());
	}
}