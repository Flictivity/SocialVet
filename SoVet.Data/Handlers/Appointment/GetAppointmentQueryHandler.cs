using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Appointment;

namespace SoVet.Data.Handlers.Appointment;

public sealed class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, Domain.Models.Appointment?>
{
    private readonly IAppointmentRepository _repository;

    public GetAppointmentQueryHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public Task<Domain.Models.Appointment?> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAppointmentAsync(request.AppointmentId);
    }
}