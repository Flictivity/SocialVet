using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Domain.Models;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class PatientRepository : IPatientRepository
{
    private readonly ApplicationContext _context;

    public PatientRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Patient>> GetPatients(int? clientId)
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(PatientRepositoryQueries.GetPatients);
        if (clientId is not null)
            builder.Where($"p.client_id = {clientId}");
        
        var connection = _context.Database.GetDbConnection();
        var result = (await connection.QueryAsync<Patient>(selector.RawSql)).AsList();

        return result;
    }
}