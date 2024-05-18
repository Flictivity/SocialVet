using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Report;
using SoVet.Domain.Models;

namespace SoVet.Data.Handlers.Report;

public class GetEmployeeReportCommandHandler : IRequestHandler<GetEmployeeReportCommand, List<EmployeeReport>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeReportCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeReport>> Handle(GetEmployeeReportCommand request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetReport(request.Start, request.End);
    }
}