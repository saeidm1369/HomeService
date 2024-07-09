using HomeService.Domain.Core.UserAgg.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.UserAgg.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> CreateUserAsync(UserDTO userDto);
        Task<UserDTO> UpdateUserAsync(string id);
        Task<bool> DeleteUserAsync(string id);
    }
}
