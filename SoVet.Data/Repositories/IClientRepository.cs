using LanguageExt.Pipes;

namespace SoVet.Data.Repositories;

public interface IClientRepository
{
    public Task<Domain.Models.Client> AddClientAsync(Domain.Models.Client client);
}