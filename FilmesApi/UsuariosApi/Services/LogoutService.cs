using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class LogoutService
{
	private readonly SignInManager<CustomIdentityUser> signInManager;

	public LogoutService(SignInManager<CustomIdentityUser> signInManager)
	{
		this.signInManager = signInManager;
	}

	public Result DeslogarUsuario()
	{
		var resultadoIdentity = signInManager.SignOutAsync();
		if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
		return Result.Fail("Logout Falhou");
	}
}