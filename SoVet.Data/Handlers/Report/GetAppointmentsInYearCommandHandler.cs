using MediatR;
using SoVet.Domain.Commands.Report;
using SoVet.Domain.Models;

namespace SoVet.Data.Handlers.Report;

public sealed class GetAppointmentsInYearCommandHandler : IRequestHandler<GetAppointmentsInYearCommand, DataItem[]>
{
    private readonly ApplicationContext _context;

    public GetAppointmentsInYearCommandHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<DataItem[]> Handle(GetAppointmentsInYearCommand request, CancellationToken cancellationToken)
    {
        var months = new Dictionary<int, string>()
        {
            { 1, "Янв." },
            { 2, "Фев." },
            { 3, "Мар." },
            { 4, "Апр." },
            { 5, "Май" },
            { 6, "Июнь" },
            { 7, "Июль" },
            { 8, "Авг." },
            { 9, "Сен." },
            { 10, "Окт." },
            { 11, "Нояб." },
            { 12, "Дек." },
        };
        
        var result = new List<DataItem>();
        for (var i = 1; i < 13; ++i)
        {
            var count = _context.Appointments.Count(x => x.CreationDate.Date.Year == request.Year
                                                         && x.CreationDate.Date.Month == i);
            result.Add(new DataItem{Category = months[i], Count = count});
        }

        return Task.FromResult(result.ToArray());
    }
}