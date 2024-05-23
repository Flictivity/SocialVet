using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Queries.Client;

namespace SoVet.Data.Handlers.Client;

public sealed class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<Domain.Models.Client>>
{
    private readonly IClientRepository _repository;

    public GetClientsQueryHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Models.Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetClientsAsync(request.Users);
    }
}