using MediatR;
using Microsoft.AspNetCore.Identity;
using SoVet.Auth.Models;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Exceptions;
using SoVet.Domain.Notifications;

namespace SoVet.Auth.Handlers;

public sealed class UserUpdatedNotificationHandler : INotificationHandler<UserUpdatedNotification>
{
    private readonly UserManager<ClinicUser> _userManager;
    private readonly IdentityContext _context;

    public UserUpdatedNotificationHandler(UserManager<ClinicUser> userManager, IdentityContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task Handle(UserUpdatedNotification notification, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var user = await _userManager.FindByEmailAsync(notification.Email);
            if (user is null)
            {
                throw new UserCreationException(UserErrorMessages.UserNotFound);
            }
            if (user.Email != notification.NewEmail 
                && await _userManager.FindByEmailAsync(notification.NewEmail) is not null)
            {
                throw new UserCreationException(UserErrorMessages.UserExists);
            }

            user.Email = notification.NewEmail;
            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded)
            {
                throw new UserCreationException($"Could not create a user: {string.Join("; ", res.Errors.Select(x => $"{x.Code} - {x.Description}"))}");
            }

            var oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (oldRole is null)
            {
                throw new UserCreationException("Роль пользователя не найдена");
            }
            await _userManager.RemoveFromRoleAsync(user, oldRole);
            await _userManager.AddToRoleAsync(user, notification.Role);
            if (notification.Password is not null)
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, notification.Password);
            }
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}