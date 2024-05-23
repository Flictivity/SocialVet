namespace SoVet.Data.Repositories;

public interface IAnimalTypeRepository
{
    public Task<List<Domain.Models.AnimalType>> GetAnimalTypesAsync();
}