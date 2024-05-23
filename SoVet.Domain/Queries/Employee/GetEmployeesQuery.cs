using MediatR;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesQuery() : IRequest<List<Models.EmployeeUser>>;