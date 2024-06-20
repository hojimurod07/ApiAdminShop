using Application.Common.DTOs.OrderDetailDtos;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs.OrderDtos;

public class AddOrderDto
{
    [Required(ErrorMessage = "User ID is required.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "At least one order detail is required.")]
    public List<AddOrderDetailDto> OrderDetails { get; set; } = new List<AddOrderDetailDto>();
}
