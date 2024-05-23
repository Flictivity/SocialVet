using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Facility;

public sealed record DeleteFacilityCommand(int AppointmentFacilityId) : IRequest<BaseResponse>;