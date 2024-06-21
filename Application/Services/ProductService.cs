using Application.Common.DTOs.ProductDtos;
using Application.Common.Utils;
using Application.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(AddProductDto productDto)
        {
            var employee = _mapper.Map<Product>(productDto);
            await _unitOfWork.Product.CreateAsync(employee);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
