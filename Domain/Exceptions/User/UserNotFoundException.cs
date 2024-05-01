namespace Domain.Exceptions.User;

public class UserNotFoundException(string userName)
    : Exception($"No se ha encontrado el usuario: {userName}");