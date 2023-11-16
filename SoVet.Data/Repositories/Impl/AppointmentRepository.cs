﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Domain.Models;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationContext _context;

    public AppointmentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<AppointmentTable>> GetAppointmentsAsync(int patientId)
    {
        var connection = _context.Database.GetDbConnection();
        var res =  (await connection.QueryAsync<AppointmentTable>(AppointmentRepositoryQueries.GetAppointments, new {patientId})).AsList();
        return res;
    }
}