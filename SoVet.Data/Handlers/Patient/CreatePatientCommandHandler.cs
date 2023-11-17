using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Patient;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Patient;

public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, BaseResponse>
{
    private readonly IPatientRepository _repository;

    public CreatePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreatePatientAsync(request.Patient);
    }
}