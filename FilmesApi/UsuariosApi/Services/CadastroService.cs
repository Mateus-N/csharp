using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class CadastroService
{
	private readonly IMapper mapper;
	private readonly UserManager<Usuario> userManager;

	public CadastroService (
		IMapper mapper,
		UserManager<Usuario> userManager)
	{
		this.mapper = mapper;
		this.userManager = userManager;
	}

	public Result CadastraUsuario(CreateUsuarioDto createDto)
	{
		Usuario usuario = mapper.Map<Usuario>(createDto);

		Task<IdentityResult> resultadoIdentity = userManager
			.CreateAsync(usuario, createDto.Password);

		userManager.AddToRoleAsync(usuario, "regular");
		if (resultadoIdentity.Result.Succeeded) return Result.Ok();
		return Result.Fail("Falha ao cadastrar usuário");
	}
}