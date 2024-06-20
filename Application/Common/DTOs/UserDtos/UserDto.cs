using Domain.Enums;

namespace Application.Common.DTOs.UserDtos;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string Address { get; set; } = string.Empty;
    public Role Role { get; set; } // Role bir ko'rish kerak
}
