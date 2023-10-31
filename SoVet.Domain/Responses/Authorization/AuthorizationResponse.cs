using SoVet.Domain.Models;

namespace SoVet.Domain.Responses.Authorization;

public sealed class AuthorizationResponse : BaseResponse
{
    public TokenDTO? Token { get; set; }
}