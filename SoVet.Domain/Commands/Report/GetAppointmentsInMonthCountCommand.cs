using MediatR;

namespace SoVet.Domain.Commands.Report;

public record GetAppointmentsInMonthCountCommand() : IRequest<int>;