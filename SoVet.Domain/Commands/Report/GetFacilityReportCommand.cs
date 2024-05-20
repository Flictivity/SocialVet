using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Report;

public sealed record GetFacilityReportCommand(DateTime Start, DateTime End) : IRequest<List<FacilityReport>>;