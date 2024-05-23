using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services;

public interface ITokenService
{
    Task<TokenDTO?> GetToken();
    Task RemoveToken();
    Task SetToken(TokenDTO token);
}