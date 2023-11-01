﻿using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Models;

namespace SoVet.Data.Repositories.Impl;

public sealed class ClinicRepository : IClinicRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public ClinicRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public async Task<Clinic?> GetClinicInfo()
    {
        var clinicDb = await _context.ClinicSchedules.FirstOrDefaultAsync(x => true);
        return clinicDb is not null ? _mapper.Map(clinicDb) : null;
    }
}