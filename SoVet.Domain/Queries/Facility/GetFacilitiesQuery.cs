using MediatR;

namespace SoVet.Domain.Queries.Facility;

public sealed record GetFacilitiesQuery : IRequest<List<Models.Facility>>;