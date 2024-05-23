using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Facility;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Facility;

public sealed class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, BaseResponse>
{
    private readonly IFacilityRepository _facilityRepository;

    public UpdateFacilityCommandHandler(IFacilityRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public Task<BaseResponse> Handle(UpdateFacilityCommand request, CancellationToken cancellationToken)
    {
        return _facilityRepository.UpdateFacility(request.Facility);
    }
}