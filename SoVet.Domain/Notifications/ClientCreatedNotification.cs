using MediatR;
using SoVet.Domain.Models;

namespace SoVet.Domain.Notifications;

public sealed record ClientCreatedNotification(Client Client, string Email, string Password) : INotification;