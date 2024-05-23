using MediatR;
using Microsoft.EntityFrameworkCore;
using SoVet.Data.Mappers;
using SoVet.Domain.Commands.Appointment;

namespace SoVet.Data.Handlers.Appointment;

public sealed class GetAppointmentByRegistrationCommandHandler : IRequestHandler<GetAppointmentByRegistrationCommand, Domain.Models.Appointment?>
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public GetAppointmentByRegistrationCommandHandler(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public async Task<Domain.Models.Appointment?> Handle(GetAppointmentByRegistrationCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _context.Appointments.Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.RegistrationId == request.RegistrationId, cancellationToken: cancellationToken);
        return appointment is null ? null : _mapper.Map(appointment);
    }
}