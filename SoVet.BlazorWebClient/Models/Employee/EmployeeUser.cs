using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models.Employee;

public sealed class EmployeeUser
{
    public int Id { get; set; }
    [Required(ErrorMessage = "ФИО не может быть пустым")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "Email не может быть пустым")]
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Роль обязательна!")]
    public string Role { get; set; } = null!;

    public string? Password { get; set; } = null!;
    public string? OldEmail { get; set; } = null!;
}