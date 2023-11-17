using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Patient;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Patient;

public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, BaseResponse>
{
    private readonly IPatientRepository _repository;

    public UpdatePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdatePatientAsync(request.Patient);
    }
}