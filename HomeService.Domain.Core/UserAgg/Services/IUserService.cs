using HomeService.Domain.Core.UserAgg.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task<UserDTO> UpdateUserAsync(UserDTO userDto);
        Task<bool> DeleteUserAsync(string id);
        Task<string> SaveProfileImageAsync(IFormFile profileImage);
        Task<string> SaveProfileImageAsync(byte[] imageBytes);
        Task UpdateUserAsync(string id);
    }
}
