using System.Security.Cryptography;
using LanguageExt.Common;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Employee;
using SoVet.Domain.Notifications;
using SoVet.Domain.Responses;
using SoVet.Domain.Services;

namespace SoVet.Data.Handlers.Employee;

public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<EntityResponse<Domain.Models.Employee>>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IPublisher _publisher;
    private readonly IEmailService _emailService;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IPublisher publisher, IEmailService emailService)
    {
        _repository = repository;
        _publisher = publisher;
        _emailService = emailService;
    }

    public async Task<Result<EntityResponse<Domain.Models.Employee>>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var password = new string(Enumerable.Repeat(chars.Concat(chars.ToLower()).ToArray(), 12)
            .Select(s => s[RandomNumberGenerator.GetInt32(s.Length)]).ToArray());
        // var password = "12345";
        var employee = await _repository.CreateEmployee(request.Employee);
        var notification = new UserCreatedNotification(Client:null, Employee:employee, request.Email, password,request.Role);
        await _publisher.Publish(notification, cancellationToken);
        var emailSendResult =  await _emailService.SendEmailAsync(request.Email, "Пароль для входа", $"Ваш пароль для входа в систему - {password}");
        
        return emailSendResult.IsSuccess ? new EntityResponse<Domain.Models.Employee>{Entity = employee, IsSuccess = true} 
            : new EntityResponse<Domain.Models.Employee>{Entity = employee, IsSuccess = false,Message = emailSendResult.Message};
    }
}