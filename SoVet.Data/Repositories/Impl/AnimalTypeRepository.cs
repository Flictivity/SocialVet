using Dapper;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using AnimalType = SoVet.Data.Entities.AnimalType;

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

    public async Task<List<Domain.Models.AnimalType>> GetAnimalTypesAsync()
    {
        return _context.AnimalTypes.Select(type => _mapper.Map(type)).ToList();
    }
}