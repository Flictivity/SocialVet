using LanguageExt.Common;
using MediatR;
using SoVet.Domain.Commands.Registration;

namespace SoVet.WebAPI;

public class TimedHostedService : BackgroundService
{
    private int executionCount = 0;
    private readonly ILogger<TimedHostedService> _logger;
    private readonly IServiceProvider _services;
    private Timer? _timer = null;

    public TimedHostedService(ILogger<TimedHostedService> logger, IServiceProvider services)
    {
        _logger = logger;
        _services = services;
    }
    

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _timer = new Timer(SendEmail, null, TimeSpan.Zero,
                    TimeSpan.FromDays(1));
                    
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:{0}",ex.Message);
            }
        }

        return Task.CompletedTask;
    }

    private async void SendEmail(object? state)
    {
        using var scope = _services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        
        var command = new SendMailCommand();
        await mediator.Send(command);
    }
}