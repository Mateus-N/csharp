using System.ComponentModel.DataAnnotations;

namespace TypeScriptApi.Models;

public record Dado
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public double Montante { get; set; }
    [Required]
    public int Vezes { get; set; }
}
