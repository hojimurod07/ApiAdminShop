﻿namespace Application.Common.DTOs.CategoryDtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    // public int ProductCount { get; set; }  // Kerak bo'lib qolishligi mumkin
}