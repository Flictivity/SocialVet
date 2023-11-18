using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Employee;

namespace SoVet.Data.Handlers.Employee;

public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Domain.Models.EmployeeUser?>
{
    private readonly IEmployeeRepository _repository;
    private readonly ISender _sender;

    public GetEmployeeQueryHandler(IEmployeeRepository repository, ISender sender)
    {
        _repository = repository;
        _sender = sender;
    }

    public async Task<Domain.Models.EmployeeUser?> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var command = new GetEmployeesUserQuery();
        var commandResult = await _sender.Send(command, cancellationToken);
        return await _repository.GetEmployee(commandResult, request.Email);
    }
}