using MediatR;
using LanguageExt.Common;
using SoVet.Domain.Commands.Base;

namespace SoVet.Domain.Commands.Client;

public sealed record AddClientCommand (Models.Client Client, string Email, string Password) : IRequest<Result<Models.Client>>, ITransactRequest;