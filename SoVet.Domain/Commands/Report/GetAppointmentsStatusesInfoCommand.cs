using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Report;

public sealed record GetAppointmentsStatusesInfoCommand : IRequest<DataItem[]>;