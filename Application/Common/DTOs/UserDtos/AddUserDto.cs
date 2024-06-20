using Application.Common.Attributes;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs.UserDtos;

public class AddUserDto
{
    [Required(ErrorMessage = "Full name is required.")]
    [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [Password(ErrorMessage = "Password must meet complexity requirements.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Gender is required.")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
    public string Address { get; set; } = string.Empty;
}
