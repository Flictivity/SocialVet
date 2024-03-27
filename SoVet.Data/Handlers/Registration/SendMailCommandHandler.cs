using System.Security.Claims;
using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Registration;
using SoVet.Domain.Models;
using SoVet.Domain.Queries;
using SoVet.Domain.Responses;
using SoVet.Domain.Services;

namespace SoVet.Data.Handlers.Registration;

public sealed class SendMailCommandHandler : IRequestHandler<SendMailCommand, BaseResponse>
{
    private readonly IEmailService _emailService;
    private readonly IRegistrationRepository _registrationRepository;
    private readonly ApplicationContext _context;
    private readonly ISender _sender;

    public SendMailCommandHandler(IEmailService emailService, IRegistrationRepository registrationRepository, ApplicationContext context, ISender sender)
    {
        _emailService = emailService;
        _registrationRepository = registrationRepository;
        _context = context;
        _sender = sender;
    }

    public async Task<BaseResponse> Handle(SendMailCommand request, CancellationToken cancellationToken)
    {
        var registrations = await _registrationRepository.GetRegistrations(null);

        var newRegistrations = registrations.Where(x => x.StartTime > DateTime.Now);

        foreach (var registration in newRegistrations)
        {
            var getEmailQuery = new GetUserEmailQuery(registration.ClientId, UserClaims.ClientId);
            var email = await _sender.Send(getEmailQuery, cancellationToken);
            var client = _context.Clients.FirstOrDefault( x=> x.Id == registration.ClientId);
            
            if(client is null)
                continue;
            
            return await _emailService.SendEmailAsync(email, "Запись на прием", $"Здравствуйте, {client.Name}! " +
                $"Хотим сообщить вам, что у вас присутсвует запись на {registration.StartTime}. Ждем вас в нашей клинике!");
        }

        return new BaseResponse { IsSuccess = true };
    }
}