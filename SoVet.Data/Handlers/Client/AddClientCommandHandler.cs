using LanguageExt.Common;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Client;
using SoVet.Domain.Notifications;
    
namespace SoVet.Data.Handlers;

public sealed class AddClientCommandHandler : IRequestHandler<AddClientCommand, Result<Domain.Models.Client>>
{
    private readonly IPublisher _publisher;
    private readonly IClientRepository _repository;

    public AddClientCommandHandler(IPublisher publisher, IClientRepository repository)
    {
        _publisher = publisher;
        _repository = repository;
    }

    public async Task<Result<Domain.Models.Client>> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.AddClientAsync(request.Client); 
        var notification = new ClientCreatedNotification(teacher, request.Email, request.Password);
        await _publisher.Publish(notification, cancellationToken);

        return teacher;
    }
}