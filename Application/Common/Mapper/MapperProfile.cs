using Application.Common.DTOs.CategoryDtos;
using Application.Common.DTOs.OrderDetailDtos;
using Application.Common.DTOs.OrderDtos;
using Application.Common.DTOs.ProductDtos;
using Application.Common.DTOs.UserDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // User 
        CreateMap<AddUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UserDto>();

        // Product 
        CreateMap<AddProductDto, Product>();
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        // Category 
        CreateMap<AddCategoryDto, Category>();
        CreateMap<Category, CategoryDto>();

        // Order 
        CreateMap<AddOrderDto, Order>();
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));

        // Order Detail 
        CreateMap<AddOrderDetailDto, OrderDetail>();
        CreateMap<OrderDetail, OrderDetailDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));
    }
}
