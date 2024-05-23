using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Reference;

namespace SoVet.Data.Handlers.Reference;

public sealed class GetAnimalTypeQueryHandler : IRequestHandler<GetAnimalTypeQuery, List<AnimalType>>
{
    private readonly IAnimalTypeRepository _repository;

    public GetAnimalTypeQueryHandler(IAnimalTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AnimalType>> Handle(GetAnimalTypeQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAnimalTypesAsync();
    }
}