namespace SoVet.Domain.Exceptions;

public class UserCreationException : InformationException
{
    public UserCreationException(string? message) : base(message)
    {
    }
}