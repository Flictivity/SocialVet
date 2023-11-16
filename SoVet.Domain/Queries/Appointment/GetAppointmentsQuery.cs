using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Queries.Appointment;

public sealed record GetAppointmentsQuery(int PatientId) : IRequest<List<AppointmentTable>>;