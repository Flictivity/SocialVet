using SoVet.Domain.Responses;

namespace SoVet.Domain.Services;

public interface IEmailService
{
    public Task<BaseResponse> SendEmailAsync(string? email, string subject, string message);
}