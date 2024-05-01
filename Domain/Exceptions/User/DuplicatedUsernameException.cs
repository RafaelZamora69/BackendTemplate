namespace Domain.Exceptions.User;

public class DuplicatedUsernameException(string userName) : 
    Exception($"El usuario {userName} ya se encuentra registrado.");