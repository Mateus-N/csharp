using Agenda.Data;
using Agenda.Data.Dtos;
using Agenda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly AgendaContext agendaContext;
    private readonly IMapper mapper;

    public UsuarioController(AgendaContext agendaContext, IMapper mapper)
    {
        this.agendaContext = agendaContext;
        this.mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuario)
    {  
        Usuario user = mapper.Map<Usuario>(usuario);
        agendaContext.Usuarios.Add(user);
        agendaContext.SaveChanges();
        return Ok(usuario);
    }

    [HttpGet]
    public IEnumerable<ReadUsuarioComCompromissosDto> RecuperaUsuarios()
    {
        return mapper.Map<List<ReadUsuarioComCompromissosDto>>(agendaContext.Usuarios.ToList());
    }
}
