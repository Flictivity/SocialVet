using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Auth.Models;
using SoVet.Auth.SqlQueries;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Employee;

namespace SoVet.Auth.Handlers;

public sealed class GetEmployeesUserQueryHandler : IRequestHandler<GetEmployeesUserQuery, List<UserInfo>>
{
    private readonly IdentityContext _context;

    public GetEmployeesUserQueryHandler(IdentityContext context)
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

    public async Task<List<UserInfo>> Handle(GetEmployeesUserQuery request, CancellationToken cancellationToken)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<UserInfo>(UserQueries.GetEmployeesUsers, new {claimType = UserClaims.EmployeeId})
            ).AsList();
        return result;
    }
}