using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Appointment;

namespace SoVet.Data.Handlers.Appointment;

public sealed class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, List<AppointmentTable>>
{
    private readonly IAppointmentRepository _repository;

    public GetAppointmentsQueryHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public Task<List<AppointmentTable>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAppointmentsAsync(request.PatientId);
    }
}