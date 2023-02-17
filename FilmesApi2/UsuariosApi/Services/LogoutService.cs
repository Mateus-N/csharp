using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Services;

public class LogoutService
{
	private SignInManager<IdentityUser<int>> signInManager;

	public LogoutService(SignInManager<IdentityUser<int>> signInManager)
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