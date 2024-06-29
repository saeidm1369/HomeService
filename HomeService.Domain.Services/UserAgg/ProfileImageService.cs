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
    public class ProfileImageService : IProfileImageService
    {
        private readonly IProfileImageRepository _profileImageRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ProfileImageService> _logger;

        public ProfileImageService(IProfileImageRepository profileImageRepository, IMapper mapper, IMemoryCache cache, ILogger<ProfileImageService> logger)
        {
            _profileImageRepository = profileImageRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<ProfileImageDTO> GetProfileImageByIdAsync(int id)
        {
            var cacheKey = $"ProfileImage_{id}";
            if (!_cache.TryGetValue(cacheKey, out ProfileImageDTO profileImageDto))
            {
                var profileImage = await _profileImageRepository.GetByIdAsync(id);
                profileImageDto = _mapper.Map<ProfileImageDTO>(profileImage);
                _cache.Set(cacheKey, profileImageDto);
            }

            _logger.LogInformation("Retrieved profile image by id: {Id}", id);
            return profileImageDto;
        }

        public async Task<IEnumerable<ProfileImageDTO>> GetAllProfileImagesAsync()
        {
            const string cacheKey = "AllProfileImages";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<ProfileImageDTO> cachedProfileImages))
            {
                var profileImages = await _profileImageRepository.GetAllAsync();
                cachedProfileImages = _mapper.Map<IEnumerable<ProfileImageDTO>>(profileImages);
                _cache.Set(cacheKey, cachedProfileImages);
            }

            _logger.LogInformation("Retrieved all profile images from cache");
            return cachedProfileImages;
        }

        public async Task<ProfileImageDTO> CreateProfileImageAsync(ProfileImageDTO profileImageDto)
        {
            var profileImage = _mapper.Map<ProfileImage>(profileImageDto);
            await _profileImageRepository.AddAsync(profileImage);
            _logger.LogInformation("Profile image created: {@ProfileImage}", profileImage);
            _cache.Remove("AllProfileImages");
            return _mapper.Map<ProfileImageDTO>(profileImage);
        }

        public async Task<ProfileImageDTO> UpdateProfileImageAsync(ProfileImageDTO profileImageDto)
        {
            var profileImage = await _profileImageRepository.GetByIdAsync(profileImageDto.Id);
            if (profileImage == null)
            {
                _logger.LogWarning("Profile image not found: {Id}", profileImageDto.Id);
                throw new KeyNotFoundException("Profile image not found.");
            }

            _mapper.Map(profileImageDto, profileImage);
            await _profileImageRepository.UpdateAsync(profileImage);
            _logger.LogInformation("Profile image updated: {@ProfileImage}", profileImage);
            _cache.Remove("AllProfileImages");
            _cache.Remove($"ProfileImage_{profileImage.Id}");
            return _mapper.Map<ProfileImageDTO>(profileImage);
        }

        public async Task<bool> DeleteProfileImageAsync(int id)
        {
            var success = await _profileImageRepository.DeleteAsync(id);
            if (success)
            {
                _logger.LogInformation("Profile image deleted: {Id}", id);
                _cache.Remove("AllProfileImages");
                _cache.Remove($"ProfileImage_{id}");
            }
            return success;
        }
    }
}
    

