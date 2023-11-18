using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IClientService
{
    public Task<List<Client>?> GetClients();
    public Task<Client?> GetClient(string email);
    public Task<BaseResult?> UpdateClient(Client client, string oldEmail, string? newPassword);
}