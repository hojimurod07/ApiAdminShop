using Application.Common.Exceptions;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using System.Net;

namespace Application.Services
{
    public class AdminService(IUnitOfWork unitOf, IValidator<User> validator) : IAdminService
    {
        private readonly IUnitOfWork _unitOf = unitOf;
        private readonly IValidator<User> _validator = validator;

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

        public Task<List<User>> GetAllAdminAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<List<User>> GetAllAdminAsync()
        //{
        //    var users = _unitOf.User.GetAllAsync();
        //    return users.Where(p => p.Role == Role.Admin);
        //}

    }
}
