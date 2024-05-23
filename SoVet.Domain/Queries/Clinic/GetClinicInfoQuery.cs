using MediatR;

namespace SoVet.Domain.Queries.Clinic;

public sealed record GetClinicInfoQuery : IRequest<Models.Clinic?>;