using CursoDesignPatterns.Estados.Interface;

namespace CursoDesignPatterns.Estados;

public class Reprovado : IEstadoDeUmOrcamento
{
    public void AplicaDescontoExtra(Orcamento orcamento)
    {
        throw new Exception("Orcamentos reprovados nao recebem desconto extra");
    }

    public void Aprova(Orcamento orcamento)
    {
        throw new Exception("Orcamento ja esta reprovado");
    }

    public void Finaliza(Orcamento orcamento)
    {
        orcamento.EstadoAtual = new Finalizado();
    }

    public void Reprova(Orcamento orcamento)
    {
        throw new Exception("Orcamento ja esta reprovado");
    }
}
