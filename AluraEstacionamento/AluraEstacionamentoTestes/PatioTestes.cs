using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class PatioTestes
{
    [Fact]
    public void ValidafaturamentoDoEstacionamentoComUmVeiculo()
    {
        var estacionamento = new Patio();
        var veiculo = new Veiculo
        {
            Proprietario = "Mateus Nunes",
            Tipo = TipoVeiculo.Automovel,
            Cor = "Verde",
            Modelo = "Fusca",
            Placa = "asd-9999"
        };

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        double faturamento = estacionamento.TotalFaturado();

        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("Mateus Nunes", "ASD-1498", "Preto", "Gol")]
    [InlineData("Adrielly Mendes", "POL-9242", "Cinza", "Fusca")]
    [InlineData("Castiel Nunes", "GDR-6524", "Azul", "Opala")]
    public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos
        (string proprietario, string placa, string cor, string modelo)
    {
        var estacionamento = new Patio();
        var veiculo = new Veiculo
        {
            Proprietario = proprietario,
            Placa = placa,
            Cor = cor,
            Modelo = modelo,
            Tipo = TipoVeiculo.Automovel
        };

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        double faturamento = estacionamento.TotalFaturado();

        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("Mateus Nunes", "ASD-1498", "Preto", "Gol")]
    public void LocalizaVeiculoNoPatioComBaseNaPlaca
        (string proprietario, string placa, string cor, string modelo)
    {
        var estacionamento = new Patio();
        var veiculo = new Veiculo
        {
            Proprietario = proprietario,
            Placa = placa,
            Cor = cor,
            Modelo = modelo,
            Tipo = TipoVeiculo.Automovel
        };
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var consultado = estacionamento.PesquisaVeiculo(placa);
        Assert.Equal("ASD-1498", consultado.Placa);
    }

    [Fact]
    public void AlterarDadosDoProprioVeiculo()
    {
        var estacionamento = new Patio();
        var veiculo = new Veiculo
        {
            Proprietario = "Mateus Nunes",
            Placa = "ASD-1498",
            Cor = "Preto",
            Modelo = "Gol",
            Tipo = TipoVeiculo.Automovel
        };
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var veiculoAlterado = new Veiculo
        {
            Proprietario = "Mateus Nunes",
            Placa = "ASD-1498",
            Cor = "Branco",
            Modelo = "Gol",
            Tipo = TipoVeiculo.Automovel
        };

        Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);
        Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
    }
}
