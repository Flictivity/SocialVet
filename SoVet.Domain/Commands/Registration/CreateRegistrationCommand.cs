using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Registration;

public sealed record CreateRegistrationCommand(Models.Registration Registration) : IRequest<BaseResponse>; 
