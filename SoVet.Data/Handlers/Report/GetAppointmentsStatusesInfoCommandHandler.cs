using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Domain.Commands.Report;
using SoVet.Domain.Extensions;
using SoVet.Domain.Models;

namespace SoVet.Data.Handlers.Report;

public sealed class GetAppointmentsStatusesInfoCommandHandler : IRequestHandler<GetAppointmentsStatusesInfoCommand, DataItem[]>
{
    private readonly ApplicationContext _context;

    public GetAppointmentsStatusesInfoCommandHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<DataItem[]> Handle(GetAppointmentsStatusesInfoCommand request, CancellationToken cancellationToken)
    {
        var todayDate = DateTime.UtcNow.Date;
        var result = (from AppointmentStatus diagnosisResult in Enum.GetValues(typeof(AppointmentStatus)) 
            let count = _context.Appointments.Count(x => (x.CreationDate.Date == todayDate || x.ChangeDate.Date == todayDate) 
                                                         && x.AppointmentStatus == (int)diagnosisResult) 
            select new DataItem { Category = diagnosisResult.GetDisplayName()!, Count = count }).ToList();

        return Task.FromResult(result.ToArray());
    }
}