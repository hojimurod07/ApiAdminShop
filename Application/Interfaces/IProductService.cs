using Application.Common.DTOs.ProductDtos;
using Application.Common.Extentions;
using Application.Common.Utils;

namespace Application.Interfaces
{
    public  interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync(PaginationParams @params);
        Task<ProductDto> GetByIdAsync(int id);
        Task CreateAsync(AddProductDto productDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(ProductDto productDto);

    }
}
