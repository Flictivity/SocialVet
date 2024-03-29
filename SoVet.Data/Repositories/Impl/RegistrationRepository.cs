using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class RegistrationRepository : IRegistrationRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public RegistrationRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public async Task<List<TimeSpan>?> GetTimes(int employeeId, DateOnly registrationDate)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<DateTime>(RegistrationRepositoryQueries.GetAvailableTimes,
                    new { dateReg = registrationDate, employeeId })
            ).Select(x => x.TimeOfDay).AsList();

        return result;
    }

    public async Task<BaseResponse> CreateRegistration(Registration registration)
    {
        registration.StartTime = DateTime.SpecifyKind(registration.StartTime, DateTimeKind.Utc);
        var registrationDb = _mapper.Map(registration);
        _context.Registrations.Add(registrationDb);
        await _context.SaveChangesAsync();
        return new BaseResponse { IsSuccess = true };
    }

    public async Task<List<Registration>> GetRegistrations(int? employeeId, int? clientId = null)
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(RegistrationRepositoryQueries.GetRegistrations);
        if (employeeId is not null)
            builder.Where($"r.employee_id = {employeeId}");
        if (clientId is not null)
            builder.Where($"r.client_id = {clientId}");
        var connection = _context.Database.GetDbConnection();
        var result = (await connection
                .QueryAsync<Registration>(selector.RawSql)
            ).AsList();

        return result;
    }
}