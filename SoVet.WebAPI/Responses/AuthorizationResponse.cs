using SoVet.Domain.Models;

namespace SoVet.WebAPI.Responses;

public sealed class AuthorizationResponse : BaseResponse
{
    public string? Token { get; set; }
}