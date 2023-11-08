using MediatR;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesUserQuery (string RoleName, string ClaimType) : IRequest<List<int>>;