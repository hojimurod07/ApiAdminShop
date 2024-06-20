using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs.CategoryDtos;

public class AddCategoryDto
{
    [Required(ErrorMessage = "Category name is required.")]
    [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255, ErrorMessage = "Category description cannot exceed 255 characters.")]
    public string? Description { get; set; }
}
