using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers;

public class LeilaoController : Controller
{
    private readonly IAdminService service;
    private readonly IProdutoService produtoService;

    public LeilaoController(IAdminService service, IProdutoService produtoService)
    {
        this.service = service;
        this.produtoService = produtoService;
    }

    public IActionResult Index()
    {
        var leiloes = service.ConsultaLeiloes();
        return View(leiloes);
    }

    [HttpGet]
    public IActionResult Insert()
    {
        ViewData["Categorias"] = service.ConsultaCategorias();
        ViewData["Operacao"] = "Inclusão";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Insert(Leilao model)
    {
        if (ModelState.IsValid)
        {
            service.CadastraLeilao(model);
            return RedirectToAction("Index");
        }
        ViewData["Categorias"] = service.ConsultaCategorias();
        ViewData["Operacao"] = "Inclusão";
        return View("Form", model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewData["Categorias"] = service.ConsultaCategorias();
        ViewData["Operacao"] = "Edição";
        var leilao = service.ConsultaLeilaoPorId(id);
        if (leilao == null) return NotFound();
        return View("Form", leilao);
    }

    [HttpPost]
    public IActionResult Edit(Leilao model)
    {
        if (ModelState.IsValid)
        {
            service.ModificaLeilao(model);
            return RedirectToAction("Index");
        }
        ViewData["Categorias"] = service.ConsultaCategorias();
        ViewData["Operacao"] = "Edição";
        return View("Form", model);
    }

    [HttpPost]
    public IActionResult Inicia(int id)
    {
        var leilao = service.ConsultaLeilaoPorId(id);
        if (leilao == null) return NotFound();
        if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
        leilao.Situacao = SituacaoLeilao.Pregao;
        leilao.Inicio = DateTime.Now;
        service.ModificaLeilao(leilao);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Finaliza(int id)
    {
        var leilao = service.ConsultaLeilaoPorId(id);
        if (leilao == null) return NotFound();
        if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
        leilao.Situacao = SituacaoLeilao.Finalizado;
        leilao.Termino = DateTime.Now;
        service.ModificaLeilao(leilao);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remove(int id)
    {
        var leilao = service.ConsultaLeilaoPorId(id);
        if (leilao == null) return NotFound();
        if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
        service.Removeleilao(leilao);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Pesquisa(string termo)
    {
        ViewData["termo"] = termo;
        var leiloes = produtoService.PesquisaLeiloesEmPregaoPorTermo(termo);
        return View("Index", leiloes);
    }
}
