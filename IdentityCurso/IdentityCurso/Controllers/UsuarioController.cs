using IdentityCurso.Data.Dtos;
using IdentityCurso.Models;
using IdentityCurso.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCurso.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> Cadastra(CreateUsuarioDto dto)
    {
        try
        {
            await usuarioService.Cadastra(dto);
            return Ok("Usuário cadastrado com sucesso");
        }
        catch (Exception e)
        {
            return UnprocessableEntity(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        try
        {
            ReadTokenDto token = await usuarioService.Login(dto);
            return Ok(token);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
}
