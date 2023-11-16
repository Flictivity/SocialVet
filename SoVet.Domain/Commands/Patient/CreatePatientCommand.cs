using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Patient;

public sealed record CreatePatientCommand(Models.Patient Patient) : IRequest<BaseResponse>;