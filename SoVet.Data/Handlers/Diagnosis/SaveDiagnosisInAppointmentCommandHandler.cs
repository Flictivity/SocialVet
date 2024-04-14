using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Diagnosis;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Diagnosis;

public sealed class SaveDiagnosisInAppointmentCommandHandler : IRequestHandler<SaveDiagnosisInAppointmentCommand, BaseResponse>
{
    private readonly IDiagnosisRepository _diagnosisRepository;

    public SaveDiagnosisInAppointmentCommandHandler(IDiagnosisRepository diagnosisRepository)
    {
        _diagnosisRepository = diagnosisRepository;
    }

    public Task<BaseResponse> Handle(SaveDiagnosisInAppointmentCommand request, CancellationToken cancellationToken)
    {
        return _diagnosisRepository.SaveDiagnosisInAppointmentAsync(request.AppointmentDiagnoses);
    }
}