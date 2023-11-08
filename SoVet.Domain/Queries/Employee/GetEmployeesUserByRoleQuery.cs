using MediatR;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesUserByRoleQuery (string RoleName, string ClaimType) : IRequest<List<int>>;