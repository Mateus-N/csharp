namespace DesignPatterns2.Cap3.Estados;

internal class EmAndamento : IEstado
{
    public void AvancaContrato(Contrato contrato)
    {
        contrato.Tipo = new Acertado();
    }

    public void VoltaContrato(Contrato contrato)
    {
        contrato.Tipo = new Novo();
    }

    public override string ToString()
    {
        return "Contrato em Andamento";
    }
}