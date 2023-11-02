using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Registration;

namespace SoVet.Data.Handlers.Registration;

public sealed class GetAvailableRegistrationTimesQueryHandler : IRequestHandler<GetAvailableRegistrationTimesQuery, List<TimeSpan>?>
{
    private readonly IRegistrationRepository _repository;

    public GetAvailableRegistrationTimesQueryHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    public Task<List<TimeSpan>?> Handle(GetAvailableRegistrationTimesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetTimes(request.EmployeeId, request.RegistrationDate);
    }
}