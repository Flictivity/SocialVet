using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Client;

public sealed record GetClientsQuery(List<UserInfo> Users) : IRequest<List<Models.Client>>;