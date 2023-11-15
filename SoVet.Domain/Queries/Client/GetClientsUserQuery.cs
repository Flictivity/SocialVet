using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Client;

public sealed record GetClientsUserQuery() : IRequest<List<UserInfo>>;