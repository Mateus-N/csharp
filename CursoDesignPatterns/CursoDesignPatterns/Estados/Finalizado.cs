﻿using CursoDesignPatterns.Estados.Interface;

namespace CursoDesignPatterns.Estados;

public class Finalizado : IEstadoDeUmOrcamento
{
    public void AplicaDescontoExtra(Orcamento orcamento)
    {
        throw new Exception("Orcamentos finalizados nao recebem desconto extra");
    }

    public void Aprova(Orcamento orcamento)
    {
        throw new Exception("Orcamento ja esta finalizado");
    }

    public void Finaliza(Orcamento orcamento)
    {
        throw new Exception("Orcamento ja esta finalizado");
    }

    public void Reprova(Orcamento orcamento)
    {
        throw new Exception("Orcamento ja esta finalizado");
    }
}
