using MediatR;
using SoVet.Domain.Queries.Employee;

namespace SoVet.Data.Handlers.Employee;

public sealed class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<Domain.Models.Employee>>
{
    public Task<List<Domain.Models.Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}