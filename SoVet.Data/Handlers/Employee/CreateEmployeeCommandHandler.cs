using System.Security.Cryptography;
using LanguageExt.Common;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Employee;
using SoVet.Domain.Notifications;

namespace SoVet.Data.Handlers.Employee;

public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Domain.Models.Employee>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IPublisher _publisher;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IPublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<Result<Domain.Models.Employee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        // var password = new string(Enumerable.Repeat(chars.Concat(chars.ToLower()).ToArray(), 12)
            // .Select(s => s[RandomNumberGenerator.GetInt32(s.Length)]).ToArray());
        var password = "12345";
        var employee = await _repository.CreateEmployee(request.Employee);
        var notification = new UserCreatedNotification(Client:null, Employee:employee, request.Email, password,request.Role);
        await _publisher.Publish(notification, cancellationToken);

        return employee;
    }
}