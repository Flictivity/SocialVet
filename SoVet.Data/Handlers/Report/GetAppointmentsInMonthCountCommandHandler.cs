using MediatR;
using SoVet.Domain.Commands.Report;

namespace SoVet.Data.Handlers.Report;

public sealed class GetAppointmentsInMonthCountCommandHandler : IRequestHandler<GetAppointmentsInMonthCountCommand, int>
{
    private readonly ApplicationContext _context;

    public GetAppointmentsInMonthCountCommandHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<int> Handle(GetAppointmentsInMonthCountCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_context.Appointments.Count(x => x.CreationDate.Date.Month == DateTime.UtcNow.Date.Month));
    }
}