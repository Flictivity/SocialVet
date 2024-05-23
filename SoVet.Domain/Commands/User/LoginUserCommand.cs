using MediatR;
using SoVet.Domain.Responses.Authorization;

namespace SoVet.Domain.Commands.User;

public sealed record LoginUserCommand(string Email, string Password) : IRequest<AuthorizationResponse>;