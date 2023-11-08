using System.Reflection;
using Dapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoVet.Data.PipelineBehaviors;
using SoVet.Data.Repositories;
using SoVet.Data.Repositories.Impl;
using SoVet.Domain.Commands.Client;

namespace SoVet.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        if (connectionString is null)
            throw new Exception("No database connection string");

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(connectionString,
                    npgsqlOptions =>
                    {
                        npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
                .UseSnakeCaseNamingConvention();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            options
                .AddBehavior<IPipelineBehavior<AddClientCommand, Result<Domain.Models.Client>>,
                    TransactPipelineBehavior<AddClientCommand, Domain.Models.Client>>();
        });

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClinicRepository, ClinicRepository>();
        services.AddScoped<IRegistrationRepository, RegistrationRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        SqlMapper.AddTypeHandler(new DapperSqlDateOnlyTypeHandler());

        return services;
    }
}