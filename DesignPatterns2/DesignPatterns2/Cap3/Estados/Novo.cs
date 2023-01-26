namespace DesignPatterns2.Cap3.Estados;

internal class Novo : IEstado
{
    public void AvancaContrato(Contrato contrato)
    {
        contrato.Tipo = new EmAndamento();
    }

    public void VoltaContrato(Contrato contrato)
    {
        throw new Exception("O contrato é novo e não tem estados anteriores");
    }

    public override string ToString()
    {
        return "Contrato Novo";
    }
}
