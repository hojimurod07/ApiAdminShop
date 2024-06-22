using Application.Common.DTOs.OrderDtos;
using Application.Common.DTOs.ProductDtos;
using Application.Common.Utils;

namespace Application.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrderDto>> GetAllAsync(PaginationParams @params);
        Task<OrderDto> GetByIdAsync(int id);
        Task CreateAsync(AddOrderDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(OrderDto orderDto);
    }
}
