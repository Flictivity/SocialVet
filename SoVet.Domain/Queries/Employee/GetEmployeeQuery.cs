using MediatR;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeeQuery(string Email) : IRequest<Models.EmployeeUser?>;