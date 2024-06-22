using Application.Common.DTOs.OrderDetailDtos;
using Application.Common.DTOs.ProductDtos;
using Application.Common.Utils;

namespace Application.Interfaces
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetailDto>> GetAllAsync(PaginationParams @params);
        Task<OrderDetailDto> GetByIdAsync(int id);
        Task CreateAsync(AddOrderDetailDto addOrderDetailDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(OrderDetailDto orderDetailDto);
    }
}
