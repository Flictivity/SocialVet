using MediatR;

namespace SoVet.Domain.Queries.Registration;

public sealed record GetRegistrationsQuery(int? EmployeeId, int? ClientId = null) : IRequest<List<Models.Registration>?>;