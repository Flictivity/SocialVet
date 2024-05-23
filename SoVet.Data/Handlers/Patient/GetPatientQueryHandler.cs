using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Patient;

namespace SoVet.Data.Handlers.Patient;

public sealed class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, Domain.Models.Patient?>
{
    private readonly IPatientRepository _repository;

    public GetPatientQueryHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Models.Patient?> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetPatientAsync(request.PatientId);
    }
}