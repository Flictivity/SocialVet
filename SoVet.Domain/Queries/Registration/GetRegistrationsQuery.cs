using MediatR;

namespace SoVet.Domain.Queries.Registration;

public sealed record GetRegistrationsQuery(int? EmployeeId) : IRequest<List<Models.Registration>?>;