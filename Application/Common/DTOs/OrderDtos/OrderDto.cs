using Application.Common.DTOs.OrderDetailDtos;

namespace Application.Common.DTOs.OrderDtos;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty; // korishga 
    public double TotalAmount { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
}
