using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public sealed class Facility
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Обязательное поле!")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Обязательное поле!")]
    public decimal Cost { get; set; }
    [Required(ErrorMessage = "Обязательное поле!")]
    public FacilityCategory FacilityCategory { get; set; } = null!;
}