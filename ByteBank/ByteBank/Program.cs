using ByteBank;

ContaCorrente contaDoAndre = new ContaCorrente();
contaDoAndre.Titular = "André Silva";
contaDoAndre.NumeroAgencia = 15;
contaDoAndre.Conta = "1010-X";
contaDoAndre.Saldo = 100;

Console.WriteLine($"Saldo da conta do André = {contaDoAndre.Saldo}");

contaDoAndre.Depositar(100);

Console.WriteLine($"Saldo da conta do André = {contaDoAndre.Saldo}");

contaDoAndre.Sacar(300);

Console.WriteLine($"Saldo da conta do André = {contaDoAndre.Saldo}");
