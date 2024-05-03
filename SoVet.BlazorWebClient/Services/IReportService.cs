﻿using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services;

public interface IReportService
{
    public Task<DataItem[]> AppointmentsStatusesInfo();
    public Task<DataItem[]> AppointmentsInYear(int year);
    public Task<int> AppointmentsInMonthCount();
    public Task<List<FacilityReport>> FacilityReport(DateTime start, DateTime end);
}