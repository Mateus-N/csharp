using CursoDesignPatterns;
using CursoDesignPatterns.Calculadores;
using CursoDesignPatterns.Descontos.Interface;
using CursoDesignPatterns.Descontos;
using CursoDesignPatterns.Impostos;
using CursoDesignPatterns.Impostos.Interface;
using CursoDesignPatterns.Nota;
using CursoDesignPatterns.Nota.AposGerarNota;

Imposto iss = new Iss();
Imposto icms = new Icms();

Orcamento orcamento = new Orcamento("Mateus");

CalculadorDeImpostos calculador = new CalculadorDeImpostos();

calculador.RealizaCalculo(orcamento, icms);
calculador.RealizaCalculo(orcamento, iss);

IDesconto d1 = new DescontoPorCincoItens();
IDesconto d2 = new DescontoPorMaisDeQuinhentosReais();
IDesconto d3 = new SemDesconto();

d1.Proximo = d2;
d2.Proximo = d3;

Orcamento orcamento2 = new Orcamento("Adrielly");

double desconto = d1.Desconta(orcamento2);
Console.WriteLine(desconto);

NotaFiscalBuilder criador = new();
criador.ParaEmpresa("Caelum Ensino e Inovacao")
    .ComCnpj("23.323.323/0001-12")
    .Com(new ItemDaNota("Item 1", 100))
    .Com(new ItemDaNota("Item 2", 150))
    .ComObservacoes("Obs");

criador.AdicionaAcao(new EnviarEmail());
criador.AdicionaAcao(new NotaFiscalDao());
criador.AdicionaAcao(new EnviadorDeSms());

