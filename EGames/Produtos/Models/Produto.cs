using Produtos.Models.Enums;

namespace Produtos.Models;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Descricao { get; set; }
    public EstadoDoProduto EstadoDoProduto { get; set; }
}
