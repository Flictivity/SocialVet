using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Results;

public sealed class AuthorizationResult : BaseResult
{
    public TokenDTO? Token { get; set; }
}