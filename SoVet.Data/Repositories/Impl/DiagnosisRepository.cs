using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using SoVet.Domain.SqlQueries;
using Diagnosis = SoVet.Domain.Models.Diagnosis;

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

    public async Task<List<AppointmentDiagnoses>> GetAppointmentDiagnosesAsync(int appointmentId)
    {
        var connection = _context.Database.GetDbConnection();
        
        var result = (await connection.QueryAsync<AppointmentDiagnoses,Diagnosis,AppointmentDiagnoses>(
            DiagnosisRepositoryQueries.GetDiagnoses, 
            (appointmentDiagnosis, diagnosis) =>
            {
                appointmentDiagnosis.Diagnosis = diagnosis;
                return appointmentDiagnosis;
            },new{appointmentId})).AsList();

        return result;
    }

    public async Task<BaseResponse> SaveDiagnosisAsync(Diagnosis diagnosis)
    {
        _context.ChangeTracker.Clear();

        var existDiagnosis = _context.Diagnoses.FirstOrDefault(x => x.Id == diagnosis.Id);
        var diagnosisDb = _mapper.Map(diagnosis);
        if (existDiagnosis is null)
        {
            await _context.Diagnoses.AddAsync(diagnosisDb);
        }
        else
        {
            _context.Diagnoses.Update(diagnosisDb);
        }
        await _context.SaveChangesAsync();
        return new BaseResponse { IsSuccess = true };
    }

    public async Task<BaseResponse> DeleteDiagnosisAsync(int diagnosisId)
    {
        _context.ChangeTracker.Clear();
        var diagnosisDb = _context.Diagnoses.FirstOrDefault(x => x.Id == diagnosisId);
        if (diagnosisDb is null)
            return new BaseResponse{ IsSuccess = false, Message = "Диагноз не найден" };

        _context.Diagnoses.Remove(diagnosisDb);
        await _context.SaveChangesAsync();
        return new BaseResponse{ IsSuccess = true};
    }

    public async Task<List<Diagnosis>> GetDiagnosesAsync()
    {
        return await _context.Diagnoses.Select(x => _mapper.Map(x)).ToListAsync();
    }
}