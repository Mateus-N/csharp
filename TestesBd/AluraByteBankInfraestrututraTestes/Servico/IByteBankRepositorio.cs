using Alura.ByteBank.Dominio.Entidades;

namespace AluraByteBankInfraestrututraTestes.Servico;

public interface IByteBankRepositorio
{
    public List<Cliente> BuscaClientes();
    public List<Agencia> BuscaAgencias();
    public List<ContaCorrente> BuscaContasCorrente();
}
