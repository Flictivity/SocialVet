using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Report;

public record GetAppointmentsInYearCommand(int Year) : IRequest<DataItem[]>;