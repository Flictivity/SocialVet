using Dapper;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using SoVet.Domain.SqlQueries;

namespace SoVet.Data.Repositories.Impl;

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

    public async Task<BaseResponse> DeleteFacilityInAppointmentAsync(int appointmentFacilityId)
    {
        _context.ChangeTracker.Clear();
        var appointmentFacilityDb = _context.AppointmentFacilities.FirstOrDefault(x => x.Id == appointmentFacilityId);
        if (appointmentFacilityDb is null)
            return new BaseResponse{ IsSuccess = false, Message = "Услуга не найден" };

        _context.AppointmentFacilities.Remove(appointmentFacilityDb);
        await _context.SaveChangesAsync();
        return new BaseResponse{ IsSuccess = true};
    }

    public async Task<BaseResponse> UpdateFacility(Facility facility)
    {
        var facilityDb = _mapper.Map(facility);
        _context.Facilities.Update(facilityDb);
        await _context.SaveChangesAsync();
        
        _context.ChangeTracker.Clear();

        return new BaseResponse { IsSuccess = true };
    }

    public async Task<BaseResponse> UpdateFacilityCategory(FacilityCategory facilityCategory)
    {
        var facilityCategoryDb = _mapper.Map(facilityCategory);
        _context.FacilityCategories.Update(facilityCategoryDb);
        await _context.SaveChangesAsync();
        
        _context.ChangeTracker.Clear();

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

    public async Task<List<Facility>> GetFacilitiesAsync()
    {
        var connection = _context.Database.GetDbConnection();
        var result = (await connection.QueryAsync<Facility,FacilityCategory,Facility>(
            FacilityRepositoryQueries.GetFacilities, 
            (facility, facilityCategory) =>
            {
                facility.FacilityCategory = facilityCategory;
                return facility;
            })).AsList();

        return result;
    }

    public Task<List<FacilityCategory>> GetFacilityCategoriesAsync()
    {
        return Task.FromResult(_context.FacilityCategories.Where(x => !x.IsDeleted)
            .Select(x => _mapper.Map(x)).ToList());
    }

    public async Task<List<FacilityReport>> GetReport(DateTime start, DateTime end)
    {
        var connection = _context.Database.GetDbConnection();
        return (await connection.QueryAsync<FacilityReport>(FacilityRepositoryQueries.GetReport, new{start,end})).AsList();
    }
}