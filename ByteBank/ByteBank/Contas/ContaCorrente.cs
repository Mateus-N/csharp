using ByteBank.Titular;

namespace ByteBank.Contas
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        private int _numeroAgencia;
        private double _saldo = 100;
        public string Conta { get; set; }
        public Cliente Titular { get; set; }

        public int NumeroAgencia
        {
            get => _numeroAgencia;
            private set
            {
                if (value > 0)
                {
                    _numeroAgencia = value;
                }
            }
        }

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

        public ContaCorrente(int numeroAgencia, string numeroConta)
        {
            NumeroAgencia = numeroAgencia;
            Conta = numeroConta;
            TotalDeContasCriadas++;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor <= _saldo)
            {
                _saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (_saldo < valor)
            {
                return false;
            }
            else
            {
                Sacar(valor);
                destino.Depositar(valor);
                return true;
            }
        }

        public void ExibirDadosDaConta()
        {
            Console.WriteLine("Titular: " + Titular.Nome);
            Console.WriteLine("Conta: " + Conta);
            Console.WriteLine("Número Agência: " + _numeroAgencia);
            Console.WriteLine("Saldo: " + _saldo);
        }
    }
}
