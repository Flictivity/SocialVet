using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Appointment;

public sealed record SaveAppointmentCommand(Models.Appointment Appointment) : IRequest<BaseResponse>;