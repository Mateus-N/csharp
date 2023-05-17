using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore;

public class LeilaoDaoComEfCore : ILeilaoDao
{
    private readonly AppDbContext context;

    public LeilaoDaoComEfCore()
    {
        context = new AppDbContext();
    }

    public IEnumerable<Leilao> BuscarTodos()
    {
        return context.Leiloes
            .Include(l => l.Categoria)
            .ToList();
    }

    public Leilao BuscarPorId(int id)
    {
        return context.Leiloes.First(l => l.Id == id);
    }

    public void Incluir(Leilao leilao)
    {
        context.Leiloes.Add(leilao);
        context.SaveChanges();
    }

    public void Alterar(Leilao leilao)
    {
        context.Leiloes.Update(leilao);
        context.SaveChanges();
    }

    public void Excluir(Leilao leilao)
    {
        context.Leiloes.Remove(leilao);
        context.SaveChanges();
    }

    public IEnumerable<Leilao> PesquisaLeiloes(string termo)
    {
        return context.Leiloes
            .Include(l => l.Categoria)
            .Where(l => string.IsNullOrWhiteSpace(termo) ||
                l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
            );
    }
}
