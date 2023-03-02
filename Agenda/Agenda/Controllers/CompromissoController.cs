using Agenda.Data;
using Agenda.Data.Dtos;
using Agenda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers;

[ApiController]
[Route("[controller]")]
public class CompromissoController : ControllerBase
{
    private readonly AgendaContext agendaContext;
    private readonly IMapper mapper;

    public CompromissoController(AgendaContext agendaContext, IMapper mapper)
    {
        this.agendaContext = agendaContext;
        this.mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaCompromisso([FromBody] CreateCompromissoDto compromisso)
    {
        Compromisso comp = mapper.Map<Compromisso>(compromisso);
        agendaContext.Compromissos.Add(comp);
        agendaContext.SaveChanges();
        return Ok(compromisso);
    }

    [HttpGet]
    public IEnumerable<ReadCompromissoCompleto> RecuperaCompromissos()
    {
        return mapper.Map<List<ReadCompromissoCompleto>>(agendaContext.Compromissos.ToList());
    }

    [HttpGet("{data}")]
    public IActionResult RecuperaCompromissosPorDia(DateTime data)
    {
        var compromissos = agendaContext.Compromissos.Where(compromisso => 
            compromisso.DataEHorario.Date == data);

        return Ok(compromissos);
    }
}
