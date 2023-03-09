using Produtos.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Dtos;

public class CreateProdutoDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public double Preco { get; set; }
    [Required]
    public string Descricao { get; set; }
    [Required]
    public EstadoDoProduto EstadoDoProduto { get; set; }
}
