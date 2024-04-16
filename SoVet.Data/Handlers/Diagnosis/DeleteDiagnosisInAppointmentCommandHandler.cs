using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Diagnosis;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Diagnosis;

public sealed class DeleteDiagnosisInAppointmentCommandHandler : IRequestHandler<DeleteDiagnosisInAppointmentCommand, BaseResponse>
{
    private readonly IDiagnosisRepository _diagnosisRepository;

    public DeleteDiagnosisInAppointmentCommandHandler(IDiagnosisRepository diagnosisRepository)
    {
        _diagnosisRepository = diagnosisRepository;
    }

    public Task<BaseResponse> Handle(DeleteDiagnosisInAppointmentCommand request, CancellationToken cancellationToken)
    {
        return _diagnosisRepository.DeleteDiagnosisInAppointmentAsync(request.AppointmentDiagnosisId);
    }
}