using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public sealed class Patient
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Обязательное поле")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Обязательное поле")]
    public DateOnly BirthDate { get; set; }
    [Required(ErrorMessage = "Обязательное поле")]
    public AnimalType AnimalType { get; set; } = null!;
    [Required(ErrorMessage = "Обязательное поле")]
    public Client Client { get; set; } = null!;
    public string? Comment { get; set; }
}