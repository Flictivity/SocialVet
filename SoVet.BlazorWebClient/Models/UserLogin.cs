using System.ComponentModel.DataAnnotations;

namespace SoVet.BlazorWebClient.Models;

public sealed class UserLogin
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}