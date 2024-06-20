namespace Application.Common.DTOs.OrderDetailDtos;

public class OrderDetailDto
{
    public int Id { get; set; }
    public int OrderId { get; set; } // kerak bo'ladimi
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; } // 1 ta narx
    public double Amount { get; set; } // Hisoblangan: Narx * Miqdor
}
