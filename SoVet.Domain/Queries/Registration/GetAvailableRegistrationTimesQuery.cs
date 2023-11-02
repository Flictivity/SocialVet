using MediatR;

namespace SoVet.Domain.Queries.Registration;

public sealed record GetAvailableRegistrationTimesQuery (int EmployeeId, DateOnly RegistrationDate) : IRequest<List<TimeSpan>?>;