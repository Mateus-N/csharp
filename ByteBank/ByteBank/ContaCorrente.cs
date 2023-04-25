namespace ByteBank;

public class ContaCorrente
{
    public int NumeroAgencia;
    public string Conta;
    public string Titular;
    public double Saldo;

    public void Depositar(double valor)
    {
        Saldo += valor;
    }

    public void Sacar(double valor)
    {
        if (valor <= Saldo)
        {
            Saldo -= valor;
        }
    }
}
