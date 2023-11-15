using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services;

public interface IAnimalTypeService
{
    public Task<List<AnimalType>?> GetAnimalTypes();
}