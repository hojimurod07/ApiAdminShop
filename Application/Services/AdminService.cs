using Application.Common.Exceptions;
using Application.Common.Extentions;
using Application.Common.Utils;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Services
{
    public class AdminService(IUnitOfWork unitOf) : IAdminService
    {
        private readonly IUnitOfWork _unitOf = unitOf;
      

        public async Task ChangeUserRoleAsync(int id)
        {
            var user = await _unitOf.User.GetByIdAsync(id);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");

            if (user.Role == Role.SuperAdmin)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Jinnilik qilma!");

            user.Role = user.Role == Role.Admin ? Role.User : Role.Admin;

            await _unitOf.User.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOf.User.GetByIdAsync(id);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");

            await _unitOf.User.DeleteAsync(user);
        }

  

        public async Task<List<User>> GetAllAdminAsync(PaginationParams @params)
        {
            var users = await _unitOf.User.GetAllAsync().ToPagedListAsync(@params);
            var admins =  users.Where(p=>p.Role==Role.Admin).ToList();
            return admins;
            
        }

       
    }
}
