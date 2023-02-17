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
	private IMapper mapper;
	private UserManager<IdentityUser<int>> userManager;
	private EmailService emailService;

	public CadastroService (
		IMapper mapper,
		UserManager<IdentityUser<int>> userManager,
		EmailService emailService)
	{
		this.mapper = mapper;
		this.userManager = userManager;
		this.emailService = emailService;
	}

	public Result CadastraUsuario(CreateUsuarioDto createDto)
	{
		Usuario usuario = mapper.Map<Usuario>(createDto);
		IdentityUser<int> usuarioIdentity = mapper.Map<IdentityUser<int>>(usuario);
		Task<IdentityResult> resultadoIdentity = userManager.CreateAsync(usuarioIdentity, createDto.Password);
		if (resultadoIdentity.Result.Succeeded)
		{
			var code = userManager
				.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
			var encodedCode = HttpUtility.UrlEncode(code);
			emailService.EnviarEmail(
				new [] { usuarioIdentity.Email },
				"Link de Ativação",
				usuarioIdentity.Id,
				encodedCode);
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