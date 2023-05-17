using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore;

public class CategoriaDaoComEfCore : ICategoriaDao
{
    private readonly AppDbContext context;

    public CategoriaDaoComEfCore()
    {
        context = new AppDbContext();
    }
    public Categoria BuscarPorId(int id)
    {
        return context.Categorias.First(c => c.Id == id);
    }

    public IEnumerable<Categoria> BuscarTodos()
    {
        return context.Categorias.ToList();
    }
}
