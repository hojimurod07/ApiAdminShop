using Application.Common.DTOs.UserDtos;
using Application.Common.Exceptions;
using Application.Common.Extentions;
using Application.Common.Utils;
using Application.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;

namespace Application.Services
{
    public class UserService(IUnitOfWork unitOf,IMapper mapper,IHttpContextAccessor accessor) : IUserService
    {
        private readonly IUnitOfWork _unitOf = unitOf;
        private readonly IMapper _mapper = mapper;
        private readonly IHttpContextAccessor _accessor = accessor;


        public async Task DeleteAsync(int id)
        {
            var user = await _unitOf.User.GetByIdAsync(id);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            await _unitOf.User.DeleteAsync(user);
            throw new StatusCodeException(HttpStatusCode.OK, "User has been deleted sucessfully");
        }

     

        public async Task<List<UserDto>> GetAllAsync(PaginationParams @params)
        {
            var users = await _unitOf.User.GetAllAsync().ToPagedListAsync(@params);
            return users.Select(x=>_mapper.Map<UserDto>(x)).ToList();
        }



        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _unitOf.User.GetByIdAsync(id);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            var res = _mapper.Map<UserDto>(user);
            return res;
        }

        public async Task UpdateAsync(int id, UpdateUserDto dto)
        {
            var model = await _unitOf.User.GetByIdAsync(id);
            if (model is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            var user = _mapper.Map<User>(dto); 
          
   
            user.Password = model.Password;

            await _unitOf.User.UpdateAsync(user);
            throw new StatusCodeException(HttpStatusCode.OK, "User has been updated sucessfully");
        }
    }
}
