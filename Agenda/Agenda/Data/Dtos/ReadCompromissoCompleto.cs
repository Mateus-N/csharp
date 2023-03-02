using Agenda.Models;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Data.Dtos;

public class ReadCompromissoCompleto
{
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataEHorario { get; set; }
    public ReadUsuario Usuario { get; set; }
}
