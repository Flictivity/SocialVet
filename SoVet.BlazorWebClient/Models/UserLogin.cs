using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public sealed class UserLogin
{
    [Required(ErrorMessage = "Почта должна быть заполнена!")]
    [EmailAddress(ErrorMessage = "Введенная почта должна быть корректной")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Пароль не может быть пустым!")]
    [DataType(DataType.Password, ErrorMessage = "неверный формат пароля")]
    public string Password { get; set; } = null!;
}