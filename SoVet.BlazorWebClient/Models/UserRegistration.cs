using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public class UserRegistration
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;
    
    [Required]
    public string Name { get; set; } = null!;
    public string? Address { get; set; } = null!;
}