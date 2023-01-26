using MySql.Data.MySqlClient;
using System.Data;

namespace DesignPatterns2.Cap1;

public class ConnectionFactory
{
    public IDbConnection GetConnection()
    {
        IDbConnection conexao = new MySqlConnection
        {
            ConnectionString = "User Id=root;Password=root;Server=localhost;Database=meuBanco"
        };
        conexao.Open();

        return conexao;
    }
}
