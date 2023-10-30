using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SoVet.Auth.Models;
using SoVet.Domain.Exceptions;
using SoVet.Domain.Notifications;

namespace SoVet.Auth.Handlers;

internal sealed class ClientCreatedNotificationHandler : INotificationHandler<ClientCreatedNotification>
{
    private readonly UserManager<ClinicUser> _userManager;
    private readonly IdentityContext _context;

    public ClientCreatedNotificationHandler(UserManager<ClinicUser> userManager, IdentityContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task Handle(ClientCreatedNotification notification, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            if (await _userManager.FindByEmailAsync(notification.Email) is not null)
            {
                throw new UserCreationException("User with this email already exists");
            }

            var user = new ClinicUser { Email = notification.Email, UserName = notification.Email };

            var res = await _userManager.CreateAsync(user);
            if (!res.Succeeded)
            {
                throw new UserCreationException($"Could not create a user: {string.Join("; ", res.Errors.Select(x => $"{x.Code} - {x.Description}"))}");
            }

            await _userManager.AddToRoleAsync(user, Role.Client);
            await _userManager.AddClaimAsync(user, new Claim(UserClaims.ClientId, notification.Client.Id.ToString()));
            await _userManager.AddPasswordAsync(user, notification.Password);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}