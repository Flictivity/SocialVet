using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public sealed class Diagnosis
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Обязательное поле!")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}