using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Facility;

public sealed record GetFacilityCategoriesQuery : IRequest<List<FacilityCategory>>;