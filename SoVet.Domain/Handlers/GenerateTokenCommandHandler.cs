using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SoVet.Domain.Commands.Token;
using SoVet.Domain.Models;
using SoVet.Domain.Services;
using SoVet.Domain.Settings;

namespace SoVet.Domain.Handlers;

public sealed class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, TokenDTO>
{
    private readonly JwtSettings _jwtSettings;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IEncryptionService _encryptionService;

    public GenerateTokenCommandHandler(JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters,
        IEncryptionService encryptionService)
    {
        _jwtSettings = jwtSettings;
        _tokenValidationParameters = tokenValidationParameters;
        _encryptionService = encryptionService;
    }

    public Task<TokenDTO> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key));

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, request.Name),
            new(ClaimTypes.Role, request.Role),
            new(ClaimTypes.Email, request.Email),
            new("id", request.Id.ToString())
        };
        claims.AddRange(request.Claims.Select(claim => new Claim(claim.Type, claim.Value)));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.Add(_jwtSettings.AccessTokenLifetime),
            signingCredentials: credentials);

        var accessToken = tokenHandler.WriteToken(token);

        return Task.FromResult(new TokenDTO
            { Token = accessToken, Expiration =  DateTime.Now.Add(_jwtSettings.AccessTokenLifetime)});
    }
}