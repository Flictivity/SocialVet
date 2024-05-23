using MediatR;

namespace SoVet.Domain.Queries;

public sealed record GetUserEmailQuery(int UserId, string ClaimType) : IRequest<string>;