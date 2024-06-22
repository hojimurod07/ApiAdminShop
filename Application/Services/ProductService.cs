using Application.Common.DTOs.ProductDtos;
using Application.Common.Exceptions;
using Application.Common.Extentions;
using Application.Common.Helpers;
using Application.Common.Utils;
using Application.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(AddProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.Product.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound,"Product not found");
            }
            await _unitOfWork.Product.DeleteAsync(product);
        }

        public async Task<List<ProductDto>> GetAllAsync(PaginationParams @params)
        {
            var products = await _unitOfWork.Product.GetAllAsync().ToPagedListAsync(@params);
            return products.Select(p=>_mapper.Map<ProductDto>(p)).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var produc = await _unitOfWork.Product.GetByIdAsync(id);
            if (produc is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Product not found");
            return _mapper.Map<ProductDto>(produc);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(productDto.Id);
            if (product is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Product Not Found");
            product.Status = product.Status;
            product.Quantity = productDto.Quantity;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.Name = productDto.Name;
            await _unitOfWork.Product.UpdateAsync(product);
        }
    }
}
