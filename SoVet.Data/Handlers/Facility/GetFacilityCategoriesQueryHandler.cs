using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Facility;

namespace SoVet.Data.Handlers.Facility;

public sealed class GetFacilityCategoriesQueryHandler : IRequestHandler<GetFacilityCategoriesQuery, List<FacilityCategory>>
{
    private readonly IFacilityRepository _facilityRepository;

    public GetFacilityCategoriesQueryHandler(IFacilityRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public async Task<List<FacilityCategory>> Handle(GetFacilityCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _facilityRepository.GetFacilityCategoriesAsync();
    }
}