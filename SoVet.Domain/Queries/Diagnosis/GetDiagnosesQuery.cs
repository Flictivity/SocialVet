using MediatR;

namespace SoVet.Domain.Queries.Diagnosis;

public sealed record GetDiagnosesQuery : IRequest<List<Models.Diagnosis>>;