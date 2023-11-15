using Dapper;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;

namespace SoVet.Data.Repositories.Impl;

public sealed class ClientRepository : IClientRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public ClientRepository(ApplicationContext context)
    {
        _mapper = new DatabaseMapper();
        _context = context;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        var clientDb = _mapper.Map(client);
        await _context.Clients.AddAsync(clientDb);
        await _context.SaveChangesAsync();
        return _mapper.Map(clientDb);
    }

    public Task<List<Client>> GetClientsAsync(List<UserInfo> users)
    {
        var clients = _context.Clients.AsList();
        var res = (from client in clients
                let clientUser = users.FirstOrDefault(x => x.Id == client.Id)
                where clientUser is not null
                select new Client
                    { Id = client.Id, Name = client.Name, Email = clientUser.Email, Address = client.Address})
            .ToList();

        return Task.FromResult(res);
    }
}