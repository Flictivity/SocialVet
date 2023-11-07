using MediatR;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesQuery(int[] EmployeeIds) : IRequest<List<Models.Employee>>;