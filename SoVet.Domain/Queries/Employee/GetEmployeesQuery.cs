using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesQuery(string RoleName, string ClaimType) : IRequest<List<Models.Employee>>;