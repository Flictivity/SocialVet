using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Registration;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Registration;

public sealed class DeleteRegistrationCommandHandler : IRequestHandler<DeleteRegistrationCommand, BaseResponse>
{
    private readonly IRegistrationRepository _registrationRepository;

    public DeleteRegistrationCommandHandler(IRegistrationRepository registrationRepository)
    {
        _registrationRepository = registrationRepository;
    }

    public async Task<BaseResponse> Handle(DeleteRegistrationCommand request, CancellationToken cancellationToken)
    {
        var result = await _registrationRepository.DeleteRegistration(request.RegistrationId);
        return result;
    }
}