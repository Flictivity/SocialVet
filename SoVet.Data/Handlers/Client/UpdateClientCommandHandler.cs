using LanguageExt.Common;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Client;
using SoVet.Domain.Notifications;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Client;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand,Result<EntityResponse<Domain.Models.Client>>>
{
    private readonly IClientRepository _repository;
    private readonly IPublisher _publisher;

    public UpdateClientCommandHandler(IClientRepository repository, IPublisher publisher)
    {
        _repository = repository;
        _publisher = publisher;
    }

    public async Task<Result<EntityResponse<Domain.Models.Client>>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _repository.UpdateClientAsync(request.Client);
        if (request.Client.Email == null)
            return new EntityResponse<Domain.Models.Client> { Entity = client, IsSuccess = true };
        
        var notification = new UserUpdatedNotification(Client:client, Employee:null, request.Email, request.Client.Email,
            request.Password,request.Role);
        await _publisher.Publish(notification, cancellationToken);

        return new EntityResponse<Domain.Models.Client>{Entity = client, IsSuccess = true};
    }
}