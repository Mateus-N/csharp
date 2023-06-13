using Xunit;

namespace Features.Tests._02_Fixtures;

[CollectionDefinition(nameof(ClienteCollection))]
public class ClienteCollection : ICollectionFixture<ClienteTestesFixture>
{
}
