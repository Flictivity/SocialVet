using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Auth.Models;
using SoVet.Auth.SqlQueries;
using SoVet.Domain.Queries.Employee;
using SoVet.Domain.SqlQueries;

namespace SoVet.Auth.Handlers;

public sealed class GetEmployeesUserQueryHandler : IRequestHandler<GetEmployeesUserQuery, List<int>>
{
    private readonly IdentityContext _context;

    public GetEmployeesUserQueryHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<List<int>> Handle(GetEmployeesUserQuery request, CancellationToken cancellationToken)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<int>(UserQueries.GetEmployeesUsers,
                    new { roleName = request.RoleName, claimType = request.ClaimType})
            ).AsList();
        return result;
    }
}