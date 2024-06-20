using Application.Common.DTOs.UserDtos;
using Application.Common.Exceptions;
using Application.Common.Security;
using Application.Interfaces;
using AutoMapper;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Application.Services
{
    public class AccountService(IUnitOfWork unitOf,
                                 IAuthManager authmanager,
                                 IMemoryCache cache,
                                 IEmailService emailService,
                                 IMapper mapper) : IAccountService
    {
        private readonly IUnitOfWork _unitOf = unitOf;
        private readonly IAuthManager _authmanager = authmanager;
 
        private readonly IMemoryCache _cache = cache;
        private readonly IEmailService _emailService = emailService;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> CheckCodeAsync(string email, string code)
        {
            var user = await _unitOf.User.GetByEmailAsync(email);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");
            if (_cache.TryGetValue(email, out var result))
            {
                if (code.Equals(result))
                {
                    user.isVerified = true;
                    await _unitOf.User.UpdateAsync(user);
                    return true;
                }
                else
                    throw new StatusCodeException(HttpStatusCode.Conflict, "Code is incorrect!");
            }
            else
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Code expired!");
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

        public async Task<bool> RegistrAsync(AddUserDto dto)
        {
            var user = await _unitOf.User.GetByEmailAsync(dto.Email);

            if (user is not null) throw new StatusCodeException(HttpStatusCode.AlreadyReported, "User already exists!");


            var entity = _mapper.Map<User>(dto); 
            entity.Password = PasswordHasher.GetHash(entity.Password);

            await _unitOf.User.CreateAsync(entity);

            return true;
        }

        public async Task SendCodeAsync(string email)
        {
            var user = await _unitOf.User.GetByEmailAsync(email);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");
            var code = GeneratedCode();
            _cache.Set(email, code, TimeSpan.FromSeconds(60));
            await _emailService.SendMessageAsync(email, "Verification code!", code);
        }
        private string GeneratedCode()
        => (new Random().Next(10000, 99999)).ToString();
    }
}
