namespace SoVet.Domain.ErrorMessages;

public static class UserErrorMessages
{
    public const string UserExists = "Пользователь с таким адресом почты уже существует";
    public const string UserNotFound = "Не удалось найти пользователя с таким адресом почты";
    public const string UserWrongPassword = "Неверный пароль";
}