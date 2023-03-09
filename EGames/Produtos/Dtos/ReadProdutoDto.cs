namespace Produtos.Dtos;

public class ReadProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Descricao { get; set; }
    public string EstadoDoProduto { get; set; }
}
