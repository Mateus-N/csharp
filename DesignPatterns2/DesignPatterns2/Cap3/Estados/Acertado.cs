namespace DesignPatterns2.Cap3.Estados;

internal class Acertado : IEstado
{
    public void AvancaContrato(Contrato contrato)
    {
        contrato.Tipo = new Concluido();
    }

    public void VoltaContrato(Contrato contrato)
    {
        contrato.Tipo = new EmAndamento();
    }

    public override string ToString()
    {
        return "Contrato Acertado";
    }
}