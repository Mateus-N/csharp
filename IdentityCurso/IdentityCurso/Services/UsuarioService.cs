using AutoMapper;
using IdentityCurso.Data.Dtos;
using IdentityCurso.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityCurso.Services;

public class UsuarioService
{
    private readonly SignInManager<Usuario> signInManager;
    private readonly UserManager<Usuario> userManager;
    private readonly TokenService tokenService;
    private readonly IMapper mapper;

    public UsuarioService(
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        TokenService tokenService,
        IMapper mapper)
    {
        this.signInManager = signInManager;
        this.tokenService = tokenService;
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task Cadastra(CreateUsuarioDto dto)
    {
        Usuario usuario = mapper.Map<Usuario>(dto);
        IdentityResult resultado = await userManager.CreateAsync(usuario, dto.Password);
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }

    public async Task<ReadTokenDto> Login(LoginUsuarioDto dto)
    {
        SignInResult resultado = await signInManager
            .PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        Usuario usuario = signInManager
            .UserManager
            .Users
            .First(user => user.NormalizedUserName == dto.Username.ToUpper());

        string token = tokenService.GenerateToken(usuario);
        return new ReadTokenDto(token);
    }
}
