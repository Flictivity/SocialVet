using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Auth.SqlQueries;
using SoVet.Domain.Queries;

namespace SoVet.Auth.Handlers;

public sealed class GetUserEmailQueryHandler : IRequestHandler<GetUserEmailQuery, string>
{
    private readonly IdentityContext _context;

    public GetUserEmailQueryHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(GetUserEmailQuery request, CancellationToken cancellationToken)
    {
        var connection = _context.Database.GetDbConnection();
        var result = await connection
            .QueryFirstOrDefaultAsync<string>(UserQueries.GetUserEmail,
                new { userId = request.UserId.ToString(), claimType = request.ClaimType });

        return result ?? string.Empty;
    }
}