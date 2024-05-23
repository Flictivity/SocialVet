using MediatR;

namespace SoVet.Domain.Queries.Appointment;

public sealed record GetAppointmentQuery(int AppointmentId) : IRequest<Models.Appointment?>;