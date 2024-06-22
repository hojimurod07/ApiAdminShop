using Application.Common.DTOs.CategoryDtos;
using Application.Common.DTOs.ProductDtos;
using Application.Common.Utils;

namespace Application.Interfaces
{
    public  interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync(PaginationParams @params);
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(AddCategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(CategoryDto categoryDto);
    }
}
