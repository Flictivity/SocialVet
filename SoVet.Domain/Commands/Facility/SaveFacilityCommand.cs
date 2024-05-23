using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Facility;

public sealed record SaveFacilityCommand(Models.AppointmentFacility Facility) : IRequest<BaseResponse>;