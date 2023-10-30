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
}