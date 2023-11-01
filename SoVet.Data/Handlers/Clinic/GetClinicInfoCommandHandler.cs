using LanguageExt.Common;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Clinic;

namespace SoVet.Data.Handlers.Clinic;

public sealed class GetClinicInfoCommandHandler : IRequestHandler<GetClinicInfoCommand, Domain.Models.Clinic?>
{
    private readonly IClinicRepository _repository;

    public GetClinicInfoCommandHandler(IClinicRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Models.Clinic?> Handle(GetClinicInfoCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetClinicInfo();
    }
}