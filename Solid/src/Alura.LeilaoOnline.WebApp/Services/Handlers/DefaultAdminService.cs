using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers;

public class DefaultAdminService : IAdminService
{
    private readonly ILeilaoDao dao;
    private readonly ICategoriaDao categoriaDao;

    public DefaultAdminService(ILeilaoDao dao, ICategoriaDao categoriaDao)
    {
        this.dao = dao;
        this.categoriaDao = categoriaDao;
    }

    public void CadastraLeilao(Leilao leilao)
    {
        dao.Incluir(leilao);
    }

    public IEnumerable<Categoria> ConsultaCategorias()
    {
        return categoriaDao.BuscarTodos();
    }

    public Leilao ConsultaLeilaoPorId(int id)
    {
        return dao.BuscarPorId(id);
    }

    public IEnumerable<Leilao> ConsultaLeiloes()
    {
        return dao.BuscarTodos();
    }

    public void FinalizaPregaoDoLeilaoComId(int id)
    {
        Leilao leilao = dao.BuscarPorId(id);
        if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
        {
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            dao.Alterar(leilao);
        }
    }

    public void IniciaPregaoDoLeilaoComId(int id)
    {
        Leilao leilao = dao.BuscarPorId(id);
        if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
        {
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            dao.Alterar(leilao);
        }
    }

    public void ModificaLeilao(Leilao leilao)
    {
        dao.Alterar(leilao);
    }

    public void Removeleilao(Leilao leilao)
    {
        if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
        {
            leilao.Situacao = SituacaoLeilao.Arquivado;
            dao.Alterar(leilao);
        }
    }
}
