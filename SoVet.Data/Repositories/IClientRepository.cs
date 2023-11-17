using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IClientRepository
{
    public Task<Client> AddClientAsync(Client client);
    public Task<List<Client>> GetClientsAsync(List<UserInfo> users);
}