using Data.Entities;
using Domain.Enums;
using System.Data;
using System.Reflection;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public Role Role { get; set; } = Role.User;
    public string Adress { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = new List<Order>();
}