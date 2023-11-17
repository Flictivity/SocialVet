using System.Net.Mail;
using Microsoft.Extensions.Logging;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using SoVet.Domain.Responses;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SoVet.Domain.Services.Impl;

public sealed class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private static readonly SemaphoreSlim Semaphore = new(1, 1);
    private readonly string? _mailPassword;

    public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _mailPassword = configuration.GetValue<string>("MailSettings:Password");
    }

    public async Task<BaseResponse> SendEmailAsync(string? email, string subject, string message)
    {
        await Semaphore.WaitAsync();
        var sendMessage = new MimeMessage();
        sendMessage.From.Add(new MailboxAddress("Ветеринарная клиника", "computerservlse@mail.ru"));
        sendMessage.To.Add(MailboxAddress.Parse(email));
        sendMessage.Subject = subject;
        sendMessage.Body = new TextPart("plain")
        {
            Text = message
        };

        SmtpClient client = new SmtpClient();

        try
        {
            await client.ConnectAsync("smpt.mail.ru", 465, true);
            await client.AuthenticateAsync("computerservlse@mail.ru",_mailPassword);
            await client.SendAsync(sendMessage);
            _logger.LogInformation("Письмо успешно отправлено");
            return new BaseResponse{IsSuccess = true};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResponse{IsSuccess = false, Message = "Не удалось отправить письмо"};
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
            Semaphore.Release();
        }
    }
}