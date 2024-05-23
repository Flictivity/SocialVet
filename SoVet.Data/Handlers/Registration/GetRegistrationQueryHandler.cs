using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Registration;

namespace SoVet.Data.Handlers.Registration;

public sealed class GetRegistrationQueryHandler : IRequestHandler<GetRegistrationsQuery, List<Domain.Models.Registration>?>
{
    private readonly IRegistrationRepository _repository;

    public GetRegistrationQueryHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Models.Registration>?> Handle(GetRegistrationsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetRegistrations(request.EmployeeId, request.ClientId);
    }
}