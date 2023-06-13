using Features.Clientes;

namespace Features.Tests._02_Fixtures;

public class ClienteTestesFixture : IDisposable
{
    public Cliente GerarClienteValido()
    {
        return new Cliente(
            Guid.NewGuid(),
            "Mateus",
            "Nunes",
            DateTime.Now.AddYears(-22),
            "mateus@email.com",
            true,
            DateTime.Now);
    }

    public Cliente GerarClienteInvalido()
    {
        return new Cliente(
            Guid.NewGuid(),
            "",
            "",
            DateTime.Now,
            "mateus2email.com",
            true,
            DateTime.Now);
    }

    public void Dispose()
    {
    }
}
