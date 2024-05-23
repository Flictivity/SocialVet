using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Diagnosis;

public record DeleteDiagnosisInAppointmentCommand(int AppointmentDiagnosisId) : IRequest<BaseResponse>;