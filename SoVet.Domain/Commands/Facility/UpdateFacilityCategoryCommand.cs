using MediatR;
using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Facility;

public sealed record UpdateFacilityCategoryCommand(FacilityCategory FacilityCategory) : IRequest<BaseResponse>;