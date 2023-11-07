using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class RegistrationRepository : IRegistrationRepository
{
    private readonly ApplicationContext _context;

    public RegistrationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<TimeSpan>?> GetTimes(int employeeId, DateOnly registrationDate)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<DateTime>(RegistrationRepositoryQueries.GetavailableTimes,
                    new { dateReg = registrationDate, employeeId })
            ).Select(x => x.TimeOfDay).AsList();

        return result;
    }
}