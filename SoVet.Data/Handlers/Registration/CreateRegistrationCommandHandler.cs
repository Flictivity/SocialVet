using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Registration;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Registration;

public sealed class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, BaseResponse>
{
    private readonly IRegistrationRepository _repository;

    public CreateRegistrationCommandHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateRegistration(request.Registration);
    }
}