using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Diagnosis;

namespace SoVet.Data.Handlers.Diagnosis;

public sealed class GetDiagnosesQueryHandler : IRequestHandler<GetDiagnosesQuery, List<Domain.Models.Diagnosis>>
{
    private readonly IDiagnosisRepository _diagnosisRepository;

    public GetDiagnosesQueryHandler(IDiagnosisRepository diagnosisRepository)
    {
        _diagnosisRepository = diagnosisRepository;
    }

    public Task<List<Domain.Models.Diagnosis>> Handle(GetDiagnosesQuery request, CancellationToken cancellationToken)
    {
        return _diagnosisRepository.GetDiagnosesAsync();
    }
}