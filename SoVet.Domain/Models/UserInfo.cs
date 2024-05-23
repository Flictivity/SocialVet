namespace SoVet.Domain.Models;

public class UserInfo
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string RoleName { get; set; } = null!;
}