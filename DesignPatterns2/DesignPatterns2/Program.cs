using DesignPatterns2.Cap1;
using DesignPatterns2.Cap2;
using DesignPatterns2.Cap3;
using System.Data;

//cap1
//IDbConnection conexao = new ConnectionFactory().GetConnection();

//IDbCommand comando = conexao.CreateCommand();
//comando.CommandText = "select * from tabela";


//cap2
//NotasMusicais notas = new NotasMusicais();
//IList<INota> musica = new List<INota>()
//{
//    notas.Pega("do"),
//    notas.Pega("re"),
//    notas.Pega("mi"),
//    notas.Pega("fa"),
//    notas.Pega("fa"),
//    notas.Pega("fa"),
//};
//Piano piano = new Piano();
//piano.Toca(musica);

//cap 3
Contrato contrato = new("Mateus");

try
{
    Console.WriteLine(contrato.Tipo);
    contrato.Avanca();

    Console.WriteLine(contrato.Tipo);
    contrato.Avanca();

    Console.WriteLine(contrato.Tipo);
    contrato.Avanca();

    Console.WriteLine(contrato.Tipo);
    contrato.Avanca();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}