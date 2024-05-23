using MediatR;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Registration;

public sealed record SendMailCommand : IRequest<BaseResponse>;
