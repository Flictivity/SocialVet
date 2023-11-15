using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services;

public interface IClientService
{
    public Task<List<Client>?> GetClients();
}