using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Appointment;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Appointment;

public sealed class SaveAppointmentCommandHandler : IRequestHandler<SaveAppointmentCommand,BaseResponse>
{
    private readonly IAppointmentRepository _repository;

    public SaveAppointmentCommandHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(SaveAppointmentCommand request, CancellationToken cancellationToken)
    {
        return await _repository.SaveAppointmentAsync(request.Appointment);
    }
}