using AutoMapper;
using HomeService.Domain.Core.UserAgg.Data;
using HomeService.Domain.Core.UserAgg.DTOs;
using HomeService.Domain.Core.UserAgg.Entities;
using HomeService.Domain.Core.UserAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.UserAgg
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, IMemoryCache cache, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var cacheKey = $"User_{id}";
            if (!_cache.TryGetValue(cacheKey, out UserDTO userDto))
            {
                var user = await _userRepository.GetByIdAsync(id);
                userDto = _mapper.Map<UserDTO>(user);
                _cache.Set(cacheKey, userDto);
            }

            _logger.LogInformation("Retrieved user by id: {Id}", id);
            return userDto;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            const string cacheKey = "AllUsers";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<UserDTO> cachedUsers))
            {
                var users = await _userRepository.GetAllAsync();
                cachedUsers = _mapper.Map<IEnumerable<UserDTO>>(users);
                _cache.Set(cacheKey, cachedUsers);
            }

            _logger.LogInformation("Retrieved all users from cache");
            return cachedUsers;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            _logger.LogInformation("User created: {@User}", user);
            _cache.Remove("AllUsers");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User not found: {Id}", id);
                throw new KeyNotFoundException("User not found.");
            }

            _mapper.Map(id, user);
            await _userRepository.UpdateAsync(user);
            _logger.LogInformation("User updated: {@User}", user);
            _cache.Remove("AllUsers");
            _cache.Remove($"User_{user.Id}");
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User not found: {Id}", id);
                return false;
            }

            await _userRepository.DeleteAsync(id);
            _logger.LogInformation("User deleted: {Id}", id);
            _cache.Remove("AllUsers");
            _cache.Remove($"User_{id}");
            return true;
        }
    }
}