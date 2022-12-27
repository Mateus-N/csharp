using CursoDesignPatterns.Estados;
using CursoDesignPatterns.Estados.Interface;

namespace CursoDesignPatterns;

public class Orcamento
{
    private bool FoiAplicadoDescontoExtra = false;
    public string Cliente { get; set; }
    public double Valor { get; set; }
    public IList<Item> Items { get; private set; }
    public IEstadoDeUmOrcamento EstadoAtual { get; set; }

    public Orcamento(string cliente)
    {
        Cliente = cliente;
        Items = new List<Item>();
        EstadoAtual = new EmAprovacao();
    }

    public void AdicionaItem(Item item)
    {
        Items.Add(item);
        Valor += item.Valor;
    }

    public void AplicaDescontoExtra()
    {
        if (!FoiAplicadoDescontoExtra)
        {
            EstadoAtual.AplicaDescontoExtra(this);
            FoiAplicadoDescontoExtra = true;
        }
        else
        {
            throw new Exception("Já foi aplicado desconto extra nesse orçamento");
        }
    }

    public void Aprova()
    {
        EstadoAtual.Aprova(this);
    }

    public void Reprova()
    {
        EstadoAtual.Reprova(this);
    }

    public void Finaliza()
    {
        EstadoAtual.Finaliza(this);
    }
}
