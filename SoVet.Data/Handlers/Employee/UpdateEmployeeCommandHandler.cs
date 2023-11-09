using LanguageExt.Common;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Employee;
using SoVet.Domain.Notifications;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Employee;

public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<EntityResponse<Domain.Models.Employee>>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IPublisher _publisher;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IPublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<Result<EntityResponse<Domain.Models.Employee>>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.UpdateEmployee(request.Employee);
        var notification = new UserUpdatedNotification(Client:null, Employee:employee, request.Email, request.NewEmail,
            request.Password ,request.Role);
        await _publisher.Publish(notification, cancellationToken);

        return new EntityResponse<Domain.Models.Employee>{Entity = employee, IsSuccess = true};
    }
}