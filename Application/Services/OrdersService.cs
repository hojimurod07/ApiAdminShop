using Application.Common.DTOs.OrderDtos;
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
    public class OrdersService(IUnitOfWork unitOfWork, IMapper mapper) : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

   
        public async Task CreateAsync(AddOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _unitOfWork.Order.CreateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(id);
            if (order == null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "Order not found");
            }
            await _unitOfWork.Order.DeleteAsync(order);
        }

        public async Task<List<OrderDto>> GetAllAsync(PaginationParams @params)
        {
            var orders = await _unitOfWork.Order.GetAllAsync().ToPagedListAsync(@params);
            return orders.Select(p => _mapper.Map<OrderDto>(p)).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(id);
            if (order is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "order not found");
            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateAsync(OrderDto orderDto)
        {
            var order = await _unitOfWork.Order.GetByIdAsync(orderDto.Id);
            if (order is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Order Not Found");

            order.OrderDate = DateOnly.FromDateTime(orderDto.OrderDate);

            await _unitOfWork.Order.UpdateAsync(order);
        }
    }
}
