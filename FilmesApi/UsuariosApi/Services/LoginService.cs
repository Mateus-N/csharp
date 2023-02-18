using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class LoginService
{
	private SignInManager<CustomIdentityUser> signInManager;
	private TokenService tokenService;

	public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
	{
		this.signInManager = signInManager;
		this.tokenService = tokenService;
	}

	public Result LogaUsuario(LoginRequest request)
	{
		var resultadoIdentity = signInManager
			.PasswordSignInAsync(request.Username, request.Password, false, false);
		if (resultadoIdentity.Result.Succeeded)
		{
			var identityUser = signInManager
				.UserManager
				.Users
				.FirstOrDefault(usuario =>
				usuario.NormalizedUserName == request.Username.ToUpper());
			Token token = tokenService
				.CreateToken(identityUser, signInManager
					.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
			return Result.Ok().WithSuccess(token.Value);
		}
		return Result.Fail("Login Falhou");
	}

    public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
    {
        CustomIdentityUser? identityUser = RecuperaUsuarioPorEmail(request.Email);

        if (identityUser !=null)
		{
			string codigoDeRecuperacao = signInManager
				.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
			return Result.Ok().WithSuccess(codigoDeRecuperacao);
		}

		return Result.Fail("Falha ao solicitar redefinição.");
    }

    public Result ResetaSenhaUsuario(EfetuaResetRequest request)
    {
        CustomIdentityUser? identityUser = RecuperaUsuarioPorEmail(request.Email);

        IdentityResult resultadoIdentity = signInManager
            .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

        if (resultadoIdentity.Succeeded)
        {
            return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
        }

        return Result.Fail("Houve um erro na operação");
    }

    private CustomIdentityUser? RecuperaUsuarioPorEmail(string requestEmail)
    {
        return signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(u => u.NormalizedEmail == requestEmail.ToUpper());
    }
}