using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs.UserDtos;

public class UpdateUserDto
{
    [Required(ErrorMessage = "User ID is required for updates.")]
    public int Id { get; set; } // idsini qanday olamiza lekin helpers da jwtdan id olib beruvchi metod bor 

    [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
    public string? FullName { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string? Email { get; set; }

    [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
    public string? Address { get; set; }

    public Gender? Gender { get; set; } // nma qilamiz 
}
