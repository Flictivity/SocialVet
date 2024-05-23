using MediatR;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesByRoleQuery(string RoleName, string ClaimType) : IRequest<List<Models.Employee>>;