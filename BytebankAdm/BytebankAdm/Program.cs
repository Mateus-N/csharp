using BytebankAdm.Funcionarios;
using BytebankAdm.Parceria;
using BytebankAdm.SistemaInterno;
using BytebankAdm.Utilitario;

#region
//Funcionario pedro = new Funcionario("12345678910", 2000);
//pedro.Nome = "Pedro Malazartes";

//Console.WriteLine(pedro.Nome);
//Console.WriteLine(pedro.GetBonificacao());

//Diretor roberta = new Diretor("98765432101");
//roberta.Nome = "Roberta Silva";

//Console.WriteLine(roberta.Nome);
//Console.WriteLine(roberta.GetBonificacao());

//GerenciadorDeBonificacao gerenciador = new GerenciadorDeBonificacao();
//gerenciador.Registrar(pedro);
//gerenciador.Registrar(roberta);

//Console.WriteLine(gerenciador.TotalDeBonificacoes);
//Console.WriteLine(Funcionario.TotalDeFuncionarios);

//pedro.AumentarSalario();
//roberta.AumentarSalario();

//Console.WriteLine($"Novo salário do Pedro: {pedro.Salario}");
//Console.WriteLine($"Novo salário da Roberta: {roberta.Salario}");
#endregion

CalcularBonificacao();

UsarSistema();

void CalcularBonificacao()
{
    GerenciadorDeBonificacao gerenciador = new GerenciadorDeBonificacao();

    Designer ulisses = new Designer("12345678910");
    ulisses.Nome = "Ulisses Souza";

    Diretor paula = new Diretor("98765432101");
    paula.Nome = "Paula Silva";

    Auxiliar igor = new Auxiliar("54687981321");
    igor.Nome = "Igor Dias";

    GerenteDeContas camila = new GerenteDeContas("32165498765");
    camila.Nome = "Camila Oliveira";

    gerenciador.Registrar(camila);
    gerenciador.Registrar(igor);
    gerenciador.Registrar(paula);
    gerenciador.Registrar(ulisses);

    Console.WriteLine($"Total de bonificação: {gerenciador.TotalDeBonificacoes}");
}

void UsarSistema()
{
    SistemaInterno sistema = new SistemaInterno();

    Diretor ingrid = new Diretor("12345645655");
    ingrid.Nome = "Ingrid Novaes";
    ingrid.Senha = "123";

    GerenteDeContas ursula = new GerenteDeContas("12312312312");
    ursula.Nome = "Ursula Nunes";
    ursula.Senha = "321";

    ParceiroComercial caio = new ParceiroComercial();
    caio.Senha = "999";

    sistema.Logar(ingrid, "123");
    sistema.Logar(ursula, "963");
    sistema.Logar(caio, "999");
}