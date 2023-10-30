namespace SoVet.Domain.Settings;

public sealed class JwtSettings
{
    public string Key { get; set; } = null!;
    public TimeSpan AccessTokenLifetime { get; set; }
}