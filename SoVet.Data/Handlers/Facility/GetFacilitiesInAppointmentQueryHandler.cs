using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Facility;

namespace SoVet.Data.Handlers.Facility;

public sealed class
    GetFacilitiesInAppointmentQueryHandler : IRequestHandler<GetFacilitiesInAppointmentQuery, List<AppointmentFacility>>
{
    private readonly IFacilityRepository _repository;

    public GetFacilitiesInAppointmentQueryHandler(IFacilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AppointmentFacility>> Handle(GetFacilitiesInAppointmentQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetFacilitiesInAppointment(request.AppointmentId);
    }
}