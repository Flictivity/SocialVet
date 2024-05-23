using LanguageExt.Common;
using MediatR;
using SoVet.Domain.Commands.Base;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Client;

public sealed record UpdateClientCommand (Models.Client Client, string Email, string? Password, string Role) : IRequest<Result<EntityResponse<Models.Client>>>, ITransactRequest;