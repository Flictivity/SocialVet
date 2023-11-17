using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Diagnosis;

namespace SoVet.Data.Handlers.Diagnosis;

public sealed class GetAppointmentDiagnosesQueryHandler : IRequestHandler<GetAppointmentDiagnosesQuery, List<Domain.Models.Diagnosis>>
{
    private readonly IDiagnosisRepository _repository;

    public GetAppointmentDiagnosesQueryHandler(IDiagnosisRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Domain.Models.Diagnosis>> Handle(GetAppointmentDiagnosesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetDiagnosesAsync(request.AppointmentId);
    }
}