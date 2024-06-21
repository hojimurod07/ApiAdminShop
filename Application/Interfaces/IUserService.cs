using Application.Common.DTOs.UserDtos;
using Application.Common.Utils;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task<List<UserDto>> GetAllAsync(PaginationParams @params);
        Task UpdateAsync(int id, UpdateUserDto dto);
        Task DeleteAsync(int id);
    }

}
