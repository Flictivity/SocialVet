using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SoVet.Domain.Commands.Token;
using SoVet.Domain.Services;
using SoVet.Domain.Settings;

namespace SoVet.Domain.Handlers;

public sealed class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
{
    private readonly JwtSettings _jwtSettings;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IEncryptionService _encryptionService;

    public GenerateTokenCommandHandler(JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, IEncryptionService encryptionService)
    {
        _jwtSettings = jwtSettings;
        _tokenValidationParameters = tokenValidationParameters;
        _encryptionService = encryptionService;
    }
    
    public Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, request.Email),
                new Claim("id", request.Id.ToString())
            }),
            Expires = DateTime.UtcNow.Add(_jwtSettings.AccessTokenLifetime),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var accessToken = tokenHandler.CreateToken(tokenDescriptor);

        return Task.FromResult(tokenHandler.WriteToken(accessToken));
    }
}