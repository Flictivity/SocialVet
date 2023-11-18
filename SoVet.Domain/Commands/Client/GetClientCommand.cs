using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Client;

public sealed record GetClientCommand(List<UserInfo> Users, string Email) : IRequest<Models.Client>;