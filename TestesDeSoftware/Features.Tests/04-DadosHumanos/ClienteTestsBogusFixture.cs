using Bogus.DataSets;
using Bogus;
using Features.Clientes;
using Xunit;

namespace Features.Tests._04_DadosHumanos;

[CollectionDefinition(nameof(ClienteBogusCollection))]
public class ClienteBogusCollection : ICollectionFixture<ClienteTestsBogusFixture>
{
}

public class ClienteTestsBogusFixture
{
    public Cliente GerarClienteValido()
    {
        Name.Gender genero = new Faker().PickRandom<Name.Gender>();

        Cliente cliente = new Faker<Cliente>("pt_BR")
            .CustomInstantiator(f => new Cliente(
                Guid.NewGuid(),
                f.Name.FirstName(genero),
                f.Name.LastName(genero),
                f.Date.Past(80, DateTime.Now.AddYears(-18)),
                "",
                true,
                DateTime.Now
                )
            ).RuleFor(c => c.Email, (f, c) =>
                f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

        return cliente;
    }

    public Cliente GerarClienteInvalido()
    {
        Name.Gender genero = new Faker().PickRandom<Name.Gender>();

        Cliente cliente = new Faker<Cliente>("pt_BR")
            .CustomInstantiator(f => new Cliente(
                Guid.NewGuid(),
                f.Name.FirstName(genero),
                f.Name.LastName(genero),
                f.Date.Past(1, DateTime.Now.AddYears(1)),
                "",
                false,
                DateTime.Now
                )
            ).RuleFor(c => c.Email, (f, c) =>
                f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

        return cliente;
    }
}
