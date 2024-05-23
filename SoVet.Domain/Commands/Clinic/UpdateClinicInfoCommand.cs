using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Clinic;

public sealed record UpdateClinicInfoCommand(Models.Clinic Clinic) : IRequest<BaseResponse>
{
}