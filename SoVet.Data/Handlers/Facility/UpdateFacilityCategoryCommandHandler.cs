using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Facility;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Facility;

public sealed class UpdateFacilityCategoryCommandHandler : IRequestHandler<UpdateFacilityCategoryCommand, BaseResponse>
{
    private readonly IFacilityRepository _facilityRepository;

    public UpdateFacilityCategoryCommandHandler(IFacilityRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public async Task<BaseResponse> Handle(UpdateFacilityCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _facilityRepository.UpdateFacilityCategory(request.FacilityCategory);
    }
}