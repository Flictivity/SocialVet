using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Auth.SqlQueries;
using SoVet.Domain.Queries.Employee;

namespace SoVet.Auth.Handlers;

public sealed class GetEmployeesUserByRoleQueryHandler : IRequestHandler<GetEmployeesUserByRoleQuery, List<int>>
{
    private readonly IdentityContext _context;

    public GetEmployeesUserByRoleQueryHandler(IdentityContext context)
    {
        _context = context;
    }

    public async Task<List<int>> Handle(GetEmployeesUserByRoleQuery request, CancellationToken cancellationToken)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<int>(UserQueries.GetEmployeesUsersByRole,
                    new { roleName = request.RoleName, claimType = request.ClaimType})
            ).AsList();
        return result;
    }
}