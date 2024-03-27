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

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody =
            $"<head><style>*{{box-sizing: border-box;}}body {{margin: 0;font-family: Arial, Helvetica, sans-serif;}}" +
            $".wrapper {{display: block; margin: 0 auto;text-align: center;}}.image-container {{text-align: center;margin: 0;}}" +
            $"img {{max-width: 100%;height: auto;display: block;margin: 0 auto;}}h1 {{font-size: 36px;margin-bottom: 20px;}}" +
            $"p {{line-height: 24px;color: #000000; margin: 0;}} #pp {{font-size: 14px;color: #777;margin-top:20px;}}</style>\n</head>\n<body>\n" +
            $"<img src=\"https://i.postimg.cc/9Q7FhNYJ/logo.png\" alt=\"Лого\">" +
            $"<div class=\"wrapper\">\n<h1>{subject}</h1><p>{message}</p><p id=\"pp\">" +
            $"Если вы не имеете связи с данным письмом, просим проигнорировать его.</p></div></body>";

        sendMessage.Body = bodyBuilder.ToMessageBody();

        SmtpClient client = new SmtpClient();

        try
        {
            await client.ConnectAsync("smpt.mail.ru", 465, true);
            await client.AuthenticateAsync("computerservlse@mail.ru", _mailPassword);
            await client.SendAsync(sendMessage);
            _logger.LogInformation("Email succesfully sended");
            return new BaseResponse { IsSuccess = true };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResponse { IsSuccess = false, Message = "Не удалось отправить письмо" };
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
            Semaphore.Release();
        }
    }
}