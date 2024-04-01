using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Registration;

public sealed record DeleteRegistrationCommand(int RegistrationId) : IRequest<BaseResponse>;