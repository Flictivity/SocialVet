using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Reference;

public sealed record GetAnimalTypeQuery : IRequest<List<AnimalType>>;