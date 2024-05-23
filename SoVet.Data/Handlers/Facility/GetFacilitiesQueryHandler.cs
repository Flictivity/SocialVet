using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Facility;

namespace SoVet.Data.Handlers.Facility;

public sealed class GetFacilitiesQueryHandler : IRequestHandler<GetFacilitiesQuery, List<Domain.Models.Facility>>
{
    private readonly IFacilityRepository _repository;

    public GetFacilitiesQueryHandler(IFacilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Models.Facility>> Handle(GetFacilitiesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetFacilitiesAsync();
    }
}