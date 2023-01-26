global using Xunit;
using Alura.ByteBank.Dados.Contexto;

namespace AluraByteBankInfraestrututraTestes;

public class ByteBankContextoTestes
{
    [Fact]
    public void TestaConexaoContextoComBdMySql()
    {
        var contexto = new ByteBankContexto();
        bool conectado;

        try
        {
            conectado = contexto.Database.CanConnect();
        }
        catch
        {
            throw new Exception("Não foi possivel conectar a base de dados.");
        }

        Assert.True( conectado );
    }
}
