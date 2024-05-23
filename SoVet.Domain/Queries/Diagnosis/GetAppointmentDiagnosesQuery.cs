using MediatR;

namespace SoVet.Domain.Queries.Diagnosis;

public sealed record GetAppointmentDiagnosesQuery (int AppointmentId) : IRequest<List<Models.AppointmentDiagnoses>>;