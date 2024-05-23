using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Clinic;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Clinic;

public sealed class UpdateClinicInfoCommandHandler : IRequestHandler<UpdateClinicInfoCommand, BaseResponse>
{
    private readonly IClinicRepository _repository;

    public UpdateClinicInfoCommandHandler(IClinicRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(UpdateClinicInfoCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateClinicInfo(request.Clinic);
    }
}