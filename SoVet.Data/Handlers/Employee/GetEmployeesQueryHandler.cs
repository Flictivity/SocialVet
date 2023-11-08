using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Employee;

namespace SoVet.Data.Handlers.Employee;

public sealed class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeUser>>
{
    private readonly IEmployeeRepository _repository;
    private readonly ISender _sender;

    public GetEmployeesQueryHandler(IEmployeeRepository repository, ISender sender)
    {
        _repository = repository;
        _sender = sender;
    }

    public async Task<List<EmployeeUser>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var command = new GetEmployeesUserQuery();
        var commandResult = await _sender.Send(command, cancellationToken);
        return await _repository.GetEmployees(commandResult);
    }
}