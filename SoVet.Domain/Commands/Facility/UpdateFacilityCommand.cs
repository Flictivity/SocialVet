using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Facility;

public sealed record UpdateFacilityCommand(Models.Facility Facility) : IRequest<BaseResponse>;