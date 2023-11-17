using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class DiagnosisRepository : IDiagnosisRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public DiagnosisRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public async Task<List<Diagnosis>> GetDiagnosesAsync(int appointmentId)
    {
        var connection = _context.Database.GetDbConnection();
        return (await connection.QueryAsync<Diagnosis>(DiagnosisRepositoryQueries.GetDiagnoses, new {appointmentId})).AsList();
    }
}