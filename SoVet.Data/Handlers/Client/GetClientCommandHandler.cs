using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Client;

namespace SoVet.Data.Handlers.Client;

public sealed class GetClientCommandHandler : IRequestHandler<GetClientCommand, Domain.Models.Client?>
{
    private readonly IClientRepository _repository;

    public GetClientCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Models.Client?> Handle(GetClientCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetClientAsync(request.Users, request.Email);
    }
}