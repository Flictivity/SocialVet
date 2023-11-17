using MediatR;

namespace SoVet.Domain.Queries.Patient;

public sealed record GetPatientQuery (int PatientId) : IRequest<Models.Patient?>;