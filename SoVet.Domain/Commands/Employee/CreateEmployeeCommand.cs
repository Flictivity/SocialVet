using LanguageExt.Common;
using MediatR;
using SoVet.Domain.Commands.Base;
using SoVet.Domain.Responses;

namespace SoVet.Domain.Commands.Employee;

public sealed record CreateEmployeeCommand (Models.Employee Employee, string Email, string Role) : IRequest<Result<EntityResponse<Models.Employee>>>, ITransactRequest;