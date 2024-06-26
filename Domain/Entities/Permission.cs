﻿namespace Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Role> Roles { get; } = new List<Role>();
}