using System.Reflection;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using SoVet.Domain.Services;
using SoVet.Domain.Services.Impl;

namespace SoVet.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IEncryptionService, EncryptionService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
        });
        return services;
    }
}