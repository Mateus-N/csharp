using Microsoft.AspNetCore.Mvc;
using TypeScriptApi.Dtos;
using TypeScriptApi.Models;
using TypeScriptApi.Services;

namespace TypeScriptApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DadosController : ControllerBase
{
    private readonly IDadoService Service;

    public DadosController(IDadoService service)
    {
        Service = service;
    }

    [HttpGet]
    public IActionResult BuscaTodos()
    {
        try
        {
            IEnumerable<ReadDadoDto> dados = Service.BuscaTodos();
            return Ok(dados);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CadastraDado(CreateDadoDto createDto)
    {
        try
        {
            Dado dado = await Service.CadastraDado(createDto);
            return Ok(dado);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletaPorId(Guid id)
    {
        try
        {
            await Service.DeletaPorId(id);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
