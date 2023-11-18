﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories;

public sealed class FacilityRepository : IFacilityRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public FacilityRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public async Task<BaseResponse> SaveFacilityInAppointmentAsync(AppointmentFacility facility)
    {
        _context.ChangeTracker.Clear();

        var existFacility = _context.AppointmentFacilities.FirstOrDefault(x => x.Id == facility.Id);
        var facilityDb = _mapper.Map(facility);
        if (existFacility is null)
        {
            await _context.AppointmentFacilities.AddAsync(facilityDb);
        }
        else
        {
            _context.AppointmentFacilities.Update(facilityDb);
        }
        await _context.SaveChangesAsync();
        return new BaseResponse { IsSuccess = true };
    }

    public async Task<List<AppointmentFacility>> GetFacilitiesInAppointment(int appointmentId)
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection.QueryAsync<AppointmentFacility,Facility,AppointmentFacility>(
            FacilityRepositoryQueries.GetFacilitiesInAppointment, 
            (appointmentFacility, facility) =>
            {
                appointmentFacility.Facility = facility;
                return appointmentFacility;
            },new{appointmentId})).AsList();

        return result;
    }
}