using MediatR;

namespace SoVet.Domain.Commands.Token;

public sealed record GenerateTokenCommand(string Email, int Id) : IRequest<string>;