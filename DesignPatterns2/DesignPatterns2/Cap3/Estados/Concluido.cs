namespace DesignPatterns2.Cap3.Estados;

internal class Concluido : IEstado
{
    public void AvancaContrato(Contrato contrato)
    {
        throw new Exception("O Contrato já está concluido");
    }

    public void VoltaContrato(Contrato contrato)
    {
        contrato.Tipo = new Acertado();
    }

    public override string ToString()
    {
        return "Contrato Concluido";
    }
}