using Application.Common.DTOs.UserDtos;
using Application.Common.Exceptions;
using Application.Common.Security;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Application.Services
{
    public class AccountService(IUnitOfWork unitOf,
                                 IAuthManager authmanager,
                                 IValidator<User> validator,
                                 IMemoryCache cache,
                                 IEmailService emailService) : IAccountService
    {
        private readonly IUnitOfWork _unitOf = unitOf;
        private readonly IAuthManager _authmanager = authmanager;
        private readonly IValidator<User> _validator = validator;
        private readonly IMemoryCache _cache = cache;
        private readonly IEmailService _emailService = emailService;

        public Task<bool> CheckCodeAsync(string email, string code)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(LoginDto login)
        {
            var user = await _unitOf.User.GetByEmailAsync(login.Email);

            if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");

            if (!user.Password.Equals(PasswordHasher.GetHash(login.Password)))
                throw new StatusCodeException(HttpStatusCode.Conflict, "Password incorrect!");
            if (!user.isVerified)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "User is not verified!");

            return _authmanager.GeneratedToken(user);
        }

        public Task<bool> RegistrAsync(AddUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task SendCodeAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
