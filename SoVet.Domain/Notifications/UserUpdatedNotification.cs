using MediatR;
using SoVet.Domain.Models;
using Client = LanguageExt.Pipes.Client;

namespace SoVet.Domain.Notifications;

public sealed record UserUpdatedNotification(Client? Client, Employee? Employee, string Email, string NewEmail,
    string? Password, string Role) : INotification;