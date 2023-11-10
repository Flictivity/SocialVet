using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Patient;

namespace SoVet.Data.Handlers.Patient;

public sealed class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<Domain.Models.Patient>>
{
    private readonly IPatientRepository _repository;

    public GetPatientsQueryHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Domain.Models.Patient>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetPatients(request.ClientId);
    }
}