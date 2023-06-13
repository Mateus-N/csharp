using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TypeScriptApi.Data;
using TypeScriptApi.Dtos;
using TypeScriptApi.Models;

namespace TypeScriptApi.Services;

public class DadoService : IDadoService, IInjetable
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;

    public DadoService(AppDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<Dado?> CadastraDado(CreateDadoDto createDto)
    {
        Dado dado = mapper.Map<Dado>(createDto);
        await context.Dados.AddAsync(dado);
        context.SaveChanges();
        return dado;
    }

    public IEnumerable<ReadDadoDto> BuscaTodos()
    {
        return mapper.Map<IEnumerable<ReadDadoDto>>(context.Dados.ToList());
    }

    public async Task DeletaPorId(Guid id)
    {
        Dado? dado = await context.Dados.FirstOrDefaultAsync(d => d.Id == id);
        if (dado == null) return;
        context.Remove(dado);
        context.SaveChanges();
    }
}
