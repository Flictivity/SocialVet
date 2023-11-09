using System.Security.Claims;
using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Commands.Token;

public sealed record GenerateTokenCommand(string Email, int Id, string Role, string Name, List<Claim> Claims) : IRequest<TokenDTO>;