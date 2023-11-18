using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Facility;

public sealed record GetFacilitiesInAppointmentQuery(int AppointmentId) : IRequest<List<AppointmentFacility>>;