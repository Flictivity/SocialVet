using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Report;

public record GetEmployeeReportCommand(DateTime Start, DateTime End) : IRequest<List<EmployeeReport>>;