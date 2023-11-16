using SoVet.Data.Mappers;

namespace SoVet.Data.Repositories.Impl;

public sealed class AnimalTypeRepository : IAnimalTypeRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public AnimalTypeRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public Task<List<Domain.Models.AnimalType>> GetAnimalTypesAsync()
    {
        return Task.FromResult(_context.AnimalType.Select(type => _mapper.Map(type)).ToList());
    }
}