using SoVet.Domain.Models;
using AnimalType = SoVet.Data.Entities.AnimalType;

namespace SoVet.Data.Repositories;

public interface IAnimalTypeRepository
{
    public Task<List<Domain.Models.AnimalType>> GetAnimalTypesAsync();
}