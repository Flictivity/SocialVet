using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Employee;

public sealed record GetEmployeesUserQuery() : IRequest<List<UserInfo>>;