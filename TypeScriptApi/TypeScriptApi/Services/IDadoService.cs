using TypeScriptApi.Dtos;
using TypeScriptApi.Models;

namespace TypeScriptApi.Services;

public interface IDadoService
{
    Task<Dado?> CadastraDado(CreateDadoDto createDto);
    IEnumerable<ReadDadoDto> BuscaTodos();
    Task DeletaPorId(Guid id);
}
