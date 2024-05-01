namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Surnames { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
}