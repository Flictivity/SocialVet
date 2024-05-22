using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public abstract class BaseReference
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Обязательное поле")]
    public string Name { get; set; } = null!;
}