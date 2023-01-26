global using Xunit;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
    private Veiculo veiculo;
    public ITestOutputHelper SaidaConsoleTeste { get; set; }

    public VeiculoTestes(ITestOutputHelper saidaConsoleTeste)
    {
        SaidaConsoleTeste = saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Construtor invocado.");
        veiculo = new Veiculo();
    }

    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        // arrange
        // act
        veiculo.Acelerar(10);
        // assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrearComParametro10()
    {
        veiculo.Frear(10);
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void FichaDeInformacaoDoVeiculo()
    {
        var carro = new Veiculo
        {
            Proprietario = "Mateus Nunes",
            Placa = "ASD-1498",
            Cor = "Preto",
            Modelo = "Gol",
            Tipo = TipoVeiculo.Automovel
        };

        string dados = carro.ToString();

        Assert.Contains("Tipo do Veículo: Automovel", dados);
    }

    [Fact]
    public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
    {
        string placa = "ASDF8888";

        var mensagem = Assert.Throws<FormatException>(
            () => new Veiculo().Placa = placa);

        Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
    }
}