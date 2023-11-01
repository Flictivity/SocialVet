using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Token;

public sealed record GenerateTokenCommand(string Email, int Id, string Role, string Name) : IRequest<TokenDTO>;