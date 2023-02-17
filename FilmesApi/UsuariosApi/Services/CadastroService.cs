using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class CadastroService
{
	private readonly IMapper mapper;
	private readonly UserManager<CustomIdentityUser> userManager;
	private readonly EmailService emailService;

	public CadastroService (
		IMapper mapper,
		UserManager<CustomIdentityUser> userManager,
		EmailService emailService,
        RoleManager<IdentityRole<int>> roleManager)
	{
		this.mapper = mapper;
		this.userManager = userManager;
		this.emailService = emailService;
	}

	public Result CadastraUsuario(CreateUsuarioDto createDto)
	{
		Usuario usuario = mapper.Map<Usuario>(createDto);
		CustomIdentityUser usuarioIdentity = mapper.Map<CustomIdentityUser>(usuario);

		Task<IdentityResult> resultadoIdentity = userManager
			.CreateAsync(usuarioIdentity, createDto.Password);
		userManager.AddToRoleAsync(usuarioIdentity, "regular");
		if (resultadoIdentity.Result.Succeeded)
		{
			var code = userManager
				.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
			//var encodedCode = HttpUtility.UrlEncode(code);
			//emailService.EnviarEmail(
			//	new[] { usuarioIdentity.Email },
			//	"Link de Ativação",
			//	usuarioIdentity.Id,
			//	encodedCode);
			return Result.Ok().WithSuccess(code);
		}
		return Result.Fail("Falha ao cadastrar usuário");
	}

	public Result AtivaContaUsuario(AtivaContaRequest request)
	{
		var identityUser = userManager
			.Users
			.FirstOrDefault(u => u.Id == request.UsuarioId);
		
		var identityResult = userManager
			.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
		
		if (identityResult.Succeeded)
		{
			return Result.Ok();
		}
		return Result.Fail("Falha ao ativar conta de usuário");
	}
}