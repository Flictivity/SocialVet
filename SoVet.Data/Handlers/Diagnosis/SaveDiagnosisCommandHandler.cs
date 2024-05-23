using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Diagnosis;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Diagnosis;

public sealed class SaveDiagnosisCommandHandler : IRequestHandler<SaveDiagnosisCommand,BaseResponse>
{
    private readonly IDiagnosisRepository _repository;

    public SaveDiagnosisCommandHandler(IDiagnosisRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(SaveDiagnosisCommand request, CancellationToken cancellationToken)
    {
        return await _repository.SaveDiagnosisAsync(request.Diagnosis);
    }
}