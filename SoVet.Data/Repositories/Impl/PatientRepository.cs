using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class PatientRepository : IPatientRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public PatientRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public async Task<List<Patient>> GetPatientsAsync(int? clientId)
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(PatientRepositoryQueries.GetPatients);
        if (clientId is not null)
            builder.Where($"p.client_id = {clientId}");
        
        var connection = _context.Database.GetDbConnection();
        var result = (await connection.QueryAsync<Patient, AnimalType, Client,Patient>(selector.RawSql,
            (patient, at, c) =>
            {
                patient.AnimalType = at;
                patient.Client = c;
                return patient;
            })).AsList();

        return result;
    }

    public async Task<Patient?> GetPatientAsync(int patientId)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection.QueryAsync<Patient, AnimalType, Client,Patient>(PatientRepositoryQueries.GetPatient,
            (patient, at, c) =>
            {
                patient.AnimalType = at;
                patient.Client = c;
                return patient;
            })).AsList();

        return result.FirstOrDefault();
    }

    public async Task<BaseResponse> CreatePatientAsync(Patient patient)
    {
        var patientDb = _mapper.Map(patient);
        await _context.Patients.AddAsync(patientDb);
        await _context.SaveChangesAsync();
        return new BaseResponse{IsSuccess = true};
    }

    public async Task<BaseResponse> UpdatePatientAsync(Patient patient)
    {
        _context.ChangeTracker.Clear();
        var patientDb = _mapper.Map(patient);
        _context.Patients.Update(patientDb);
        await _context.SaveChangesAsync();
        return new BaseResponse{IsSuccess = true};
    }
}