using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Clinic;

namespace SoVet.Data.Handlers.Clinic;

public sealed class GetClinicInfoQueryHandler : IRequestHandler<GetClinicInfoQuery, Domain.Models.Clinic?>
{
    private readonly IClinicRepository _repository;

    public GetClinicInfoQueryHandler(IClinicRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Models.Clinic?> Handle(GetClinicInfoQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetClinicInfo();
    }
}