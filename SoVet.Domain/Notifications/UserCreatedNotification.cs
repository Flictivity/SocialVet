using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Notifications;

public sealed record UserCreatedNotification(Client? Client, Employee? Employee, string Email, string Password, string? Role) : INotification;