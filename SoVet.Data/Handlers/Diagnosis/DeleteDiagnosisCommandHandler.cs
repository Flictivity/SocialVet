using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Diagnosis;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Diagnosis;

public sealed class DeleteDiagnosisCommandHandler : IRequestHandler<DeleteDiagnosisCommand,BaseResponse>
{
    private readonly IDiagnosisRepository _repository;

    public DeleteDiagnosisCommandHandler(IDiagnosisRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(DeleteDiagnosisCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteDiagnosisAsync(request.DiagnosisId);
    }
}