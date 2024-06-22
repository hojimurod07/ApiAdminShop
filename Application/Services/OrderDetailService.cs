using Application.Common.DTOs.OrderDetailDtos;
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
    public class OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper) : IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public  async Task CreateAsync(AddOrderDetailDto addOrderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(addOrderDetailDto);
            await _unitOfWork.OrderDetal.CreateAsync(orderDetail);
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetail = await _unitOfWork.OrderDetal.GetByIdAsync(id);
            if (orderDetail == null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "orderDetail not found");
            }
            await _unitOfWork.OrderDetal.DeleteAsync(orderDetail);
        }

        public async Task<List<OrderDetailDto>> GetAllAsync(PaginationParams @params)
        {
            var orderDetails = await _unitOfWork.OrderDetal.GetAllAsync().ToPagedListAsync(@params);
            return orderDetails.Select(p => _mapper.Map<OrderDetailDto>(p)).ToList();
        }

        public async Task<OrderDetailDto> GetByIdAsync(int id)
        {
            var orderDetail = await _unitOfWork.OrderDetal.GetByIdAsync(id);
            if (orderDetail is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "orderDetail not found");
            return _mapper.Map<OrderDetailDto>(orderDetail);
        }

        public async Task UpdateAsync(OrderDetailDto orderDetailDto)
        {
         var orderDetail = await _unitOfWork.OrderDetal.GetByIdAsync(orderDetailDto.Id);
            if (orderDetail is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "OrderDetail Not Found");
            orderDetail.Quantity = orderDetailDto.Quantity;
            orderDetail.OrderId = orderDetailDto.OrderId;
            orderDetail.Amount = orderDetailDto.Amount;
            orderDetailDto.OrderId = orderDetailDto.OrderId;
            await _unitOfWork.OrderDetal.UpdateAsync(orderDetail);
        }
    }
}
