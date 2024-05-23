using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SoVet.Auth.Models;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Exceptions;
using SoVet.Domain.Models;
using SoVet.Domain.Notifications;

namespace SoVet.Auth.Handlers;

internal sealed class UserCreatedNotificationHandler : INotificationHandler<UserCreatedNotification>
{
    private readonly UserManager<ClinicUser> _userManager;
    private readonly IdentityContext _context;

    public UserCreatedNotificationHandler(UserManager<ClinicUser> userManager, IdentityContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            if (await _userManager.FindByEmailAsync(notification.Email) is not null)
            {
                throw new UserCreationException(UserErrorMessages.UserExists);
            }

            var user = new ClinicUser { Email = notification.Email, UserName = notification.Email };

            var res = await _userManager.CreateAsync(user);
            if (!res.Succeeded)
            {
                throw new UserCreationException($"Could not create a user: {string.Join("; ", res.Errors.Select(x => $"{x.Code} - {x.Description}"))}");
            }

            await _userManager.AddToRoleAsync(user, notification.Role ?? Role.Client);
            if (notification.Client is null && notification.Employee is not null)
            {
                await _userManager.AddClaimAsync(user, new Claim(UserClaims.EmployeeId, notification.Employee.Id.ToString()));
            }
            else if (notification.Client is not null && notification.Employee is null)
            {
                await _userManager.AddClaimAsync(user, new Claim(UserClaims.ClientId, notification.Client.Id.ToString()));
            }
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