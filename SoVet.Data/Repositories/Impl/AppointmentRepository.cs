using Dapper;
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

    public async Task<Appointment?> GetAppointmentAsync(int appointmentId)
    {
        var connection = _context.Database.GetDbConnection();
        var res = await  connection.QueryAsync<Appointment,Employee,Appointment>(AppointmentRepositoryQueries.GetAppointment,
            (appointment, employee) =>
            {
                appointment.Employee = employee;
                return appointment;
            },
            new{appointmentId}, splitOn:"Id");
        return res.FirstOrDefault();
    }
}