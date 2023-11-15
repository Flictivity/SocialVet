using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Auth.Models;
using SoVet.Auth.SqlQueries;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Client;

namespace SoVet.Auth.Handlers;

public class GetClientUserQueryHandler : IRequestHandler<GetClientsUserQuery, List<UserInfo>>
{
    private readonly IdentityContext _context;

    public GetClientUserQueryHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<List<UserInfo>> Handle(GetClientsUserQuery request, CancellationToken cancellationToken)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<UserInfo>(UserQueries.GetUsers, new {claimType = UserClaims.ClientId})
            ).AsList();
        return result;
    }
}