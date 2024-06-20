namespace Application.Common.DTOs.ProductDtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;  // ko'rishga
    public string? ImageUrl { get; set; }  // rasm keladi
}
