using LanguageExt.Common;
using MediatR;
using SoVet.Domain.Commands.Base;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Employee;

public sealed record UpdateEmployeeCommand (Models.Employee Employee, string Email, string NewEmail,
    string Role, string? Password) : IRequest<Result<EntityResponse<Models.Employee>>>, ITransactRequest;
