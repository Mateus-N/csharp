using ByteBank.Contas;
using ByteBank.Titular;

//ContaCorrente contaDoAndre = new ContaCorrente
//{
//    Titular = "André Silva",
//    NumeroAgencia = 15,
//    Conta = "1010-X",
//};

//Console.WriteLine($"Saldo da conta do André = {contaDoAndre.Saldo}");

//ContaCorrente contaDoAndre2 = new ContaCorrente
//{
//    Titular = "André Silva",
//    NumeroAgencia = 15,
//    Conta = "1010-X",
//};

//Console.WriteLine($"Saldo da conta do André = {contaDoAndre2.Saldo}");

//Console.WriteLine(contaDoAndre == contaDoAndre2);

//ContaCorrente contaDaMaria = new ContaCorrente
//{
//    Titular = "Maria Souza",
//    NumeroAgencia = 17,
//    Conta = "1010-5",
//    Saldo = 350
//};

//Console.WriteLine($"Saldo da conta da Maria = {contaDaMaria.Saldo}");

//contaDoAndre.Transferir(50, contaDaMaria);

//Console.WriteLine($"Saldo da conta do André pós-transferência = {contaDoAndre.Saldo}");
//Console.WriteLine($"Saldo da conta da Maria pós-transferência = {contaDaMaria.Saldo}");

//ContaCorrente contaDoPedro = new ContaCorrente();
//Console.WriteLine(contaDoPedro.Titular);
//Console.WriteLine(contaDoPedro.Saldo);
//Console.WriteLine(contaDoPedro.NumeroAgencia);
//Console.WriteLine(contaDoPedro.Conta);

//Cliente cliente = new Cliente
//{
//    Nome = "André Silva",
//    Cpf = "12345678910",
//    Profissao = "Análista"
//};

//ContaCorrente conta = new ContaCorrente
//{
//    Titular = cliente,
//    Conta = "1010-X",
//    NumeroAgencia = 15
//};

//conta.ExibirDadosDaConta();

//ContaCorrente conta3 = new ContaCorrente();
//conta3.Saldo = 50;
//Console.WriteLine($"saldo conta3 {conta3.Saldo}");

//ContaCorrente conta4 = new ContaCorrente(18, "1010-X");
//conta4.Saldo = 500;
//conta4.Titular = new Cliente();

//Console.WriteLine(conta4.Saldo);
//Console.WriteLine(conta4.NumeroAgencia);

ContaCorrente conta5 = new ContaCorrente(283, "1234-X");
Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
ContaCorrente conta6 = new ContaCorrente(284, "2223-X");
Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
