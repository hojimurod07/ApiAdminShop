using Application.Common.DTOs.CategoryDtos;
using Application.Common.DTOs.ProductDtos;
using Application.Common.Exceptions;
using Application.Common.Extentions;
using Application.Common.Utils;
using Application.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services
{
    public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(AddCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Category.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(id);
            if (category == null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found");
            }
            await _unitOfWork.Category.DeleteAsync(category);
        }

        public async Task<List<CategoryDto>> GetAllAsync(PaginationParams @params)
        {
            var categories = await _unitOfWork.Category.GetAllAsync().ToPagedListAsync(@params);
            return categories.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
        }

        public async  Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(id);
            if (category is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found");
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(categoryDto.Id);
            if (category is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Category Not Found");
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            await _unitOfWork.Category.UpdateAsync(category);
        }
    }
}
