using LanguageExt.Common;
using MediatR;

namespace SoVet.Domain.Commands.Clinic;

public sealed record GetClinicInfoCommand : IRequest<Models.Clinic?>;