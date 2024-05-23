using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Diagnosis;

public sealed record DeleteDiagnosisCommand(int DiagnosisId) : IRequest<BaseResponse>;
