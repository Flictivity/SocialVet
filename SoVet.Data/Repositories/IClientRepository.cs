using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IClientRepository
{
    public Task<Domain.Models.Client> AddClientAsync(Domain.Models.Client client);
    public Task<List<Domain.Models.Client>> GetClientsAsync(List<UserInfo> users);
}