using BytebankAdm.Funcionarios;

namespace BytebankAdm.Utilitario
{
    public class GerenciadorDeBonificacao
    {
        public double TotalDeBonificacoes { get; private set; }

        public void Registrar(Funcionario funcionario)
        {
            TotalDeBonificacoes += funcionario.GetBonificacao();
        }
    }
}
