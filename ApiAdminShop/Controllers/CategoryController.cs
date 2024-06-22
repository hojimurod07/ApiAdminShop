using Application.Common.DTOs.CategoryDtos;
using Application.Common.DTOs.ProductDtos;
using Application.Common.Utils;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAdminShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        private readonly ICategoryService _service = service;
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> CreateAsync([FromForm] AddCategoryDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpGet("categories")]
        [Authorize]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)

             => Ok(await _service.GetAllAsync(@params));

        [HttpDelete("id")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateAsync([FromForm] CategoryDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }
    }
}
