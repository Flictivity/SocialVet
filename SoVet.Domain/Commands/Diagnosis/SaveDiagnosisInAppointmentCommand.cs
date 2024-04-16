using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Diagnosis;

public record SaveDiagnosisInAppointmentCommand(Models.AppointmentDiagnoses AppointmentDiagnoses) : IRequest<BaseResponse>;