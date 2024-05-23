using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public class UserRegistration
{
    [Required(ErrorMessage = "Почта должна быть заполнена!")]
    [EmailAddress(ErrorMessage = "Введенная почта должна быть корректной")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Пароль не может быть пустым!")]
    [DataType(DataType.Password, ErrorMessage = "неверный формат пароля")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Пароль не может быть пустым!")]
    [DataType(DataType.Password, ErrorMessage = "неверный формат пароля")]
    [Compare(nameof(Password), ErrorMessage = "Пароли должны быть одинаковыми")]
    public string ConfirmPassword { get; set; } = null!;
    
    [Required(ErrorMessage = "ФИО не может быть пустым")]
    public string Name { get; set; } = null!;
    public string? Address { get; set; } = null!;
}