using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Report;
using SoVet.Domain.Models;

namespace SoVet.Data.Handlers.Report;

public sealed class GetFacilityReportCommandHandler : IRequestHandler<GetFacilityReportCommand, List<FacilityReport>>
{
    private readonly IFacilityRepository _facilityRepository;

    public GetFacilityReportCommandHandler(IFacilityRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public async Task<List<FacilityReport>> Handle(GetFacilityReportCommand request, CancellationToken cancellationToken)
    {
        return await _facilityRepository.GetReport(request.Start, request.End);
    }
}