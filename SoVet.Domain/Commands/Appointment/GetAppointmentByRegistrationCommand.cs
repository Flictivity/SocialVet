using MediatR;

namespace SoVet.Domain.Commands.Appointment;

public sealed record GetAppointmentByRegistrationCommand(int RegistrationId) : IRequest<Models.Appointment?>;