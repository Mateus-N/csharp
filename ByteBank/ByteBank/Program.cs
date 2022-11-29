using ByteBank;
using ByteBank.Contas;
using ByteBank.Excecoes;

//try
//{
//    ContaCorrente conta = new ContaCorrente(200, 540);
//    ContaCorrente conta2 = new ContaCorrente(300, 550);

//    conta.Depositar(50);
//    Console.WriteLine(conta.Saldo);
//    // conta.Sacar(500);
//    conta.Transferir(500, conta2);
//    Console.WriteLine(conta.Saldo);
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine($"Erro no parâmetro: {ex.ParamName}");
//    Console.WriteLine("Ocorreu um erro do tipo ArguementException.");
//    Console.WriteLine(ex.Message);
//}
//catch (SaldoInsuficienteException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//catch (OperacaoFinanceiraException ex)
//{
//    Console.WriteLine(ex.Message);
//    Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");
//    Console.WriteLine(ex.InnerException.Message);

//}

LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");

try
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
catch (IOException)
{
    Console.WriteLine($"Exceção do tipo IO capturada e tratada");
}
finally
{
    leitor.Fechar();
}