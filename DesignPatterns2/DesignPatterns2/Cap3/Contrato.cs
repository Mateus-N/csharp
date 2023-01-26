using DesignPatterns2.Cap3.Estados;

namespace DesignPatterns2.Cap3;

internal class Contrato
{
    public DateTime Data { get; private set; }
    public string Cliente { get; private set; }
    public IEstado Tipo { get; set; }

    public Contrato(string cliente)
    {
        Data = DateTime.Now;
        Cliente = cliente;
        Tipo = new Novo();
    }

    public void Avanca()
    {
        Tipo.AvancaContrato(this);
    }

    public void Retorna()
    {
        Tipo.VoltaContrato(this);
    }
}
