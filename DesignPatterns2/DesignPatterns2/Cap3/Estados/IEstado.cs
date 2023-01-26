namespace DesignPatterns2.Cap3.Estados;

internal interface IEstado
{
    public void AvancaContrato(Contrato contrato);
    public void VoltaContrato(Contrato contrato);
}
