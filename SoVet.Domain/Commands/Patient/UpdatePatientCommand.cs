using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Patient;

public sealed record UpdatePatientCommand (Models.Patient Patient) : IRequest<BaseResponse>;