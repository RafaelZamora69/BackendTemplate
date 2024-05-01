namespace Domain.Exceptions.Permission;

public class PermissionNotFoundException(int id) : Exception("Este permiso no existe {id}");