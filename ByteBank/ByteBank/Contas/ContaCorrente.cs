using ByteBank.Titular;
using ByteBank.Excecoes;

namespace ByteBank.Contas
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        public static double TaxaOperacao { get; private set; }
        public Cliente? Titular { get; set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        private int Conta { get; }
        private int NumeroAgencia { get; }
        private double _saldo = 100;


        public double Saldo
        {
            get => _saldo;
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }



        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if (numeroAgencia <= 0)
            {
                throw new ArgumentException("Os argumentos numero e agencia devem ser maiores que 0", nameof(numeroAgencia));
            }

            if (numeroConta <= 0)
            {
                throw new ArgumentException("Os argumentos numero e agencia devem ser maiores que 0", nameof(numeroConta));
            }

            NumeroAgencia = numeroAgencia;
            Conta = numeroConta;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (Saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException($"Saldo insuficiente para saque no valor de {valor}");
            }

            if (valor < 0)
            {
                ContadorSaquesNaoPermitidos++;
                throw new ArgumentException("Valor inválido para saque.", nameof(valor));
            }

            Saldo -= valor;
        }

        public void Transferir(double valor, ContaCorrente destino)
        {
            try
            {
                Sacar(valor);
                destino.Depositar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }
        }
    }
}
