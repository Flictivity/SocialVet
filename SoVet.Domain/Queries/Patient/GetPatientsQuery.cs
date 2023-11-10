using MediatR;

namespace SoVet.Domain.Queries.Patient;

public sealed record GetPatientsQuery(int? ClientId) : IRequest<List<Models.Patient>>;