using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Diagnosis;

public sealed record SaveDiagnosisCommand(Models.Diagnosis Diagnosis) : IRequest<BaseResponse>;