using Application.Common.DTOs.UserDtos;
using Application.Common.Utils;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAdminShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService): ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok(await _userService.GetAllAsync(@params));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDto dto)
        {
            var id = int.Parse(HttpContext.User.FindFirst("Id")!.Value);

            await _userService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
