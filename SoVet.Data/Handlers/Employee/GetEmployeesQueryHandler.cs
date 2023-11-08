using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Employee;

namespace SoVet.Data.Handlers.Employee;

public sealed class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<Domain.Models.Employee>>
{
    private readonly IEmployeeRepository _repository;
    private readonly ISender _sender;

    public GetEmployeesQueryHandler(IEmployeeRepository repository, ISender sender)
    {
        _repository = repository;
        _sender = sender;
    }

    public async Task<List<Domain.Models.Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var command = new GetEmployeesUserQuery(request.RoleName, request.ClaimType);
        var commandResult = await _sender.Send(command, cancellationToken);
        return await _repository.GetEmployeesByIds(commandResult.ToArray());
    }
}