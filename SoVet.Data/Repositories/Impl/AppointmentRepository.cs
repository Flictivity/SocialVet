using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

public sealed class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public AppointmentRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
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

    public async Task<BaseResponse> SaveAppointmentAsync(Appointment appointment)
    {
        _context.ChangeTracker.Clear();

        var existAppointment = _context.Appointments.FirstOrDefault(x => x.Id == appointment.Id);
        if (existAppointment is null && _context.Appointments.Any(x => x.RegistrationId == appointment.RegistrationId))
        {
            return new BaseResponse { IsSuccess = false, Message = AppointmentErrorMessages.AppointmentToRegistrationAlreadyExist};
        }
        var appointmentDb = _mapper.Map(appointment);
        if (existAppointment is null)
        {
            await _context.Appointments.AddAsync(appointmentDb);
        }
        else
        {
            _context.Appointments.Update(appointmentDb);
        }
        await _context.SaveChangesAsync();
        return new BaseResponse { IsSuccess = true };
    }
}